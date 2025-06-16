using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Undertale_Saver_Tool
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string language = Undertale_Saver_Tool.Properties.Settings.Default.Language;
            if (language == "ru")
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ru");
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ru");
            }
            else if (language == "en-US")
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            }


                Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
