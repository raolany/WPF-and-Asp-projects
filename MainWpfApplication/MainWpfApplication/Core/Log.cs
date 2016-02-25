using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace MainWpfApplication.Core
{
    public class Log : IDisposable
    {
        private static Log instance;
        private static StreamWriter _writer;
        private static FileStream _fs;

        private Log()
        {

        }

        public static Log Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Log();
                    _fs = new FileStream(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "log.txt"), 
                                        FileMode.Create, FileAccess.Write);
                    _writer = new StreamWriter(_fs);
                }
                return instance;
            }
        }

        public void Error(string sender, string msg)
        {
            Write("ERROR", sender, msg);
        }

        public void Info(string sender, string msg)
        {
            Write("INFO", sender, msg);
        }

        public void Warning(string sender, string msg)
        {
            Write("Warning", sender, msg);
        }

        private void Write(string tag, string sender, string msg)
        {
            _writer.Write(DateTime.Now+" : ["+tag+", "+sender+"] :: ["+msg+"]"+Environment.NewLine);
            _writer.Flush();
        }

        public void Dispose()
        {
            _writer.Close();
            _fs.Close();
        }
    }
}
