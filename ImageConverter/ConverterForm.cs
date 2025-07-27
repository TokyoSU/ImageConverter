using ImageMagick;
using NLog;
using System.ComponentModel;

namespace ImageConverter
{
    public partial class ConverterForm : Form
    {
        private static readonly Logger _Log = LogManager.GetCurrentClassLogger();
        private readonly List<string> _FilePathList = [];
        private static IEnumerable<string> MagickNetSupportedFormats
        {
            get
            {
                return MagickNET.SupportedFormats
                    .Where(f => f.SupportsReading)
                    .Select(f => "*." + f.Format.ToString().ToLowerInvariant())
                    .Distinct();
            }
        }

        public ConverterForm()
        {
            InitializeComponent();
            MakeFormatList();
            ConverterWorker.WorkerReportsProgress = true;
            ConverterWorker.WorkerSupportsCancellation = true;
            ConverterWorker.ProgressChanged += ConverterWorker_ProgressChanged;
            ConverterWorker.RunWorkerCompleted += ConverterWorker_RunWorkerCompleted;
            ConverterWorker.DoWork += ConverterWorker_DoWork;
        }

        private void MakeFormatList()
        {
            FormatList.Items.Clear();
            var list = Enum.GetNames<MagickFormat>().Where(f => f != "Undefined" && f != "Unknown").ToList();
            foreach (var format in list) FormatList.Items.Add(format);
            if (FormatList.Items.Count > 0) FormatList.SelectedIndex = 0; // Select the first item by default
        }

        private MagickFormat GetSelectedFormat()
        {
            if (FormatList.InvokeRequired)
            {
                // On est sur un thread autre que l'UI, donc on utilise Invoke
                var format = (MagickFormat)FormatList.Invoke(new Func<MagickFormat>(GetSelectedFormat));
                return format;
            }
            else
            {
                // On est d�j� sur le thread UI
                if (FormatList.SelectedItem is string selectedFormat)
                {
                    if (Enum.TryParse<MagickFormat>(selectedFormat, out var format))
                        return format;
                }
            }
            return MagickFormat.Png; // Default format if parsing fails
        }

        private static string GetFormatByName(MagickFormat format)
        {
            // Cherche le format support� correspondant dans la liste MagickNetSupportedFormats
            var formatInfo = MagickNET.SupportedFormats.FirstOrDefault(f => f.Format == format && f.SupportsReading);
            return formatInfo != null ? formatInfo.Format.ToString().ToLowerInvariant() : format.ToString().ToLowerInvariant();
        }

        private string _DestionationFolder = string.Empty;
        private int _ProgressValue = 0;
        private int _ProgressMaxValue = 0;

        private void ConverterWorker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void ConverterWorker_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            ProcessedCountStr.Text = $"{_ProgressValue} of {_ProgressMaxValue}";
        }

        private void SelectFileBtn_Click(object sender, EventArgs e)
        {
            var formats = string.Join(";", MagickNetSupportedFormats);
            SelectFolderImage.Multiselect = false;
            SelectFolderImage.FilterIndex = 0;
            SelectFolderImage.Filter = $"Image ({formats})|{formats}";
            if (SelectFolderImage.ShowDialog() == DialogResult.OK)
            {
                var fileName = SelectFolderImage.FileName;
                if (File.Exists(fileName) && !_FilePathList.Any(s => s.Equals(fileName, StringComparison.InvariantCultureIgnoreCase)))
                    _FilePathList.Add(fileName);
                else
                    _Log.Error($"{fileName} does not exist or is already in the list.");
                _ProgressMaxValue = _FilePathList.Count;
                ImageCountStr.Text = _FilePathList.Count.ToString();
                ProcessedCountStr.Text = $"{_ProgressValue} of {_ProgressMaxValue}";
            }
        }

        private void SelectFolderBtn_Click(object sender, EventArgs e)
        {
            var formats = string.Join(";", MagickNetSupportedFormats);
            SelectFolderImage.Multiselect = true;
            SelectFolderImage.FilterIndex = 0;
            SelectFolderImage.Filter = $"Images ({formats})|{formats}";
            if (SelectFolderImage.ShowDialog() == DialogResult.OK)
            {
                foreach (var fileName in SelectFolderImage.FileNames)
                {
                    if (File.Exists(fileName) && !_FilePathList.Any(s => s.Equals(fileName, StringComparison.InvariantCultureIgnoreCase)))
                        _FilePathList.Add(fileName);
                    else
                        _Log.Error($"{fileName} does not exist or is already in the list.");
                }
                _ProgressMaxValue = _FilePathList.Count;
                ImageCountStr.Text = _FilePathList.Count.ToString();
                ProcessedCountStr.Text = $"{_ProgressValue} of {_ProgressMaxValue}";
            }
        }

        private void ConverterWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            if (string.IsNullOrEmpty(_DestionationFolder) || string.IsNullOrWhiteSpace(_DestionationFolder))
            {
                MessageBox.Show("Please select a destination folder for converted images.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }

            Parallel.ForEach(_FilePathList, (storage) =>
            {
                if (ConverterWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                try
                {
                    using var result = new MagickImage(storage);
                    result.Format = GetSelectedFormat();
                    var fileNameWithoutExt = Path.GetFileNameWithoutExtension(storage);
                    var fileName = $"{fileNameWithoutExt}.{GetFormatByName(GetSelectedFormat())}";
                    var filePath = _DestionationFolder + "\\" + fileName;
                    _Log.Debug($"Converting {storage} to {filePath} with format {GetSelectedFormat()}");
                    result.Write(filePath);
                }
                catch (Exception ex)
                {
                    _Log.Error(ex, $"Error processing {storage}");
                }

                ConverterWorker.ReportProgress(_ProgressValue++);
            });
        }

        private void StartConvertBtn_Click(object sender, EventArgs e)
        {
            ConverterWorker.RunWorkerAsync();
        }

        private void CancelConvertBtn_Click(object sender, EventArgs e)
        {
            ConverterWorker.CancelAsync();
        }

        private void SelectDestinationBtn_Click(object sender, EventArgs e)
        {
            var destFolder = new FolderBrowserDialog
            {
                Description = "Select the destination folder for converted images",
                ShowNewFolderButton = true
            };

            if (destFolder.ShowDialog() == DialogResult.OK)
            {
                if (Directory.Exists(destFolder.SelectedPath))
                {
                    _DestionationFolder = destFolder.SelectedPath;
                    SelectFolderStr.Text = _DestionationFolder;
                }
                else
                {
                    MessageBox.Show("The selected folder does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _DestionationFolder = string.Empty;
                    SelectFolderStr.Text = "No folder selected";
                }
            }
        }

        private void ClearList_Click(object sender, EventArgs e)
        {
            _FilePathList.Clear();
            _ProgressValue = 0;
            _ProgressMaxValue = 0;
            ImageCountStr.Text = _FilePathList.Count.ToString();
            ProcessedCountStr.Text = $"{_ProgressValue} of {_ProgressMaxValue}";
        }
    }
}
