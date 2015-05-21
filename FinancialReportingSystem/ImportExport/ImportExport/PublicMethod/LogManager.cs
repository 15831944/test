using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Runtime.InteropServices;

namespace ImportExport.PublicMethod
{
    /// <summary>
    /// 日志记录类,可以输出到一个固定窗口上或输出到文件中
    /// </summary>
    public class LogManager
    {
        private LogManager()
        {
        }
        private const int EM_SETSEL = 0x00B1;
        private const int EM_REPLACESEL = 0x00C2;


        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern int FindWindow(string className, string windowName);


        [DllImport("User32.dll", EntryPoint = "FindWindowEx")]
        private static extern int FindWindowEx(int hwndParent, int hwndChildAfter, string lpszClass, string lpszWindow);


        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(int hWnd, int Msg, int wParam, int lParam);


        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(int hWnd, int Msg, int wParam, string lParam);

        /// <summary>
        /// 输出信息
        /// </summary>
        /// <param name="msg"></param>
        public void Out(string msg)
        {
            int h = FindWindow("Notepad", "LW.txt - 记事本");
            h = FindWindowEx(h,0,"Edit",null);
            if(h > 0)
            {
                msg += "\r\n";
                SendMessage(h,EM_SETSEL,-1,-1);
                SendMessage(h,EM_REPLACESEL,-1,msg);
            }
        }

        private static string @lock = "lw";
        private static LogManager _logmanager = null;
        public static LogManager Instance
        {
            get
            {
                if (_logmanager == null)
                {
                    lock (@lock)
                    {
                        if (_logmanager == null)
                            _logmanager = new LogManager();
                    }
                }
                return _logmanager;
            }
        }  
    }
}
