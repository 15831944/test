using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ImportExport.PublicMethod;
using Microsoft.Win32;
using ImportExport.Entity;
using System.Collections;
using System.Threading;

namespace ImportExport
{
    public partial class frmMain : Form
    {

        private string title = "导出程序";
        private string message = "自动导出程序";
        private int timeOut = 3000;
        private bool auto = true;
        private bool flage = false;
        private frmExportXmlUse eeu = new frmExportXmlUse();

        public frmMain()
        {
            InitializeComponent();
            ////判断程序是否已经设置成开机自动启动，在form_load中写入
            //RegistryKey loca_chek = Registry.LocalMachine;
            //RegistryKey run_Check = loca_chek.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
            //if (run_Check.GetValue(Application.ProductName) == null || run_Check.GetValue(Application.ProductName).ToString().ToLower() == "false")
            //{//分别对应上面的WinForm和false
            //    this.chkAuto.Checked = false;
            //    this.autoItme.Checked = false;
            //}
            //else
            //{
            //    this.auto = false;
            //    this.chkAuto.Checked = true;
            //    this.autoItme.Checked = true;
            //}
        }

        private void showMessage(string message)
        {
            if (!this.chkMessage.Checked)
                this.nIcon.ShowBalloonTip(this.timeOut, this.title, message, ToolTipIcon.Info);
            this.txtMessage.Text = message;
            LogManager.Instance.Out(message);
        }

        /// <summary>
        /// 开机自动运行
        /// </summary>
        private void AutoRun()
        {
            //获取程序执行路径..
            string starupPath = Application.ExecutablePath;
            RegistryKey loca = Registry.LocalMachine;
            RegistryKey run = loca.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");

            try
            {
                //SetValue:存储值的名称
                if (!this.chkAuto.Checked)
                    run.DeleteValue(Application.ProductName);//取消开机运行
                else
                    run.SetValue(Application.ProductName, starupPath);//设置开机运行
                loca.Close();
            }
            catch (Exception ex)
            {
                this.showMessage(ex.Message);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {//加载窗体事件
            LoadData.Instance.loadConfigXml();
            this.lstConfig.Items.AddRange(LoadData.Instance.loadXmlAddListView());
            this.lstRun.Items.AddRange(LoadData.Instance.loadRunListView());
            if (this.lstRun.Items.Count > 0)
            {
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                this.Visible = false;
                this.timer.Enabled = true;
                this.btnStrat.Enabled = false;
                this.btnEnd.Enabled = true;
                this.showMessage(message + "启动运行！");
            }
            else
            {
                this.btnStrat.Enabled = true;
                this.btnEnd.Enabled = false;
                this.showMessage(message + "等待运行！");
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {//关闭窗体事件
            this.showMessage(e.CloseReason.ToString());
            if (flage)
            {
                if (this.lstConfig.Items.Count > 0)
                {
                    foreach (ListViewItem item in this.lstConfig.Items)
                        ((ConfigXml)item.Tag).saveXmlByConfig();
                }
            }
            else
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    e.Cancel = true;
                    this.Visible = false;
                    this.showItme.Text = "显示";
                }
                else
                {
                    if (this.lstConfig.Items.Count > 0)
                    {
                        foreach (ListViewItem item in this.lstConfig.Items)
                            ((ConfigXml)item.Tag).saveXmlByConfig();
                    }
                }
            }
        }

        private void frmMain_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible)
            {
                this.showMessage("窗体最小化，托盘程序");
            }
        }

        #region 配置设置

        private void tMenuItemExport_Click(object sender, EventArgs e)
        {//导出配置
            frmExportXml frmXml = new frmExportXml();
            frmXml.ShowDialog();
        }

        private void tMenuItemRun_Click(object sender, EventArgs e)
        {//时间配置
            frmAuto frmA = new frmAuto();
            frmA.ShowDialog();
            if (MessageBox.Show("新的时间配置重新启动生效！", "提示：", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (this.lstConfig.Items.Count > 0)
                {
                    foreach (ListViewItem item in this.lstConfig.Items)
                        ((ConfigXml)item.Tag).saveXmlByConfig();
                }
                this.lstConfig.Items.Clear();
                this.lstRun.Items.Clear();
                this.frmMain_Load(sender, e);
            }
            this.showMessage("新的时间配置重新启动生效！");
        }

        #endregion 

        #region 控制导出

        private void chkAuto_CheckedChanged(object sender, EventArgs e)
        {//开机自动运行
            //CB_Auto是一个Checkbox，IsAutoRun 是个布尔变量，用于控制是否开机运行
            try
            {
                if (this.auto)
                    AutoRun();
                else
                    this.auto = true;
                this.autoItme.Checked = this.chkAuto.Checked;
            }
            catch (Exception ex)
            {
                this.showMessage(ex.Message);
            }
        }

        private void btnStrat_Click(object sender, EventArgs e)
        {//开始
            this.timer.Enabled = true;
            this.btnStrat.Enabled = false;
            this.btnEnd.Enabled = true;
            this.showMessage(message + "启动运行！");
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {//停止
            this.timer.Enabled = false;
            this.btnEnd.Enabled = false;
            this.btnStrat.Enabled = true;
            this.showMessage(message + "停止运行！");
        }

     
        private void timer_Tick(object sender, EventArgs e)
        {//自动导出
            if (this.lstRun.Items.Count > 0)
            {
                ConfigXml configXml = null;
                foreach (ListViewItem item in this.lstRun.Items)
                {
                    configXml = (ConfigXml)item.Tag;
                    if (configXml.NextRunTime.CompareTo(DateTime.Now) < 0)
                    {
                        this.showMessage(configXml.getXmlValueById("name") + " 导出数据开始！");
                        try
                        {
                            this.eeu.autoRunExportXml(configXml);
                          
                            configXml.aountNextRunTime();
                            configXml.PreviousRunInt = 0;
                            item.SubItems[1].Text = configXml.NextRunTime.ToShortDateString() + " " + configXml.NextRunTime.ToLongTimeString();
                            item.SubItems[2].Text = configXml.getPreviousRunInt();
                            this.showMessage(configXml.getXmlValueById("name") + " 获取数据成功！");

                            Thread.Sleep(60000);
                            string filsPath = configXml.getXmlValueById("path") + "\\";

                            //CsvAnalytical xa = new CsvAnalytical();
                            //xa.ParseCsv(filsPath);

                            this.showMessage("导入数据成功！");

                        }
                        catch (Exception ex)
                        {
                            configXml.PreviousRunInt = 1;
                            item.SubItems[2].Text = configXml.getPreviousRunInt();
                            this.showMessage(configXml.getXmlValueById("name") + " 导出数据失败！\r\n" + ex.Message);
                        }


                    }
                }
            }
            else
            {
                this.btnEnd_Click(sender, e);
            }
        }

        #endregion 

        #region 操作列表信息

        private void tMenuItemAddRun_Click(object sender, EventArgs e)
        {//添加运行列表
            if (this.lstConfig.SelectedItems.Count > 0)
            {
                string names = "配置";
                ConfigXml configXml = null;
                foreach (ListViewItem item in this.lstConfig.SelectedItems)
                {
                    configXml = (ConfigXml)item.Tag;
                    if (configXml.getXmlValueById("application") != EnumClass.Application.strat.ToString())
                    {
                        configXml.setXmlValueById("application", EnumClass.Application.strat.ToString());
                        this.lstRun.Items.Add(configXml.listViewItemRunConfigXml());
                        names += "\r\n" + configXml.getXmlValueById("name");
                    }
                }
                this.showMessage(names + "\r\n加入运行列表");
            }
        }
        private void tMenuItemFsh_Click(object sender, EventArgs e)
        {//刷新配置列表
            this.lstConfig.Items.Clear();
            this.lstConfig.Items.AddRange(LoadData.Instance.loadXmlAddListView());
        }

        private void tMenuItemDelete_Click(object sender, EventArgs e)
        {//删除配置列表
            if (this.lstConfig.SelectedItems.Count > 0)
            {
                string names = "配置";
                ConfigXml configXml = null;
                foreach (ListViewItem item in this.lstConfig.SelectedItems)
                {
                    configXml = (ConfigXml)item.Tag;
                    if (configXml.getXmlValueById("application") == EnumClass.Application.strat.ToString())
                    {
                        names += "\r\n" + configXml.getXmlValueById("name");
                        this.showMessage(names + "\r\n在运行列表中不得删除");
                        return;
                    }
                }
                foreach (ListViewItem item in this.lstConfig.SelectedItems)
                {
                    configXml = (ConfigXml)item.Tag;
                    configXml.deleteXmlByConfig();
                    names += "\r\n" + configXml.getXmlValueById("name");
                    item.Remove();
                    LoadData.Instance.ConfigXmlList.Remove(configXml);
                }

                this.showMessage(names + "\r\n成功删除");
            }
        }

        private void tMenuItemExitRun_Click(object sender, EventArgs e)
        {//退出运行列表
            if (this.lstRun.SelectedItems.Count > 0)
            {
                string names = "配置";
                ConfigXml configXml = null;
                foreach (ListViewItem item in this.lstRun.SelectedItems)
                {
                    configXml = (ConfigXml)item.Tag;
                    configXml.setXmlValueById("application", EnumClass.Application.end.ToString());
                    item.Remove();
                    names += "\r\n" + configXml.getXmlValueById("name");
                }
                this.showMessage(names + "\r\n退出运行列表");
            }
        }

        private void tMenuItemExItem_Click(object sender, EventArgs e)
        {//手动导出配置项
            if (this.lstConfig.SelectedItems.Count > 0)
            {
                ConfigXml configXml = null;
                foreach (ListViewItem listItem in this.lstConfig.SelectedItems)
                {
                    configXml = (ConfigXml)listItem.Tag;
                    this.showMessage(configXml.getXmlValueById("name") + " 导出数据开始！");
                    try
                    {
                        this.eeu.runExportXml(configXml);
                        this.showMessage(configXml.getXmlValueById("name") + " 导出数据成功！");
                    }
                    catch (Exception ex)
                    {
                        this.showMessage(configXml.getXmlValueById("name") + " 导出数据失败！\r\n" + ex.Message);
                    }
                }
            }
        }

        private void tMenuItemOperateExport_Click(object sender, EventArgs e)
        {//手动导出
            frmOperateExportXml frmOperateXml = new frmOperateExportXml();
            frmOperateXml.ShowDialog();
        }

        #endregion 

        #region 隐藏显示

        private void nIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {//自动导出程序
            this.showItme_Click(sender, e);
        }

        private void chkMessage_CheckedChanged(object sender, EventArgs e)
        {//关闭提示
            this.messageItem.Checked = this.chkMessage.Checked;
        }


        private void showItme_Click(object sender, EventArgs e)
        {//显示
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = true;
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
                this.showItme.Text = "隐藏";
                return;
            }
            if (this.Visible)
            {
                this.Visible = false;
                this.showItme.Text = "显示";
            }
            else
            {
                this.Visible = true;
                this.showItme.Text = "隐藏";
            }
        }

        private void closeItme_Click(object sender, EventArgs e)
        {//退出
            //Application.Exit();
            this.flage = true;
            this.Close();
        }

        private void autoItme_Click(object sender, EventArgs e)
        {//开机自动运行
            this.chkAuto.Checked = !((ToolStripMenuItem)sender).Checked;
        }

        private void messageItem_Click(object sender, EventArgs e)
        {//关闭提示
            this.chkMessage.Checked = !this.chkMessage.Checked;
        }


        #endregion 
    }
}