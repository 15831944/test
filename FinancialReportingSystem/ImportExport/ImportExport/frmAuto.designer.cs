namespace ImportExport
{
    partial class frmAuto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAuto));
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.txtConfig = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panT = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpT = new System.Windows.Forms.DateTimePicker();
            this.numT = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.panD = new System.Windows.Forms.Panel();
            this.dtpD = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.rbtnD = new System.Windows.Forms.RadioButton();
            this.rbtnT = new System.Windows.Forms.RadioButton();
            this.lblText = new System.Windows.Forms.Label();
            this.btnES = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lstConfig = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.groupBox.SuspendLayout();
            this.panT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numT)).BeginInit();
            this.panD.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox.Controls.Add(this.txtConfig);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.panT);
            this.groupBox.Controls.Add(this.panD);
            this.groupBox.Controls.Add(this.rbtnD);
            this.groupBox.Controls.Add(this.rbtnT);
            this.groupBox.Location = new System.Drawing.Point(0, 4);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(298, 219);
            this.groupBox.TabIndex = 7;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "设置运行周期";
            // 
            // txtConfig
            // 
            this.txtConfig.Location = new System.Drawing.Point(68, 146);
            this.txtConfig.Name = "txtConfig";
            this.txtConfig.ReadOnly = true;
            this.txtConfig.Size = new System.Drawing.Size(211, 21);
            this.txtConfig.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "选择：";
            // 
            // panT
            // 
            this.panT.Controls.Add(this.label6);
            this.panT.Controls.Add(this.dtpT);
            this.panT.Controls.Add(this.numT);
            this.panT.Controls.Add(this.label5);
            this.panT.Location = new System.Drawing.Point(18, 87);
            this.panT.Name = "panT";
            this.panT.Size = new System.Drawing.Size(264, 54);
            this.panT.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "开始：";
            // 
            // dtpT
            // 
            this.dtpT.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpT.Location = new System.Drawing.Point(50, 3);
            this.dtpT.Name = "dtpT";
            this.dtpT.Size = new System.Drawing.Size(211, 21);
            this.dtpT.TabIndex = 2;
            // 
            // numT
            // 
            this.numT.Location = new System.Drawing.Point(50, 30);
            this.numT.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numT.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numT.Name = "numT";
            this.numT.Size = new System.Drawing.Size(211, 21);
            this.numT.TabIndex = 1;
            this.numT.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "间隔：";
            // 
            // panD
            // 
            this.panD.Controls.Add(this.dtpD);
            this.panD.Controls.Add(this.label4);
            this.panD.Location = new System.Drawing.Point(18, 57);
            this.panD.Name = "panD";
            this.panD.Size = new System.Drawing.Size(264, 28);
            this.panD.TabIndex = 7;
            // 
            // dtpD
            // 
            this.dtpD.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpD.Location = new System.Drawing.Point(50, 3);
            this.dtpD.Name = "dtpD";
            this.dtpD.Size = new System.Drawing.Size(211, 21);
            this.dtpD.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "时间：";
            // 
            // rbtnD
            // 
            this.rbtnD.AutoSize = true;
            this.rbtnD.Location = new System.Drawing.Point(148, 20);
            this.rbtnD.Name = "rbtnD";
            this.rbtnD.Size = new System.Drawing.Size(47, 16);
            this.rbtnD.TabIndex = 4;
            this.rbtnD.Text = "每天";
            this.rbtnD.UseVisualStyleBackColor = true;
            this.rbtnD.CheckedChanged += new System.EventHandler(this.rbtn_CheckedChanged);
            // 
            // rbtnT
            // 
            this.rbtnT.AutoSize = true;
            this.rbtnT.Location = new System.Drawing.Point(211, 20);
            this.rbtnT.Name = "rbtnT";
            this.rbtnT.Size = new System.Drawing.Size(71, 16);
            this.rbtnT.TabIndex = 5;
            this.rbtnT.Text = "间隔小时";
            this.rbtnT.UseVisualStyleBackColor = true;
            this.rbtnT.Visible = false;
            this.rbtnT.CheckedChanged += new System.EventHandler(this.rbtn_CheckedChanged);
            // 
            // lblText
            // 
            this.lblText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblText.AutoSize = true;
            this.lblText.Font = new System.Drawing.Font("SimSun", 9F);
            this.lblText.ForeColor = System.Drawing.Color.Red;
            this.lblText.Location = new System.Drawing.Point(8, 229);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(41, 12);
            this.lblText.TabIndex = 22;
            this.lblText.Text = "提示：";
            // 
            // btnES
            // 
            this.btnES.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnES.Location = new System.Drawing.Point(223, 229);
            this.btnES.Name = "btnES";
            this.btnES.Size = new System.Drawing.Size(75, 23);
            this.btnES.TabIndex = 21;
            this.btnES.Text = "保存配置";
            this.btnES.UseVisualStyleBackColor = true;
            this.btnES.Click += new System.EventHandler(this.btnES_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.lstConfig);
            this.groupBox4.Location = new System.Drawing.Point(304, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(176, 254);
            this.groupBox4.TabIndex = 23;
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
            this.lstConfig.Location = new System.Drawing.Point(3, 17);
            this.lstConfig.MultiSelect = false;
            this.lstConfig.Name = "lstConfig";
            this.lstConfig.Size = new System.Drawing.Size(170, 234);
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
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMessage.BackColor = System.Drawing.SystemColors.Control;
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessage.ForeColor = System.Drawing.Color.Red;
            this.txtMessage.Location = new System.Drawing.Point(55, 229);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.Size = new System.Drawing.Size(158, 26);
            this.txtMessage.TabIndex = 30;
            // 
            // frmAuto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 259);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.btnES);
            this.Controls.Add(this.groupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmAuto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自动运行时间配置";
            this.Load += new System.EventHandler(this.frmAuto_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.panT.ResumeLayout(false);
            this.panT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numT)).EndInit();
            this.panD.ResumeLayout(false);
            this.panD.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Panel panT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpT;
        private System.Windows.Forms.NumericUpDown numT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panD;
        private System.Windows.Forms.DateTimePicker dtpD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbtnD;
        private System.Windows.Forms.RadioButton rbtnT;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Button btnES;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListView lstConfig;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.TextBox txtConfig;
        private System.Windows.Forms.Label label2;
    }
}