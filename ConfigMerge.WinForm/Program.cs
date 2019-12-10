using ConfigMerge.Services.Logging;
using ConfigMerge.WinForm.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfigMerge.WinForm
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            LoggerFactory.SetLoggerFunction(new FileLoggerCreator());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
