using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Tamir.SharpSsh;

namespace ImportExport
{
    public class SFTPHelper
    {
        private SshTransferProtocolBase m_sshCp;
        private SFTPHelper()
        {

        }
        public SFTPHelper(SshConnectionInfo connectionInfo)
        {
            m_sshCp = new Sftp(connectionInfo.Host, connectionInfo.User);

            if (connectionInfo.Pass != null)
            {
                m_sshCp.Password = connectionInfo.Pass;
            }

            if (connectionInfo.IdentityFile != null)
            {
                m_sshCp.AddIdentityFile(connectionInfo.IdentityFile);
            }
        }

        public bool Connected
        {
            get
            {
                return m_sshCp.Connected;
            }
        }
        public void Connect()
        {
            if (!m_sshCp.Connected)
            {
                m_sshCp.Connect();
            }
        }
        public void Close()
        {
            if (m_sshCp.Connected)
            {
                m_sshCp.Close();
            }
        }
        public bool Upload(string localPath, string remotePath)
        {
            try
            {
                if (!m_sshCp.Connected)
                {
                    m_sshCp.Connect();
                }
                m_sshCp.Put(localPath, remotePath);

                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool Download(string remotePath, string localPath)
        {
            try
            {
                if (!m_sshCp.Connected)
                {
                    m_sshCp.Connect();
                }

                m_sshCp.Get(remotePath, localPath);

                return true;
            }
            catch
            {
                return false;
            }
        }


        public ArrayList GetFileList(string path)
        {
            try
            {
                if (!m_sshCp.Connected)
                {
                    m_sshCp.Connect();
                }
                return ((Sftp)m_sshCp).GetFileList(path);
            }
            catch
            {
                return null;
            }
        }
    }

    public class SshConnectionInfo
    {
        public string IdentityFile { get; set; }
        public string Pass { get; set; }
        public string Host { get; set; }
        public string User { get; set; }
    }
}
