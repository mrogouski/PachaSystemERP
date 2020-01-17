using PachaSystem.Data;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace PachaSystemERP
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            CultureInfo culture;
            culture = CultureInfo.CreateSpecificCulture("es-AR");
            culture.NumberFormat.NumberDecimalSeparator = ".";
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            PachaSystemContext context = new PachaSystemContext();
            context.Database.Initialize(false);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms.MainMenu());
        }
    }
}