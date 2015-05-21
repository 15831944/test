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

        private string title = "��������";
        private string message = "�Զ���������";
        private int timeOut = 3000;
        private bool auto = true;
        private bool flage = false;
        private frmExportXmlUse eeu = new frmExportXmlUse();

        public frmMain()
        {
            InitializeComponent();
            ////�жϳ����Ƿ��Ѿ����óɿ����Զ���������form_load��д��
            //RegistryKey loca_chek = Registry.LocalMachine;
            //RegistryKey run_Check = loca_chek.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
            //if (run_Check.GetValue(Application.ProductName) == null || run_Check.GetValue(Application.ProductName).ToString().ToLower() == "false")
            //{//�ֱ��Ӧ�����WinForm��false
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
        /// �����Զ�����
        /// </summary>
        private void AutoRun()
        {
            //��ȡ����ִ��·��..
            string starupPath = Application.ExecutablePath;
            RegistryKey loca = Registry.LocalMachine;
            RegistryKey run = loca.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");

            try
            {
                //SetValue:�洢ֵ������
                if (!this.chkAuto.Checked)
                    run.DeleteValue(Application.ProductName);//ȡ����������
                else
                    run.SetValue(Application.ProductName, starupPath);//���ÿ�������
                loca.Close();
            }
            catch (Exception ex)
            {
                this.showMessage(ex.Message);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {//���ش����¼�
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
                this.showMessage(message + "�������У�");
            }
            else
            {
                this.btnStrat.Enabled = true;
                this.btnEnd.Enabled = false;
                this.showMessage(message + "�ȴ����У�");
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {//�رմ����¼�
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
                    this.showItme.Text = "��ʾ";
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
                this.showMessage("������С�������̳���");
            }
        }

        #region ��������

        private void tMenuItemExport_Click(object sender, EventArgs e)
        {//��������
            frmExportXml frmXml = new frmExportXml();
            frmXml.ShowDialog();
        }

        private void tMenuItemRun_Click(object sender, EventArgs e)
        {//ʱ������
            frmAuto frmA = new frmAuto();
            frmA.ShowDialog();
            if (MessageBox.Show("�µ�ʱ����������������Ч��", "��ʾ��", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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
            this.showMessage("�µ�ʱ����������������Ч��");
        }

        #endregion 

        #region ���Ƶ���

        private void chkAuto_CheckedChanged(object sender, EventArgs e)
        {//�����Զ�����
            //CB_Auto��һ��Checkbox��IsAutoRun �Ǹ��������������ڿ����Ƿ񿪻�����
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
        {//��ʼ
            this.timer.Enabled = true;
            this.btnStrat.Enabled = false;
            this.btnEnd.Enabled = true;
            this.showMessage(message + "�������У�");
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {//ֹͣ
            this.timer.Enabled = false;
            this.btnEnd.Enabled = false;
            this.btnStrat.Enabled = true;
            this.showMessage(message + "ֹͣ���У�");
        }

     
        private void timer_Tick(object sender, EventArgs e)
        {//�Զ�����
            if (this.lstRun.Items.Count > 0)
            {
                ConfigXml configXml = null;
                foreach (ListViewItem item in this.lstRun.Items)
                {
                    configXml = (ConfigXml)item.Tag;
                    if (configXml.NextRunTime.CompareTo(DateTime.Now) < 0)
                    {
                        this.showMessage(configXml.getXmlValueById("name") + " �������ݿ�ʼ��");
                        try
                        {
                            this.eeu.autoRunExportXml(configXml);
                          
                            configXml.aountNextRunTime();
                            configXml.PreviousRunInt = 0;
                            item.SubItems[1].Text = configXml.NextRunTime.ToShortDateString() + " " + configXml.NextRunTime.ToLongTimeString();
                            item.SubItems[2].Text = configXml.getPreviousRunInt();
                            this.showMessage(configXml.getXmlValueById("name") + " ��ȡ���ݳɹ���");

                            Thread.Sleep(60000);
                            string filsPath = configXml.getXmlValueById("path") + "\\";

                            //CsvAnalytical xa = new CsvAnalytical();
                            //xa.ParseCsv(filsPath);

                            this.showMessage("�������ݳɹ���");

                        }
                        catch (Exception ex)
                        {
                            configXml.PreviousRunInt = 1;
                            item.SubItems[2].Text = configXml.getPreviousRunInt();
                            this.showMessage(configXml.getXmlValueById("name") + " ��������ʧ�ܣ�\r\n" + ex.Message);
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

        #region �����б���Ϣ

        private void tMenuItemAddRun_Click(object sender, EventArgs e)
        {//��������б�
            if (this.lstConfig.SelectedItems.Count > 0)
            {
                string names = "����";
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
                this.showMessage(names + "\r\n���������б�");
            }
        }
        private void tMenuItemFsh_Click(object sender, EventArgs e)
        {//ˢ�������б�
            this.lstConfig.Items.Clear();
            this.lstConfig.Items.AddRange(LoadData.Instance.loadXmlAddListView());
        }

        private void tMenuItemDelete_Click(object sender, EventArgs e)
        {//ɾ�������б�
            if (this.lstConfig.SelectedItems.Count > 0)
            {
                string names = "����";
                ConfigXml configXml = null;
                foreach (ListViewItem item in this.lstConfig.SelectedItems)
                {
                    configXml = (ConfigXml)item.Tag;
                    if (configXml.getXmlValueById("application") == EnumClass.Application.strat.ToString())
                    {
                        names += "\r\n" + configXml.getXmlValueById("name");
                        this.showMessage(names + "\r\n�������б��в���ɾ��");
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

                this.showMessage(names + "\r\n�ɹ�ɾ��");
            }
        }

        private void tMenuItemExitRun_Click(object sender, EventArgs e)
        {//�˳������б�
            if (this.lstRun.SelectedItems.Count > 0)
            {
                string names = "����";
                ConfigXml configXml = null;
                foreach (ListViewItem item in this.lstRun.SelectedItems)
                {
                    configXml = (ConfigXml)item.Tag;
                    configXml.setXmlValueById("application", EnumClass.Application.end.ToString());
                    item.Remove();
                    names += "\r\n" + configXml.getXmlValueById("name");
                }
                this.showMessage(names + "\r\n�˳������б�");
            }
        }

        private void tMenuItemExItem_Click(object sender, EventArgs e)
        {//�ֶ�����������
            if (this.lstConfig.SelectedItems.Count > 0)
            {
                ConfigXml configXml = null;
                foreach (ListViewItem listItem in this.lstConfig.SelectedItems)
                {
                    configXml = (ConfigXml)listItem.Tag;
                    this.showMessage(configXml.getXmlValueById("name") + " �������ݿ�ʼ��");
                    try
                    {
                        this.eeu.runExportXml(configXml);
                        this.showMessage(configXml.getXmlValueById("name") + " �������ݳɹ���");
                    }
                    catch (Exception ex)
                    {
                        this.showMessage(configXml.getXmlValueById("name") + " ��������ʧ�ܣ�\r\n" + ex.Message);
                    }
                }
            }
        }

        private void tMenuItemOperateExport_Click(object sender, EventArgs e)
        {//�ֶ�����
            frmOperateExportXml frmOperateXml = new frmOperateExportXml();
            frmOperateXml.ShowDialog();
        }

        #endregion 

        #region ������ʾ

        private void nIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {//�Զ���������
            this.showItme_Click(sender, e);
        }

        private void chkMessage_CheckedChanged(object sender, EventArgs e)
        {//�ر���ʾ
            this.messageItem.Checked = this.chkMessage.Checked;
        }


        private void showItme_Click(object sender, EventArgs e)
        {//��ʾ
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = true;
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
                this.showItme.Text = "����";
                return;
            }
            if (this.Visible)
            {
                this.Visible = false;
                this.showItme.Text = "��ʾ";
            }
            else
            {
                this.Visible = true;
                this.showItme.Text = "����";
            }
        }

        private void closeItme_Click(object sender, EventArgs e)
        {//�˳�
            //Application.Exit();
            this.flage = true;
            this.Close();
        }

        private void autoItme_Click(object sender, EventArgs e)
        {//�����Զ�����
            this.chkAuto.Checked = !((ToolStripMenuItem)sender).Checked;
        }

        private void messageItem_Click(object sender, EventArgs e)
        {//�ر���ʾ
            this.chkMessage.Checked = !this.chkMessage.Checked;
        }


        #endregion 
    }
}