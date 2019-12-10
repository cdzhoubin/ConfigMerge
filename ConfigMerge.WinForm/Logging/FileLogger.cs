using ConfigMerge.Services.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigMerge.WinForm.Logging
{
    public class FileLogger : ILogger
    {
        public FileLogger(string name) {
            _name = name;
        }
        private string _name;
        private static string LoggerDirctory = GetLoggerDirector();
        static string GetLoggerDirector()
        {
            var str = AppDomain.CurrentDomain.BaseDirectory.Trim('\\') + "\\Logs";
            if (Directory.Exists(str))
            {
                Directory.CreateDirectory(str);
            }
            return str;
        }
        public void Log(LogLevel level, object message)
        {
            string file = string.Format("{0}\\{1:yyyyMMddHH}.txt",LoggerDirctory,DateTime.Now);
            DateTime dateTime = DateTime.Now;
            lock (typeof(FileLogger))
            {
                File.AppendAllText(file, string.Format("{0} {3} {1} {2}\n", dateTime, level, message,_name));
            }
        }
    }

    public class FileLoggerCreator : ILoggerCreator
    {
        public ILogger Create(string name)
        {
            return new FileLogger(name);
        }
    }
}
