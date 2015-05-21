using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImportExport
{
    public delegate void UserMethod();
    public partial class frmLoading : Form
    {
        private BackgroundWorker bw = null;
        public UserMethod method;
        private string message = string.Empty;
        public string Message
        {
            get { return this.message; }
        }

        private Exception mye = null;
        public Exception Exception
        {
            get { return this.mye; }
        }

        public frmLoading(UserMethod me)
        {
            InitializeComponent();
            this.method = me;
        }
        public void start()
        {//��̨�߳�
            bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);

            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw.RunWorkerAsync();
        }
        void bw_DoWork(object sender, DoWorkEventArgs e)
        {//ִ�к�̨�̷߳���
            try
            {
                if (bw.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                if (method != null)
                    method();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                this.mye = ex;
            }
        }
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {//��̨�߳�ִ�����
            this.Close();
        }
        public void setMessage(string message)
        {
            this.label1.Text = "����"+message+",���Ժ�......";
        }

        private void frmLoading_KeyDown(object sender, KeyEventArgs e)
        {
            frmOperateExportXml.CancellationBackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            if (bw.IsBusy)
            {
                bw.CancelAsync();
            }
            this.Close();
            System.GC.Collect();
        }

        private void frmLoading_MouseClick(object sender, MouseEventArgs e)
        {
            frmOperateExportXml.CancellationBackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            if (bw.IsBusy)
            {
                bw.CancelAsync();
            }
            this.Close();
            System.GC.Collect();
        }
    }

}