using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIFR.Helper
{
    public static class Logger
    {
        public static string logFile = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\log.txt";//读取文件txt   
         
        public static string Read()
        {
            StringBuilder rerult = new StringBuilder();
            using (FileStream fileStream = new FileStream(logFile, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    while (!reader.EndOfStream)
                    {
                        string sLine = reader.ReadLine();
                        if (sLine.Length < 1)
                        {
                            continue;
                        }

                        string sRecordKbn = sLine.Substring(0, 8);//截取的数据   

                        rerult.Append(sRecordKbn + "/r/n");
                    }
                }
            }

            return rerult.ToString();
        }
         
        public static void Write(string message)
        {
            if (File.Exists(logFile)) 
            {
                using (StreamWriter streamWriter = File.AppendText(logFile))
                {
                    streamWriter.WriteLine(message);
                }
            }
            else 
            {
                FileStream fileStream;
                fileStream = File.Create(logFile); 
                fileStream.Close();
                using (StreamWriter streamWriter = File.AppendText(logFile))
                {
                    streamWriter.WriteLine(message);
                }
            }

        }
    }
}
