namespace ImageConverter
{
    partial class ConverterForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SelectImage = new OpenFileDialog();
            SelectFolderImage = new OpenFileDialog();
            SelectFileBtn = new Button();
            SelectFolderBtn = new Button();
            ConverterWorker = new System.ComponentModel.BackgroundWorker();
            CancelConvertBtn = new Button();
            FormatList = new ComboBox();
            FormatStr = new Label();
            StartConvertBtn = new Button();
            label1 = new Label();
            ImageCountStr = new Label();
            SelectDestinationBtn = new Button();
            label2 = new Label();
            SelectFolderStr = new Label();
            label3 = new Label();
            ProcessedCountStr = new Label();
            ClearList = new Button();
            SuspendLayout();
            // 
            // SelectImage
            // 
            SelectImage.FileName = "SelectImage";
            SelectImage.Filter = "Images|*.";
            // 
            // SelectFolderImage
            // 
            SelectFolderImage.FileName = "SelectFolderImage";
            // 
            // SelectFileBtn
            // 
            SelectFileBtn.Location = new Point(12, 12);
            SelectFileBtn.Name = "SelectFileBtn";
            SelectFileBtn.Size = new Size(75, 23);
            SelectFileBtn.TabIndex = 1;
            SelectFileBtn.Text = "Select file..";
            SelectFileBtn.UseVisualStyleBackColor = true;
            SelectFileBtn.Click += SelectFileBtn_Click;
            // 
            // SelectFolderBtn
            // 
            SelectFolderBtn.Location = new Point(93, 12);
            SelectFolderBtn.Name = "SelectFolderBtn";
            SelectFolderBtn.Size = new Size(87, 23);
            SelectFolderBtn.TabIndex = 2;
            SelectFolderBtn.Text = "Select folder..";
            SelectFolderBtn.UseVisualStyleBackColor = true;
            SelectFolderBtn.Click += SelectFolderBtn_Click;
            // 
            // ConverterWorker
            // 
            ConverterWorker.WorkerReportsProgress = true;
            ConverterWorker.WorkerSupportsCancellation = true;
            // 
            // CancelConvertBtn
            // 
            CancelConvertBtn.Location = new Point(122, 112);
            CancelConvertBtn.Name = "CancelConvertBtn";
            CancelConvertBtn.Size = new Size(117, 23);
            CancelConvertBtn.TabIndex = 3;
            CancelConvertBtn.Text = "Cancel Convertion";
            CancelConvertBtn.UseVisualStyleBackColor = true;
            CancelConvertBtn.Click += CancelConvertBtn_Click;
            // 
            // FormatList
            // 
            FormatList.FormattingEnabled = true;
            FormatList.Location = new Point(413, 12);
            FormatList.Name = "FormatList";
            FormatList.Size = new Size(121, 23);
            FormatList.TabIndex = 4;
            // 
            // FormatStr
            // 
            FormatStr.AutoSize = true;
            FormatStr.Location = new Point(302, 16);
            FormatStr.Name = "FormatStr";
            FormatStr.Size = new Size(105, 15);
            FormatStr.TabIndex = 5;
            FormatStr.Text = "Format to convert:";
            // 
            // StartConvertBtn
            // 
            StartConvertBtn.Location = new Point(12, 111);
            StartConvertBtn.Name = "StartConvertBtn";
            StartConvertBtn.Size = new Size(104, 23);
            StartConvertBtn.TabIndex = 6;
            StartConvertBtn.Text = "Start Convertion";
            StartConvertBtn.UseVisualStyleBackColor = true;
            StartConvertBtn.Click += StartConvertBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 38);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 7;
            label1.Text = "Loaded images:";
            // 
            // ImageCountStr
            // 
            ImageCountStr.AutoSize = true;
            ImageCountStr.Location = new Point(108, 38);
            ImageCountStr.Name = "ImageCountStr";
            ImageCountStr.Size = new Size(0, 15);
            ImageCountStr.TabIndex = 8;
            // 
            // SelectDestinationBtn
            // 
            SelectDestinationBtn.Location = new Point(186, 12);
            SelectDestinationBtn.Name = "SelectDestinationBtn";
            SelectDestinationBtn.Size = new Size(110, 23);
            SelectDestinationBtn.TabIndex = 9;
            SelectDestinationBtn.Text = "Select Destination";
            SelectDestinationBtn.UseVisualStyleBackColor = true;
            SelectDestinationBtn.Click += SelectDestinationBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 78);
            label2.Name = "label2";
            label2.Size = new Size(155, 15);
            label2.TabIndex = 10;
            label2.Text = "Select folder for destination:";
            // 
            // SelectFolderStr
            // 
            SelectFolderStr.AutoSize = true;
            SelectFolderStr.Location = new Point(12, 93);
            SelectFolderStr.Name = "SelectFolderStr";
            SelectFolderStr.Size = new Size(36, 15);
            SelectFolderStr.TabIndex = 11;
            SelectFolderStr.Text = "None";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 53);
            label3.Name = "label3";
            label3.Size = new Size(104, 15);
            label3.TabIndex = 12;
            label3.Text = "Processed images:";
            // 
            // ProcessedCountStr
            // 
            ProcessedCountStr.AutoSize = true;
            ProcessedCountStr.Location = new Point(122, 53);
            ProcessedCountStr.Name = "ProcessedCountStr";
            ProcessedCountStr.Size = new Size(36, 15);
            ProcessedCountStr.TabIndex = 13;
            ProcessedCountStr.Text = "0 of 0";
            // 
            // ClearList
            // 
            ClearList.Location = new Point(245, 112);
            ClearList.Name = "ClearList";
            ClearList.Size = new Size(75, 23);
            ClearList.TabIndex = 14;
            ClearList.Text = "Clear";
            ClearList.UseVisualStyleBackColor = true;
            ClearList.Click += ClearList_Click;
            // 
            // ConverterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 143);
            Controls.Add(ClearList);
            Controls.Add(ProcessedCountStr);
            Controls.Add(label3);
            Controls.Add(SelectFolderStr);
            Controls.Add(label2);
            Controls.Add(SelectDestinationBtn);
            Controls.Add(ImageCountStr);
            Controls.Add(label1);
            Controls.Add(StartConvertBtn);
            Controls.Add(FormatStr);
            Controls.Add(FormatList);
            Controls.Add(CancelConvertBtn);
            Controls.Add(SelectFolderBtn);
            Controls.Add(SelectFileBtn);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ConverterForm";
            Text = "Image Converter";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog SelectImage;
        private OpenFileDialog SelectFolderImage;
        private Button SelectFileBtn;
        private Button SelectFolderBtn;
        private System.ComponentModel.BackgroundWorker ConverterWorker;
        private Button CancelConvertBtn;
        private ComboBox FormatList;
        private Label FormatStr;
        private Button StartConvertBtn;
        private Label label1;
        private Label ImageCountStr;
        private Button SelectDestinationBtn;
        private Label label2;
        private Label SelectFolderStr;
        private Label label3;
        private Label ProcessedCountStr;
        private Button ClearList;
    }
}
