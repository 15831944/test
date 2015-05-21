using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ImportExport.PublicMethod;
using System.Collections;
using ImportExport.Entity;

namespace ImportExport
{
    public partial class frmAuto : Form
    {
        private ConfigXml configXml = null;
        

        public frmAuto()
        {
            InitializeComponent();
        }

        private void showMessage(string message)
        {
            this.txtMessage.Text = message;
            LogManager.Instance.Out(message);
        }

        private void frmAuto_Load(object sender, EventArgs e)
        {
            this.lstConfig.Items.AddRange(LoadData.Instance.loadXmlAddListView());
            this.btnES.Enabled = false;
            this.groupBox.Enabled = false;
        }

        private void btnES_Click(object sender, EventArgs e)
        {//设置时间
            if (this.rbtnD.Checked)
                this.configXml.setXmlValueById("cycle", EnumClass.Cycle.day.ToString());
            else if (this.rbtnT.Checked)
                this.configXml.setXmlValueById("cycle", EnumClass.Cycle.time.ToString());
            this.configXml.aountRunTime();

            this.configXml.setXmlValueById("day", this.dtpD.Value.ToLongTimeString());
            this.configXml.setXmlValueById("time", this.dtpT.Value.ToLongTimeString());
            this.configXml.setXmlValueById("hour", this.numT.Value.ToString());
            this.configXml.saveXmlByConfig();
            this.showMessage(this.configXml.getXmlValueById("name") + " 保存时间配置成功！");
        }

        private void lstConfig_Click(object sender, EventArgs e)
        {//选择配置文件
            if (this.lstConfig.SelectedItems.Count > 0)
            {
                this.groupBox.Enabled = true;
                this.configXml = (ConfigXml)this.lstConfig.SelectedItems[0].Tag;
                this.txtConfig.Text = this.configXml.getXmlValueById("name");
               
                if (this.configXml.getXmlValueById("cycle") == EnumClass.Cycle.day.ToString())
                {
                    this.rbtnD.Checked = true;
                    DateTime dt = DateTime.Now;
                    if (DateTime.TryParse(this.configXml.getXmlValueById("day"), out dt))
                        this.dtpD.Value = dt;
                    else
                        this.dtpD.Value = DateTime.Now;
                }
                else if (this.configXml.getXmlValueById("cycle") == EnumClass.Cycle.time.ToString())
                {
                    this.rbtnT.Checked = true;
                    DateTime dt = DateTime.Now;
                    if (DateTime.TryParse(this.configXml.getXmlValueById("time"), out dt))
                        this.dtpT.Value = dt;
                    else
                        this.dtpT.Value = DateTime.Now;
                    int num = 0;
                    if (int.TryParse(this.configXml.getXmlValueById("hour"), out num))
                        this.numT.Value = num;
                    else
                        this.numT.Value = 1;
                }
               
                this.btnES.Enabled = true;
            }
        }

        private void rbtn_CheckedChanged(object sender, EventArgs e)
        {//选择单选按钮
            if (!((RadioButton)sender).Checked)
                return;
            this.panD.Enabled = false;
            this.panT.Enabled = false;

            if (this.rbtnD.Checked)
            {
                this.panD.Enabled = true;
            }
            else
            {
                this.panT.Enabled = true;
            }
        }

        private bool closeProc(string ProcName)
        {//关闭进程
            bool result = false;
            ArrayList procList = new ArrayList();
            string tempName = "";
            int begpos;
            int endpos;
            foreach (System.Diagnostics.Process thisProc in System.Diagnostics.Process.GetProcesses())
            {
                tempName = thisProc.ToString();
                begpos = tempName.IndexOf("(") + 1;
                endpos = tempName.IndexOf(")");
                tempName = tempName.Substring(begpos, endpos - begpos);
                procList.Add(tempName);
                if (tempName.ToLower() == ProcName.ToLower())
                {
                    if (!thisProc.CloseMainWindow())
                        thisProc.Kill();         //当发送关闭窗口命令无效时强行结束进程
                    result = true;
                }
            }
            return result;
        }
    }
}