using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utlity
{
    public class Logging : ILogging
    {
        private string _fileName = string.Empty;

        private string LogFolder
        {
            get
            {
                String folderPath = string.Empty;
                try
                {
                    folderPath = AppDomain.CurrentDomain.BaseDirectory + "\\Log";
                    if (!System.IO.Directory.Exists(folderPath))
                    {
                        System.IO.Directory.CreateDirectory(folderPath);
                    }
                }
                catch
                {
                    folderPath = AppDomain.CurrentDomain.BaseDirectory;
                }

                return folderPath;
            }
        }

        private string FileName
        {
            get
            {
                if (string.IsNullOrEmpty(_fileName))
                {
                    _fileName = LogFolder + "\\Log_";
                    _fileName = _fileName + DateTime.Now.ToString("MM") + "_";
                    _fileName = _fileName + DateTime.Now.ToString("dd") + "_";
                    _fileName = _fileName + DateTime.Now.ToString("yyyy") + "_";
                    _fileName = _fileName + DateTime.Now.ToString("HH") + "_";
                    _fileName = _fileName + DateTime.Now.ToString("mm") + "_";
                    _fileName = _fileName + DateTime.Now.ToString("ss") + ".txt";
                }
                else
                {
                    if (!File.Exists(_fileName))
                    {
                        FileStream file = File.Create(_fileName);
                        file.Close();
                    }
                    else
                    {
                        FileInfo file = new FileInfo(_fileName);
                        if (file.Length > 1048576)
                        {
                            _fileName = string.Empty;
                            return FileName;
                        }
                    }

                    //FileInfo file = new FileInfo(_fileName);
                    //if (file.Length > 1048576)
                    //{
                    //    _fileName = string.Empty;
                    //    return FileName;
                    //}
                }

                return _fileName;
            }
        }


        //const string SinexErrLog = @"Log\ErrLog.txt";
        public void WriteLog(string message)
        {
            try
            {
#pragma warning disable CS0219 // The variable 'file' is assigned but its value is never used
                FileInfo file = null;
#pragma warning restore CS0219 // The variable 'file' is assigned but its value is never used

                string fileName = FileName;

                using (StreamWriter w = File.AppendText(fileName))
                {
                    w.WriteLine(string.Format("{0} - {1} ", DateTime.Now, message));
                 //   w.WriteLine(string.Format("---------------------------------- "));
                    w.Flush();
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {


            }

        }

        public void WriteErrorLog(string message)
        {
#pragma warning disable CS0219 // The variable 'file' is assigned but its value is never used
            FileInfo file = null;
#pragma warning restore CS0219 // The variable 'file' is assigned but its value is never used

            string fileName = FileName;

            using (StreamWriter w = File.AppendText(fileName))
            {
                w.WriteLine(string.Format(" {0} - Error {1} ", DateTime.Now, message));
             //   w.WriteLine(string.Format("---------------------------------- "));
                w.Flush();
            }
        }
    }
}
