namespace PachaSystemERP.Forms
{
    using PachaSystemERP.Classes;
    using System;
    using System.Windows.Forms;

    public partial class ConfigurationMenu : Form
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ConfigurationMenu"/>.
        /// </summary>
        public ConfigurationMenu()
        {
            InitializeComponent();
        }

        private void btnSeleccionarCertificado_Click(object sender, EventArgs e)
        {
            openFileDialogCertificado.Title = "Seleccionar certificado";
            openFileDialogCertificado.FileName = string.Empty;
            openFileDialogCertificado.Filter = "Certificado AFIP (*.pfx) |*.pfx";
            var result = openFileDialogCertificado.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtRutaDelCertificado.Text = openFileDialogCertificado.FileName;
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            PachaSystemApplicationConfiguration.RutaCertificado = txtRutaDelCertificado.Text;
            PachaSystemApplicationConfiguration.PasswordCertificado = txtPassword.Text;
            if (long.TryParse(MtbCuit.Text, out long cuit))
            {
                PachaSystemApplicationConfiguration.Cuit = cuit;
            }

            PachaSystemApplicationConfiguration.GuardarConfiguracion();
            Close();
        }

        private void Configuracion_Load(object sender, EventArgs e)
        {
            MtbCuit.Text = PachaSystemApplicationConfiguration.Cuit.ToString();
            txtRutaDelCertificado.Text = PachaSystemApplicationConfiguration.RutaCertificado;
            txtPassword.Text = PachaSystemApplicationConfiguration.PasswordCertificado;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}