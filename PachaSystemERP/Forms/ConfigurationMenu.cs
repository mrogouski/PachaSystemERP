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
            Configuracion.RutaCertificado = txtRutaDelCertificado.Text;
            Configuracion.PasswordCertificado = txtPassword.Text;
            if (long.TryParse(MtbCuit.Text, out long cuit))
            {
                Configuracion.Cuit = cuit;
            }

            Configuracion.GuardarConfiguracion();
            Close();
        }

        private void Configuracion_Load(object sender, EventArgs e)
        {
            MtbCuit.Text = Configuracion.Cuit.ToString();
            txtRutaDelCertificado.Text = Configuracion.RutaCertificado;
            txtPassword.Text = Configuracion.PasswordCertificado;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}