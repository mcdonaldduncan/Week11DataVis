using System;
using System.Windows.Forms;

namespace DataVisWeek11
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DataVis dataVis = new DataVis();
            Application.Run(dataVis);

            dataVis.service.GenerateLogFile();
            dataVis.service.ReportErrors();
            dataVis.service.ReportFinalErrors();
            dataVis.Dispose();
        }
    }
}
