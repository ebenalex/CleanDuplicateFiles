namespace CleanDuplicationFiles
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnChooseDirectory = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.btnCollectBaseInfo = new System.Windows.Forms.Button();
            this.txtRunningLog = new System.Windows.Forms.TextBox();
            this.lvResult = new System.Windows.Forms.ListView();
            this.Selected = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GroupID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DuplicateCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CreateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ModifyTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileAllPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CRC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmbCondition = new System.Windows.Forms.ComboBox();
            this.btnAnalysis = new System.Windows.Forms.Button();
            this.btnKeepNewFiles = new System.Windows.Forms.Button();
            this.btnKeepOldFiles = new System.Windows.Forms.Button();
            this.btnComputeCRC32 = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnChooseDirectory
            // 
            this.btnChooseDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseDirectory.Location = new System.Drawing.Point(576, 3);
            this.btnChooseDirectory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnChooseDirectory.Name = "btnChooseDirectory";
            this.btnChooseDirectory.Size = new System.Drawing.Size(92, 35);
            this.btnChooseDirectory.TabIndex = 0;
            this.btnChooseDirectory.Text = "选择目录";
            this.btnChooseDirectory.UseVisualStyleBackColor = true;
            this.btnChooseDirectory.Click += new System.EventHandler(this.btnChooseDirectory_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "1、选择目录：";
            // 
            // txtDirectory
            // 
            this.txtDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirectory.Location = new System.Drawing.Point(108, 9);
            this.txtDirectory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(462, 23);
            this.txtDirectory.TabIndex = 2;
            // 
            // btnCollectBaseInfo
            // 
            this.btnCollectBaseInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCollectBaseInfo.Location = new System.Drawing.Point(674, 3);
            this.btnCollectBaseInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCollectBaseInfo.Name = "btnCollectBaseInfo";
            this.btnCollectBaseInfo.Size = new System.Drawing.Size(112, 35);
            this.btnCollectBaseInfo.TabIndex = 3;
            this.btnCollectBaseInfo.Text = "采集文件信息";
            this.btnCollectBaseInfo.UseVisualStyleBackColor = true;
            this.btnCollectBaseInfo.Click += new System.EventHandler(this.btnCollectBaseInfo_Click);
            // 
            // txtRunningLog
            // 
            this.txtRunningLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRunningLog.Location = new System.Drawing.Point(13, 53);
            this.txtRunningLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRunningLog.Multiline = true;
            this.txtRunningLog.Name = "txtRunningLog";
            this.txtRunningLog.Size = new System.Drawing.Size(773, 89);
            this.txtRunningLog.TabIndex = 4;
            // 
            // lvResult
            // 
            this.lvResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvResult.CheckBoxes = true;
            this.lvResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Selected,
            this.GroupID,
            this.FileName,
            this.FileSize,
            this.DuplicateCount,
            this.CreateTime,
            this.ModifyTime,
            this.FileAllPath,
            this.CRC,
            this.FileID});
            this.lvResult.Font = new System.Drawing.Font("Franklin Gothic Book", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvResult.FullRowSelect = true;
            this.lvResult.GridLines = true;
            this.lvResult.Location = new System.Drawing.Point(13, 191);
            this.lvResult.Name = "lvResult";
            this.lvResult.Size = new System.Drawing.Size(773, 197);
            this.lvResult.TabIndex = 5;
            this.lvResult.UseCompatibleStateImageBehavior = false;
            this.lvResult.View = System.Windows.Forms.View.Details;
            this.lvResult.DoubleClick += new System.EventHandler(this.lvResult_DoubleClick);
            // 
            // Selected
            // 
            this.Selected.Text = "选择";
            this.Selected.Width = 30;
            // 
            // GroupID
            // 
            this.GroupID.Text = "组号";
            // 
            // FileName
            // 
            this.FileName.DisplayIndex = 3;
            this.FileName.Text = "文件名称";
            this.FileName.Width = 250;
            // 
            // FileSize
            // 
            this.FileSize.DisplayIndex = 4;
            this.FileSize.Text = "文件大小";
            this.FileSize.Width = 120;
            // 
            // DuplicateCount
            // 
            this.DuplicateCount.DisplayIndex = 5;
            this.DuplicateCount.Text = "重复";
            // 
            // CreateTime
            // 
            this.CreateTime.DisplayIndex = 6;
            this.CreateTime.Text = "创建日期";
            this.CreateTime.Width = 150;
            // 
            // ModifyTime
            // 
            this.ModifyTime.DisplayIndex = 7;
            this.ModifyTime.Text = "修改日期";
            this.ModifyTime.Width = 150;
            // 
            // FileAllPath
            // 
            this.FileAllPath.DisplayIndex = 8;
            this.FileAllPath.Text = "文件路径";
            this.FileAllPath.Width = 500;
            // 
            // CRC
            // 
            this.CRC.DisplayIndex = 2;
            this.CRC.Text = "CRC32";
            this.CRC.Width = 300;
            // 
            // FileID
            // 
            this.FileID.Text = "记录流水号";
            this.FileID.Width = 120;
            // 
            // cmbCondition
            // 
            this.cmbCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCondition.FormattingEnabled = true;
            this.cmbCondition.Items.AddRange(new object[] {
            " 文件名称+文件大小+CRC值相符+10M大小以上"});
            this.cmbCondition.Location = new System.Drawing.Point(12, 149);
            this.cmbCondition.Name = "cmbCondition";
            this.cmbCondition.Size = new System.Drawing.Size(452, 26);
            this.cmbCondition.TabIndex = 6;
            // 
            // btnAnalysis
            // 
            this.btnAnalysis.Location = new System.Drawing.Point(597, 149);
            this.btnAnalysis.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAnalysis.Name = "btnAnalysis";
            this.btnAnalysis.Size = new System.Drawing.Size(92, 35);
            this.btnAnalysis.TabIndex = 7;
            this.btnAnalysis.Text = "分析重复";
            this.btnAnalysis.UseVisualStyleBackColor = true;
            this.btnAnalysis.Click += new System.EventHandler(this.btnAnalysis_Click);
            // 
            // btnKeepNewFiles
            // 
            this.btnKeepNewFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKeepNewFiles.Location = new System.Drawing.Point(643, 395);
            this.btnKeepNewFiles.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnKeepNewFiles.Name = "btnKeepNewFiles";
            this.btnKeepNewFiles.Size = new System.Drawing.Size(143, 35);
            this.btnKeepNewFiles.TabIndex = 9;
            this.btnKeepNewFiles.Text = "保留最近的文件";
            this.btnKeepNewFiles.UseVisualStyleBackColor = true;
            this.btnKeepNewFiles.Click += new System.EventHandler(this.btnKeepNewFiles_Click);
            // 
            // btnKeepOldFiles
            // 
            this.btnKeepOldFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKeepOldFiles.Location = new System.Drawing.Point(479, 395);
            this.btnKeepOldFiles.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnKeepOldFiles.Name = "btnKeepOldFiles";
            this.btnKeepOldFiles.Size = new System.Drawing.Size(143, 35);
            this.btnKeepOldFiles.TabIndex = 10;
            this.btnKeepOldFiles.Text = "保留较老的文件";
            this.btnKeepOldFiles.UseVisualStyleBackColor = true;
            this.btnKeepOldFiles.Click += new System.EventHandler(this.btnKeepOldFiles_Click);
            // 
            // btnComputeCRC32
            // 
            this.btnComputeCRC32.Location = new System.Drawing.Point(490, 149);
            this.btnComputeCRC32.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnComputeCRC32.Name = "btnComputeCRC32";
            this.btnComputeCRC32.Size = new System.Drawing.Size(92, 35);
            this.btnComputeCRC32.TabIndex = 8;
            this.btnComputeCRC32.Text = "计算CRC32";
            this.btnComputeCRC32.UseVisualStyleBackColor = true;
            this.btnComputeCRC32.Click += new System.EventHandler(this.btnComputeCRC32_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Location = new System.Drawing.Point(306, 395);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(143, 35);
            this.btnRemove.TabIndex = 11;
            this.btnRemove.Text = "删除选中的文件";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 433);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnKeepOldFiles);
            this.Controls.Add(this.btnKeepNewFiles);
            this.Controls.Add(this.btnComputeCRC32);
            this.Controls.Add(this.btnAnalysis);
            this.Controls.Add(this.cmbCondition);
            this.Controls.Add(this.lvResult);
            this.Controls.Add(this.txtRunningLog);
            this.Controls.Add(this.btnCollectBaseInfo);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnChooseDirectory);
            this.Font = new System.Drawing.Font("Franklin Gothic Book", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmMain";
            this.Text = "Clean Duplicate Files";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChooseDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.Button btnCollectBaseInfo;
        private System.Windows.Forms.TextBox txtRunningLog;
        private System.Windows.Forms.ListView lvResult;
        private System.Windows.Forms.ComboBox cmbCondition;
        private System.Windows.Forms.Button btnAnalysis;
        private System.Windows.Forms.ColumnHeader Selected;
        private System.Windows.Forms.ColumnHeader GroupID;
        private System.Windows.Forms.ColumnHeader FileName;
        private System.Windows.Forms.ColumnHeader FileSize;
        private System.Windows.Forms.ColumnHeader DuplicateCount;
        private System.Windows.Forms.ColumnHeader CreateTime;
        private System.Windows.Forms.ColumnHeader ModifyTime;
        private System.Windows.Forms.ColumnHeader FileAllPath;
        private System.Windows.Forms.ColumnHeader CRC;
        private System.Windows.Forms.ColumnHeader FileID;
        private System.Windows.Forms.Button btnKeepNewFiles;
        private System.Windows.Forms.Button btnKeepOldFiles;
        private System.Windows.Forms.Button btnComputeCRC32;
        private System.Windows.Forms.Button btnRemove;
    }
}

