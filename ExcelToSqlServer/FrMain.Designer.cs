namespace ExcelToSqlServer
{
    partial class FrMain
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
            this.btnFindFile = new System.Windows.Forms.Button();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnShowExcel = new System.Windows.Forms.Button();
            this.btnToSqlServer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFindFile
            // 
            this.btnFindFile.Location = new System.Drawing.Point(12, 12);
            this.btnFindFile.Name = "btnFindFile";
            this.btnFindFile.Size = new System.Drawing.Size(75, 23);
            this.btnFindFile.TabIndex = 0;
            this.btnFindFile.Text = "选择文件";
            this.btnFindFile.UseVisualStyleBackColor = true;
            this.btnFindFile.Click += new System.EventHandler(this.BtnFindFile_Click);
            // 
            // tbFileName
            // 
            this.tbFileName.Enabled = false;
            this.tbFileName.Location = new System.Drawing.Point(94, 13);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(1421, 21);
            this.tbFileName.TabIndex = 1;
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(12, 40);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(1503, 756);
            this.dgv.TabIndex = 2;
            // 
            // btnShowExcel
            // 
            this.btnShowExcel.Location = new System.Drawing.Point(1268, 802);
            this.btnShowExcel.Name = "btnShowExcel";
            this.btnShowExcel.Size = new System.Drawing.Size(104, 23);
            this.btnShowExcel.TabIndex = 3;
            this.btnShowExcel.Text = "显示Excel内容";
            this.btnShowExcel.UseVisualStyleBackColor = true;
            this.btnShowExcel.Click += new System.EventHandler(this.BtnShowExcel_Click);
            // 
            // btnToSqlServer
            // 
            this.btnToSqlServer.Location = new System.Drawing.Point(1378, 802);
            this.btnToSqlServer.Name = "btnToSqlServer";
            this.btnToSqlServer.Size = new System.Drawing.Size(137, 23);
            this.btnToSqlServer.TabIndex = 4;
            this.btnToSqlServer.Text = "将展示内容导入到数据库";
            this.btnToSqlServer.UseVisualStyleBackColor = true;
            this.btnToSqlServer.Click += new System.EventHandler(this.BtnToSqlServer_Click);
            // 
            // FrMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1527, 827);
            this.Controls.Add(this.btnToSqlServer);
            this.Controls.Add(this.btnShowExcel);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.tbFileName);
            this.Controls.Add(this.btnFindFile);
            this.Name = "FrMain";
            this.Text = "Excel数据导入SqlServer工具";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFindFile;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnShowExcel;
        private System.Windows.Forms.Button btnToSqlServer;
    }
}

