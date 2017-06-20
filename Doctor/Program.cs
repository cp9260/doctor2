
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Windows.Forms;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace Doctor
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ILog log = log4net.LogManager.GetLogger("Program");
            //log.Info("222");
            //new Sqlservice().test();
            Application.Run(new Form1());
          
        }
        
    }
}
