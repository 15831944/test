namespace ImportExport
{
    partial class frmExportXml
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExportXml));
            this.txtPt = new System.Windows.Forms.TextBox();
            this.btnPath = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDc = new System.Windows.Forms.TextBox();
            this.lbDc = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPt = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbO = new System.Windows.Forms.Label();
            this.txtC = new System.Windows.Forms.TextBox();
            this.txtOc = new System.Windows.Forms.TextBox();
            this.txtPi = new System.Windows.Forms.TextBox();
            this.txtO = new System.Windows.Forms.TextBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lstConfig = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPt
            // 
            this.txtPt.Location = new System.Drawing.Point(173, 29);
            this.txtPt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPt.Name = "txtPt";
            this.txtPt.Size = new System.Drawing.Size(181, 25);
            this.txtPt.TabIndex = 0;
            // 
            // btnPath
            // 
            this.btnPath.Location = new System.Drawing.Point(419, 130);
            this.btnPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(75, 29);
            this.btnPath.TabIndex = 8;
            this.btnPath.Text = "选择...";
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(116, 131);
            this.txtFilePath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(293, 25);
            this.txtFilePath.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 136);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 15);
            this.label8.TabIndex = 33;
            this.label8.Text = "保存路径：";
            // 
            // txtDc
            // 
            this.txtDc.Location = new System.Drawing.Point(575, 24);
            this.txtDc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDc.Name = "txtDc";
            this.txtDc.Size = new System.Drawing.Size(180, 25);
            this.txtDc.TabIndex = 1;
            // 
            // lbDc
            // 
            this.lbDc.AutoSize = true;
            this.lbDc.Location = new System.Drawing.Point(451, 35);
            this.lbDc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDc.Name = "lbDc";
            this.lbDc.Size = new System.Drawing.Size(114, 15);
            this.lbDc.TabIndex = 29;
            this.lbDc.Text = "首选国家(dc)：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblPt);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lbO);
            this.groupBox1.Controls.Add(this.txtC);
            this.groupBox1.Controls.Add(this.txtOc);
            this.groupBox1.Controls.Add(this.txtPi);
            this.groupBox1.Controls.Add(this.txtO);
            this.groupBox1.Controls.Add(this.txtFileName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPt);
            this.groupBox1.Controls.Add(this.btnPath);
            this.groupBox1.Controls.Add(this.txtFilePath);
            this.groupBox1.Controls.Add(this.lbDc);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtDc);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(768, 185);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "参数配置";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(435, 100);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 15);
            this.label2.TabIndex = 75;
            this.label2.Text = "合作伙伴ID(pi)：";
            // 
            // lblPt
            // 
            this.lblPt.AutoSize = true;
            this.lblPt.Location = new System.Drawing.Point(15, 35);
            this.lblPt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPt.Name = "lblPt";
            this.lblPt.Size = new System.Drawing.Size(144, 15);
            this.lblPt.TabIndex = 68;
            this.lblPt.Text = "配置文件类型(pt)：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 100);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 15);
            this.label3.TabIndex = 74;
            this.label3.Text = "联盟名称ID(ci)：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(451, 68);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 15);
            this.label4.TabIndex = 73;
            this.label4.Text = "组织国家(oc)：";
            // 
            // lbO
            // 
            this.lbO.AutoSize = true;
            this.lbO.Location = new System.Drawing.Point(55, 68);
            this.lbO.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbO.Name = "lbO";
            this.lbO.Size = new System.Drawing.Size(106, 15);
            this.lbO.TabIndex = 72;
            this.lbO.Text = "机构名称(o)：";
            // 
            // txtC
            // 
            this.txtC.Location = new System.Drawing.Point(173, 94);
            this.txtC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(180, 25);
            this.txtC.TabIndex = 61;
            // 
            // txtOc
            // 
            this.txtOc.Location = new System.Drawing.Point(575, 56);
            this.txtOc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOc.Name = "txtOc";
            this.txtOc.Size = new System.Drawing.Size(181, 25);
            this.txtOc.TabIndex = 60;
            // 
            // txtPi
            // 
            this.txtPi.Location = new System.Drawing.Point(575, 89);
            this.txtPi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPi.Name = "txtPi";
            this.txtPi.Size = new System.Drawing.Size(181, 25);
            this.txtPi.TabIndex = 59;
            // 
            // txtO
            // 
            this.txtO.Location = new System.Drawing.Point(173, 61);
            this.txtO.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtO.Name = "txtO";
            this.txtO.Size = new System.Drawing.Size(181, 25);
            this.txtO.TabIndex = 53;
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(575, 131);
            this.txtFileName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(181, 25);
            this.txtFileName.TabIndex = 9;
            this.txtFileName.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(503, 136);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 37;
            this.label1.Text = "文件名：";
            this.label1.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lstConfig);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Size = new System.Drawing.Size(198, 282);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "配置列表";
            // 
            // lstConfig
            // 
            this.lstConfig.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstConfig.FullRowSelect = true;
            this.lstConfig.GridLines = true;
            this.lstConfig.Location = new System.Drawing.Point(4, 22);
            this.lstConfig.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstConfig.MultiSelect = false;
            this.lstConfig.Name = "lstConfig";
            this.lstConfig.Size = new System.Drawing.Size(190, 256);
            this.lstConfig.TabIndex = 0;
            this.lstConfig.UseCompatibleStateImageBehavior = false;
            this.lstConfig.View = System.Windows.Forms.View.Details;
            this.lstConfig.Click += new System.EventHandler(this.lstConfig_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "配置名称";
            this.columnHeader1.Width = 143;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer1.Size = new System.Drawing.Size(969, 282);
            this.splitContainer1.SplitterDistance = 766;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Controls.Add(this.txtMessage);
            this.groupBox3.Controls.Add(this.lblMessage);
            this.groupBox3.Location = new System.Drawing.Point(0, 186);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(768, 86);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Location = new System.Drawing.Point(575, 15);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 29);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保存配置";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.SystemColors.Control;
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessage.ForeColor = System.Drawing.Color.Red;
            this.txtMessage.Location = new System.Drawing.Point(73, 15);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.Size = new System.Drawing.Size(420, 65);
            this.txtMessage.TabIndex = 29;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(12, 15);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(52, 15);
            this.lblMessage.TabIndex = 18;
            this.lblMessage.Text = "提示：";
            // 
            // frmExportXml
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 282);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "frmExportXml";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "导出Xml文件配置";
            this.Load += new System.EventHandler(this.frmExportExcel_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtPt;
        private System.Windows.Forms.Button btnPath;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDc;
        private System.Windows.Forms.Label lbDc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListView lstConfig;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtO;
        private System.Windows.Forms.TextBox txtPi;
        private System.Windows.Forms.TextBox txtC;
        private System.Windows.Forms.TextBox txtOc;
        private System.Windows.Forms.Label lblPt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbO;

    }
}

