// <copyright file="Configuracion.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystemERP.Classes
{
    using PachaSystemERP.Enums;
    using System;
    using System.Configuration;

    public static class Configuracion
    {
        public static long Cuit { get; set; }

        public static int Responsabilidad { get; set; }

        public static string RutaCertificado { get; set; }

        public static string PasswordCertificado { get; set; }

        public static ModoFacturacion ModoFacturacion { get; set; }

        public static ModoOperacion ModoDeOperacion { get; set; }

        public static int PuntoVenta { get; set; }

        public static void CargarConfiguracion()
        {
            DesencriptarConfiguracion();
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;
            Cuit = long.Parse(settings["Cuit"].Value);
            Responsabilidad = int.Parse(settings["TipoResponsable"].Value);
            RutaCertificado = settings["RutaCertificado"].Value;
            PasswordCertificado = settings["PasswordCertificado"].Value;
            ModoFacturacion = (ModoFacturacion)Enum.Parse(typeof(ModoFacturacion), settings["ModoDeFacturacion"].Value);
            if (ModoFacturacion == ModoFacturacion.FacturaElectronica)
            {
                ModoDeOperacion = (ModoOperacion)Enum.Parse(typeof(ModoOperacion), settings["ModoDeOperacion"].Value);
                PuntoVenta = int.Parse(settings["PuntoDeVenta"].Value);
            }

            EncriptarConfiguracion();
        }

        public static void GuardarConfiguracion()
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;
            settings.Add("Cuit", "20376893198");
            configFile.Save(ConfigurationSaveMode.Modified);
            EncriptarConfiguracion();
        }

        private static void EncriptarConfiguracion()
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConfigurationSection section = configuration.AppSettings;
            if (!section.SectionInformation.IsProtected)
            {
                section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
                configuration.Save();
            }
        }

        private static void DesencriptarConfiguracion()
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConfigurationSection section = configuration.AppSettings;
            if (section.SectionInformation.IsProtected)
            {
                section.SectionInformation.UnprotectSection();
            }
        }
    }
}