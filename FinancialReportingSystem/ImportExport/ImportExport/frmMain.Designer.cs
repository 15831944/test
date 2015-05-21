namespace ImportExport
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstConfig = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cMenuConfig = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tMenuItemAddRun = new System.Windows.Forms.ToolStripMenuItem();
            this.tMenuItemFsh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstRun = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cMenuRun = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tMenuItemExitRun = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripOpe = new System.Windows.Forms.MenuStrip();
            this.tMenuItemExport = new System.Windows.Forms.ToolStripMenuItem();
            this.tMenuItemRun = new System.Windows.Forms.ToolStripMenuItem();
            this.tMenuItemOperateExport = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkMessage = new System.Windows.Forms.CheckBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.chkAuto = new System.Windows.Forms.CheckBox();
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnStrat = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showItme = new System.Windows.Forms.ToolStripMenuItem();
            this.autoItme = new System.Windows.Forms.ToolStripMenuItem();
            this.messageItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeItme = new System.Windows.Forms.ToolStripMenuItem();
            this.nIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.cMenuConfig.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.cMenuRun.SuspendLayout();
            this.menuStripOpe.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.cMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstConfig);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 28);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(268, 417);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "配置列表";
            // 
            // lstConfig
            // 
            this.lstConfig.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstConfig.ContextMenuStrip = this.cMenuConfig;
            this.lstConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstConfig.FullRowSelect = true;
            this.lstConfig.GridLines = true;
            this.lstConfig.Location = new System.Drawing.Point(4, 22);
            this.lstConfig.Margin = new System.Windows.Forms.Padding(4);
            this.lstConfig.Name = "lstConfig";
            this.lstConfig.Size = new System.Drawing.Size(260, 391);
            this.lstConfig.TabIndex = 0;
            this.lstConfig.UseCompatibleStateImageBehavior = false;
            this.lstConfig.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "配置名称";
            this.columnHeader1.Width = 165;
            // 
            // cMenuConfig
            // 
            this.cMenuConfig.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tMenuItemAddRun,
            this.tMenuItemFsh,
            this.toolStripSeparator2,
            this.tMenuItemDelete,
            this.toolStripSeparator3});
            this.cMenuConfig.Name = "cMenuConfig";
            this.cMenuConfig.Size = new System.Drawing.Size(169, 88);
            // 
            // tMenuItemAddRun
            // 
            this.tMenuItemAddRun.Name = "tMenuItemAddRun";
            this.tMenuItemAddRun.Size = new System.Drawing.Size(168, 24);
            this.tMenuItemAddRun.Text = "添加运行列表";
            this.tMenuItemAddRun.Click += new System.EventHandler(this.tMenuItemAddRun_Click);
            // 
            // tMenuItemFsh
            // 
            this.tMenuItemFsh.Name = "tMenuItemFsh";
            this.tMenuItemFsh.Size = new System.Drawing.Size(168, 24);
            this.tMenuItemFsh.Text = "刷新配置列表";
            this.tMenuItemFsh.Click += new System.EventHandler(this.tMenuItemFsh_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(165, 6);
            // 
            // tMenuItemDelete
            // 
            this.tMenuItemDelete.Name = "tMenuItemDelete";
            this.tMenuItemDelete.Size = new System.Drawing.Size(168, 24);
            this.tMenuItemDelete.Text = "删除配置信息";
            this.tMenuItemDelete.Click += new System.EventHandler(this.tMenuItemDelete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(165, 6);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstRun);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(268, 28);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(544, 417);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "运行列表";
            // 
            // lstRun
            // 
            this.lstRun.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lstRun.ContextMenuStrip = this.cMenuRun;
            this.lstRun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRun.FullRowSelect = true;
            this.lstRun.GridLines = true;
            this.lstRun.Location = new System.Drawing.Point(4, 22);
            this.lstRun.Margin = new System.Windows.Forms.Padding(4);
            this.lstRun.Name = "lstRun";
            this.lstRun.Size = new System.Drawing.Size(536, 391);
            this.lstRun.TabIndex = 1;
            this.lstRun.UseCompatibleStateImageBehavior = false;
            this.lstRun.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "配置名称";
            this.columnHeader5.Width = 150;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "下次运行时间";
            this.columnHeader6.Width = 127;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "上次运行结果";
            this.columnHeader7.Width = 95;
            // 
            // cMenuRun
            // 
            this.cMenuRun.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tMenuItemExitRun});
            this.cMenuRun.Name = "cMenuRun";
            this.cMenuRun.Size = new System.Drawing.Size(169, 28);
            // 
            // tMenuItemExitRun
            // 
            this.tMenuItemExitRun.Name = "tMenuItemExitRun";
            this.tMenuItemExitRun.Size = new System.Drawing.Size(168, 24);
            this.tMenuItemExitRun.Text = "退出运行列表";
            this.tMenuItemExitRun.Click += new System.EventHandler(this.tMenuItemExitRun_Click);
            // 
            // menuStripOpe
            // 
            this.menuStripOpe.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tMenuItemExport,
            this.tMenuItemRun,
            this.tMenuItemOperateExport});
            this.menuStripOpe.Location = new System.Drawing.Point(0, 0);
            this.menuStripOpe.Name = "menuStripOpe";
            this.menuStripOpe.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStripOpe.Size = new System.Drawing.Size(812, 28);
            this.menuStripOpe.TabIndex = 2;
            this.menuStripOpe.Text = "menuStrip1";
            // 
            // tMenuItemExport
            // 
            this.tMenuItemExport.Name = "tMenuItemExport";
            this.tMenuItemExport.Size = new System.Drawing.Size(81, 24);
            this.tMenuItemExport.Text = "导出配置";
            this.tMenuItemExport.Click += new System.EventHandler(this.tMenuItemExport_Click);
            // 
            // tMenuItemRun
            // 
            this.tMenuItemRun.Name = "tMenuItemRun";
            this.tMenuItemRun.Size = new System.Drawing.Size(81, 24);
            this.tMenuItemRun.Text = "时间配置";
            this.tMenuItemRun.Click += new System.EventHandler(this.tMenuItemRun_Click);
            // 
            // tMenuItemOperateExport
            // 
            this.tMenuItemOperateExport.Name = "tMenuItemOperateExport";
            this.tMenuItemOperateExport.Size = new System.Drawing.Size(81, 24);
            this.tMenuItemOperateExport.Text = "手动导出";
            this.tMenuItemOperateExport.Click += new System.EventHandler(this.tMenuItemOperateExport_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkMessage);
            this.groupBox3.Controls.Add(this.txtMessage);
            this.groupBox3.Controls.Add(this.chkAuto);
            this.groupBox3.Controls.Add(this.btnEnd);
            this.groupBox3.Controls.Add(this.btnStrat);
            this.groupBox3.Controls.Add(this.lblMessage);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 445);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(812, 85);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "运行操作";
            // 
            // chkMessage
            // 
            this.chkMessage.AutoSize = true;
            this.chkMessage.Location = new System.Drawing.Point(573, 56);
            this.chkMessage.Margin = new System.Windows.Forms.Padding(4);
            this.chkMessage.Name = "chkMessage";
            this.chkMessage.Size = new System.Drawing.Size(89, 19);
            this.chkMessage.TabIndex = 27;
            this.chkMessage.Text = "关闭提示";
            this.chkMessage.UseVisualStyleBackColor = true;
            this.chkMessage.CheckedChanged += new System.EventHandler(this.chkMessage_CheckedChanged);
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.SystemColors.Control;
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessage.ForeColor = System.Drawing.Color.Red;
            this.txtMessage.Location = new System.Drawing.Point(76, 26);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(4);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.Size = new System.Drawing.Size(481, 50);
            this.txtMessage.TabIndex = 26;
            // 
            // chkAuto
            // 
            this.chkAuto.AutoSize = true;
            this.chkAuto.Location = new System.Drawing.Point(676, 56);
            this.chkAuto.Margin = new System.Windows.Forms.Padding(4);
            this.chkAuto.Name = "chkAuto";
            this.chkAuto.Size = new System.Drawing.Size(119, 19);
            this.chkAuto.TabIndex = 25;
            this.chkAuto.Text = "开机自动运行";
            this.chkAuto.UseVisualStyleBackColor = true;
            this.chkAuto.CheckedChanged += new System.EventHandler(this.chkAuto_CheckedChanged);
            // 
            // btnEnd
            // 
            this.btnEnd.Location = new System.Drawing.Point(696, 20);
            this.btnEnd.Margin = new System.Windows.Forms.Padding(4);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(100, 29);
            this.btnEnd.TabIndex = 2;
            this.btnEnd.Text = "停 止";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnStrat
            // 
            this.btnStrat.Location = new System.Drawing.Point(588, 20);
            this.btnStrat.Margin = new System.Windows.Forms.Padding(4);
            this.btnStrat.Name = "btnStrat";
            this.btnStrat.Size = new System.Drawing.Size(100, 29);
            this.btnStrat.TabIndex = 1;
            this.btnStrat.Text = "开 始";
            this.btnStrat.UseVisualStyleBackColor = true;
            this.btnStrat.Click += new System.EventHandler(this.btnStrat_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(16, 26);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(52, 15);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "提示：";
            // 
            // cMenu
            // 
            this.cMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showItme,
            this.autoItme,
            this.messageItem,
            this.toolStripSeparator1,
            this.closeItme});
            this.cMenu.Name = "cMenu";
            this.cMenu.Size = new System.Drawing.Size(169, 106);
            // 
            // showItme
            // 
            this.showItme.Name = "showItme";
            this.showItme.Size = new System.Drawing.Size(168, 24);
            this.showItme.Text = "显示";
            this.showItme.Click += new System.EventHandler(this.showItme_Click);
            // 
            // autoItme
            // 
            this.autoItme.Name = "autoItme";
            this.autoItme.Size = new System.Drawing.Size(168, 24);
            this.autoItme.Text = "开机自动运行";
            this.autoItme.Click += new System.EventHandler(this.autoItme_Click);
            // 
            // messageItem
            // 
            this.messageItem.Name = "messageItem";
            this.messageItem.Size = new System.Drawing.Size(168, 24);
            this.messageItem.Text = "关闭提示";
            this.messageItem.Click += new System.EventHandler(this.messageItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(165, 6);
            // 
            // closeItme
            // 
            this.closeItme.Name = "closeItme";
            this.closeItme.Size = new System.Drawing.Size(168, 24);
            this.closeItme.Text = "退出";
            this.closeItme.Click += new System.EventHandler(this.closeItme_Click);
            // 
            // nIcon
            // 
            this.nIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.nIcon.ContextMenuStrip = this.cMenu;
            this.nIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("nIcon.Icon")));
            this.nIcon.Text = "自动导出程序";
            this.nIcon.Visible = true;
            this.nIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.nIcon_MouseDoubleClick);
            // 
            // timer
            // 
            this.timer.Interval = 120000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 530);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.menuStripOpe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripOpe;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自动导出程序";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.VisibleChanged += new System.EventHandler(this.frmMain_VisibleChanged);
            this.groupBox1.ResumeLayout(false);
            this.cMenuConfig.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.cMenuRun.ResumeLayout(false);
            this.menuStripOpe.ResumeLayout(false);
            this.menuStripOpe.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.cMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lstConfig;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.MenuStrip menuStripOpe;
        private System.Windows.Forms.ToolStripMenuItem tMenuItemExport;
        private System.Windows.Forms.ToolStripMenuItem tMenuItemRun;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Button btnStrat;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.CheckBox chkAuto;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem showItme;
        private System.Windows.Forms.ToolStripMenuItem autoItme;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem closeItme;
        private System.Windows.Forms.NotifyIcon nIcon;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ContextMenuStrip cMenuRun;
        private System.Windows.Forms.ToolStripMenuItem tMenuItemExitRun;
        private System.Windows.Forms.ContextMenuStrip cMenuConfig;
        private System.Windows.Forms.ToolStripMenuItem tMenuItemAddRun;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tMenuItemDelete;
        private System.Windows.Forms.CheckBox chkMessage;
        private System.Windows.Forms.ToolStripMenuItem messageItem;
        private System.Windows.Forms.ToolStripMenuItem tMenuItemFsh;
        private System.Windows.Forms.ListView lstRun;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tMenuItemOperateExport;
    }
}