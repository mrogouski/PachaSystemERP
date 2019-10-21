// <copyright file="CertificadoX509.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystemERP.Classes
{
    using System;
    using System.IO;
    using System.Security.Cryptography.X509Certificates;

    /// <summary>
    /// Representa un certificado X.509 V3.
    /// </summary>
    public static class CertificadoX509
    {
        /// <summary>
        /// Importa el Certificado X.509 en formato PFX.
        /// </summary>
        /// <returns>Devuelve un objeto del tipo X509Certificate2.</returns>
        /// <exception cref="ArgumentException">Excepción que es arrojada cuando ocurre algun error al leer el archivo.</exception>
        public static X509Certificate2 Importar()
        {
            string password = Configuracion.PasswordCertificado ?? throw new ArgumentNullException(nameof(password));
            string path = Configuracion.RutaCertificado ?? throw new ArgumentNullException(nameof(path));

            if (!File.Exists(Path.GetFullPath(path)))
            {
                throw new FileNotFoundException();
            }
            else
            {
                X509Certificate2 certificado = new X509Certificate2();
                certificado.Import(path, password, X509KeyStorageFlags.DefaultKeySet);
                return certificado;
            }
        }
    }
}