using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ImportExport.PublicMethod;
using System.Data.OleDb;
using System.IO;
using ImportExport.Entity;

namespace ImportExport
{
    public partial class frmExportXml : Form
    {
        private frmExportXmlUse feeu = null;
        private bool flage = true;
        private bool newSave = true;

        public frmExportXml()
        {
            InitializeComponent();
            this.feeu = new frmExportXmlUse();
        }

        private void frmExportExcel_Load(object sender, EventArgs e)
        {//加载窗体事件
            try
            {
               
                this.btnSave.Enabled = false;
                this.setControlEnabled(false);
                this.lstConfig.Items.AddRange(LoadData.Instance.loadXmlAddListView());
            }
            catch (Exception ex)
            {
                this.showMessage(ex.Message);
            }
        }


        private void setControlEnabled(bool _bool)
        {
            this.txtPt.Enabled = _bool;
            this.txtDc.Enabled = _bool;
            this.txtC.Enabled = _bool;
            this.txtO.Enabled = _bool;
            this.txtOc.Enabled = _bool;
            this.txtPi.Enabled = _bool;
            this.txtPt.Enabled = _bool;
           
            this.txtFilePath.Enabled = _bool;
            this.btnPath.Enabled = _bool;
            this.txtFileName.Enabled = _bool;
      
        }

        private void setEditControl()
        {
            this.btnSave.Enabled = true;
            this.setControlEnabled(true);
            this.flage = true;
        }

        private void setControlByXml()
        {

            this.txtPt.Text = this.feeu.ConfigXml.getXmlValueById("pt");
            this.txtDc.Text = this.feeu.ConfigXml.getXmlValueById("dc");

            this.txtO.Text = this.feeu.ConfigXml.getXmlValueById("o");
            this.txtOc.Text = this.feeu.ConfigXml.getXmlValueById("oc");
            this.txtC.Text = this.feeu.ConfigXml.getXmlValueById("ci");
            this.txtPi.Text = this.feeu.ConfigXml.getXmlValueById("pi");
            this.txtFilePath.Text = this.feeu.ConfigXml.getXmlValueById("path");
            int num = 0;
            int.TryParse(this.feeu.ConfigXml.getXmlValueById("type"), out num);
            this.feeu.TypeNum = num;

            this.txtFileName.Text = this.feeu.ConfigXml.getXmlValueById("file");
          
        }

        private void setXmlValue()
        {
           
            this.feeu.ConfigXml.setXmlValueById("pt", this.txtPt.Text.Trim());
            this.feeu.ConfigXml.setXmlValueById("dc", this.txtDc.Text.Trim());

            this.feeu.ConfigXml.setXmlValueById("o", this.txtO.Text.Trim());
            this.feeu.ConfigXml.setXmlValueById("oc", this.txtOc.Text.Trim());

            this.feeu.ConfigXml.setXmlValueById("ci", this.txtC.Text.Trim());
            this.feeu.ConfigXml.setXmlValueById("pi", this.txtPi.Text.Trim());

            if (this.txtFilePath.Text.Trim().EndsWith("\\"))
                this.txtFilePath.Text = this.txtFilePath.Text.Trim().Substring(0, this.txtFilePath.Text.Trim().Length - 1);
            if (this.txtFilePath.Text.Trim().EndsWith("/"))
                this.txtFilePath.Text = this.txtFilePath.Text.Trim().Substring(0, this.txtFilePath.Text.Trim().Length - 1);
            this.feeu.ConfigXml.setXmlValueById("path", this.txtFilePath.Text.Trim());
            this.feeu.ConfigXml.setXmlValueById("file", this.txtFileName.Text.Trim());
  
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "选择Xml文件保存路径";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                this.txtFilePath.Text = fbd.SelectedPath;
            }
        }
     
        #region 操作配置文件

        //private void tMenuItemNew_Click(object sender, EventArgs e)
        //{//新建配置
        //    this.feeu.newXml();
        //    this.setEditControl();
        //    this.setControlByXml();
        //    this.newSave = true;
        //}

        private void btnSave_Click(object sender, EventArgs e)
        {//保存配置
            this.setXmlValue();
            this.feeu.saveXml();
            this.showMessage("配置文件保存成功！");
        }


        private void lstConfig_Click(object sender, EventArgs e)
        {//选择配置文件
            if (this.lstConfig.SelectedItems.Count > 0)
            {
                this.feeu.ConfigXml = (ConfigXml)this.lstConfig.SelectedItems[0].Tag;
                this.setEditControl();
                this.setControlByXml();
                this.newSave = false;
                this.showMessage(string.Empty);
            }
        }

        #endregion 

        #region 显示消息

        private void showMessage(string message)
        {
            this.txtMessage.Text = message;
            LogManager.Instance.Out(message);
        }

        #endregion 
    }
}