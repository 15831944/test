namespace ImportExport
{
    partial class frmOperateExportXml
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOperateExportXml));
            this.btnPath = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtC = new System.Windows.Forms.TextBox();
            this.txtOc = new System.Windows.Forms.TextBox();
            this.txtPi = new System.Windows.Forms.TextBox();
            this.lbPi = new System.Windows.Forms.Label();
            this.lbC = new System.Windows.Forms.Label();
            this.lbOc = new System.Windows.Forms.Label();
            this.txtO = new System.Windows.Forms.TextBox();
            this.lbO = new System.Windows.Forms.Label();
            this.txtPt = new System.Windows.Forms.TextBox();
            this.lblPt = new System.Windows.Forms.Label();
            this.lbDc = new System.Windows.Forms.Label();
            this.txtDc = new System.Windows.Forms.TextBox();
            this.dtpUa = new System.Windows.Forms.DateTimePicker();
            this.lbUa = new System.Windows.Forms.Label();
            this.lbUb = new System.Windows.Forms.Label();
            this.dtpUb = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPath
            // 
            this.btnPath.Location = new System.Drawing.Point(479, 170);
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
            this.txtFilePath.Location = new System.Drawing.Point(180, 168);
            this.txtFilePath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(293, 25);
            this.txtFilePath.TabIndex = 7;
            this.txtFilePath.Text = "D:\\ExportXml";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(85, 178);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 15);
            this.label8.TabIndex = 33;
            this.label8.Text = "保存路径：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtC);
            this.groupBox1.Controls.Add(this.txtOc);
            this.groupBox1.Controls.Add(this.txtPi);
            this.groupBox1.Controls.Add(this.lbPi);
            this.groupBox1.Controls.Add(this.lbC);
            this.groupBox1.Controls.Add(this.lbOc);
            this.groupBox1.Controls.Add(this.txtO);
            this.groupBox1.Controls.Add(this.lbO);
            this.groupBox1.Controls.Add(this.txtPt);
            this.groupBox1.Controls.Add(this.lblPt);
            this.groupBox1.Controls.Add(this.lbDc);
            this.groupBox1.Controls.Add(this.txtDc);
            this.groupBox1.Controls.Add(this.dtpUa);
            this.groupBox1.Controls.Add(this.lbUa);
            this.groupBox1.Controls.Add(this.lbUb);
            this.groupBox1.Controls.Add(this.dtpUb);
            this.groupBox1.Controls.Add(this.btnPath);
            this.groupBox1.Controls.Add(this.txtFilePath);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(9, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(719, 219);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "参数选择";
            // 
            // txtC
            // 
            this.txtC.Enabled = false;
            this.txtC.Location = new System.Drawing.Point(180, 134);
            this.txtC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(181, 25);
            this.txtC.TabIndex = 73;
            // 
            // txtOc
            // 
            this.txtOc.Location = new System.Drawing.Point(523, 95);
            this.txtOc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOc.Name = "txtOc";
            this.txtOc.Size = new System.Drawing.Size(180, 25);
            this.txtOc.TabIndex = 72;
            // 
            // txtPi
            // 
            this.txtPi.Location = new System.Drawing.Point(523, 134);
            this.txtPi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPi.Name = "txtPi";
            this.txtPi.Size = new System.Drawing.Size(180, 25);
            this.txtPi.TabIndex = 71;
            // 
            // lbPi
            // 
            this.lbPi.AutoSize = true;
            this.lbPi.Location = new System.Drawing.Point(380, 139);
            this.lbPi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPi.Name = "lbPi";
            this.lbPi.Size = new System.Drawing.Size(130, 15);
            this.lbPi.TabIndex = 70;
            this.lbPi.Text = "合作伙伴ID(pi)：";
            // 
            // lbC
            // 
            this.lbC.AutoSize = true;
            this.lbC.Location = new System.Drawing.Point(35, 139);
            this.lbC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbC.Name = "lbC";
            this.lbC.Size = new System.Drawing.Size(130, 15);
            this.lbC.TabIndex = 69;
            this.lbC.Text = "联盟名称ID(ci)：";
            // 
            // lbOc
            // 
            this.lbOc.AutoSize = true;
            this.lbOc.Location = new System.Drawing.Point(396, 100);
            this.lbOc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbOc.Name = "lbOc";
            this.lbOc.Size = new System.Drawing.Size(114, 15);
            this.lbOc.TabIndex = 68;
            this.lbOc.Text = "组织国家(oc)：";
            // 
            // txtO
            // 
            this.txtO.Location = new System.Drawing.Point(180, 95);
            this.txtO.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtO.Name = "txtO";
            this.txtO.Size = new System.Drawing.Size(181, 25);
            this.txtO.TabIndex = 67;
            // 
            // lbO
            // 
            this.lbO.AutoSize = true;
            this.lbO.Location = new System.Drawing.Point(61, 100);
            this.lbO.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbO.Name = "lbO";
            this.lbO.Size = new System.Drawing.Size(106, 15);
            this.lbO.TabIndex = 66;
            this.lbO.Text = "机构名称(o)：";
            // 
            // txtPt
            // 
            this.txtPt.Location = new System.Drawing.Point(180, 56);
            this.txtPt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPt.Name = "txtPt";
            this.txtPt.Size = new System.Drawing.Size(181, 25);
            this.txtPt.TabIndex = 62;
            // 
            // lblPt
            // 
            this.lblPt.AutoSize = true;
            this.lblPt.Location = new System.Drawing.Point(21, 61);
            this.lblPt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPt.Name = "lblPt";
            this.lblPt.Size = new System.Drawing.Size(144, 15);
            this.lblPt.TabIndex = 64;
            this.lblPt.Text = "配置文件类型(pt)：";
            // 
            // lbDc
            // 
            this.lbDc.AutoSize = true;
            this.lbDc.Location = new System.Drawing.Point(476, 61);
            this.lbDc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDc.Name = "lbDc";
            this.lbDc.Size = new System.Drawing.Size(38, 15);
            this.lbDc.TabIndex = 65;
            this.lbDc.Text = "dc：";
            // 
            // txtDc
            // 
            this.txtDc.Location = new System.Drawing.Point(523, 56);
            this.txtDc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDc.Name = "txtDc";
            this.txtDc.Size = new System.Drawing.Size(180, 25);
            this.txtDc.TabIndex = 63;
            // 
            // dtpUa
            // 
            this.dtpUa.CustomFormat = "yyyy-MM-dd ";
            this.dtpUa.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpUa.Location = new System.Drawing.Point(180, 18);
            this.dtpUa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpUa.Name = "dtpUa";
            this.dtpUa.Size = new System.Drawing.Size(180, 25);
            this.dtpUa.TabIndex = 51;
            // 
            // lbUa
            // 
            this.lbUa.AutoSize = true;
            this.lbUa.Location = new System.Drawing.Point(53, 22);
            this.lbUa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbUa.Name = "lbUa";
            this.lbUa.Size = new System.Drawing.Size(114, 15);
            this.lbUa.TabIndex = 50;
            this.lbUa.Text = "起始时间(ua)：";
            // 
            // lbUb
            // 
            this.lbUb.AutoSize = true;
            this.lbUb.Location = new System.Drawing.Point(403, 22);
            this.lbUb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbUb.Name = "lbUb";
            this.lbUb.Size = new System.Drawing.Size(114, 15);
            this.lbUb.TabIndex = 48;
            this.lbUb.Text = "结束时间(ub)：";
            // 
            // dtpUb
            // 
            this.dtpUb.CustomFormat = "yyyy-MM-dd ";
            this.dtpUb.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpUb.Location = new System.Drawing.Point(523, 18);
            this.dtpUb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpUb.Name = "dtpUb";
            this.dtpUb.Size = new System.Drawing.Size(181, 25);
            this.dtpUb.TabIndex = 49;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Location = new System.Drawing.Point(613, 235);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 29);
            this.btnSave.TabIndex = 30;
            this.btnSave.Text = "导出文件";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.SystemColors.Control;
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessage.ForeColor = System.Drawing.Color.Red;
            this.txtMessage.Location = new System.Drawing.Point(104, 235);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.Size = new System.Drawing.Size(420, 65);
            this.txtMessage.TabIndex = 32;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(43, 235);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(52, 15);
            this.lblMessage.TabIndex = 31;
            this.lblMessage.Text = "提示：";
            // 
            // btnImport
            // 
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnImport.Location = new System.Drawing.Point(613, 300);
            this.btnImport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(100, 29);
            this.btnImport.TabIndex = 30;
            this.btnImport.Text = "导入数据库";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // frmOperateExportXml
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 372);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "frmOperateExportXml";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "手动导出";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPath;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbUa;
        private System.Windows.Forms.DateTimePicker dtpUa;
        private System.Windows.Forms.Label lbUb;
        private System.Windows.Forms.DateTimePicker dtpUb;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtC;
        private System.Windows.Forms.TextBox txtOc;
        private System.Windows.Forms.TextBox txtPi;
        private System.Windows.Forms.Label lbPi;
        private System.Windows.Forms.Label lbC;
        private System.Windows.Forms.Label lbOc;
        private System.Windows.Forms.TextBox txtO;
        private System.Windows.Forms.Label lbO;
        private System.Windows.Forms.TextBox txtPt;
        private System.Windows.Forms.Label lblPt;
        private System.Windows.Forms.Label lbDc;
        private System.Windows.Forms.TextBox txtDc;
        private System.Windows.Forms.Button btnImport;

    }
}

