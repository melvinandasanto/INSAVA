using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Usuario.Clases;

namespace Usuario
{
    public partial class FOLVIDOCONTRA : Form
    {
        private Tema temaActual;
        private string pinGenerado = null;

        public FOLVIDOCONTRA(Tema tema)
        {
            InitializeComponent();
            this.temaActual = tema;
            txtNuevaContrasena.Enabled = false;
            txtConfirmarContrasena.Enabled = false;
            DiseñoGlobal.AplicarTema(this, temaActual);
            DiseñoGlobal.AplicarFormatoBotones(this, temaActual);
            DiseñoGlobal.AplicarTinteToolStripButtons(this, temaActual.ForeColor);
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSolicitarPin_Click(object sender, EventArgs e)
        {
            string numeroIdentidad = txtUsuario.Text.Trim();

            if (string.IsNullOrEmpty(numeroIdentidad))
            {
                MessageBox.Show("Por favor, ingrese su número de identidad.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Generar el PIN y guardarlo en variable
            ClasePin pin = new ClasePin(4);
            pinGenerado = pin.Pin;

            // Mostrar el PIN en un MessageBox que se cierra a los 5 segundos
            Thread t = new Thread(() =>
            {
                MessageBoxTemporal.Show($"El PIN generado es: {pinGenerado}", "PIN Generado", 5000);
            });
            t.Start();
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            string pinIngresado = txtPin.Text.Trim();
            if (string.IsNullOrEmpty(pinGenerado))
            {
                MessageBox.Show("Primero solicite un PIN.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (pinIngresado == pinGenerado)
            {
                txtNuevaContrasena.Enabled = true;
                txtConfirmarContrasena.Enabled = true;
                MessageBox.Show("PIN verificado. Ahora puede cambiar su contraseña.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("El PIN ingresado es incorrecto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            string nuevaContrasena = txtNuevaContrasena.Text.Trim();
            string confirmarContrasena = txtConfirmarContrasena.Text.Trim();
            string numeroIdentidad = txtUsuario.Text.Trim();

            if (!txtNuevaContrasena.Enabled || !txtConfirmarContrasena.Enabled)
            {
                MessageBox.Show("Debe verificar el PIN antes de cambiar la contraseña.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nuevaContrasena != confirmarContrasena)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Actualizar la contraseña en la base de datos usando ClaseConexion
            string updateQuery = "UPDATE USUARIO SET Clave = @NuevaContrasena WHERE NumeroIdentidad = @NumeroIdentidad";
            var conexion = new ClaseConexion();
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@NuevaContrasena", nuevaContrasena),
                new SqlParameter("@NumeroIdentidad", numeroIdentidad)
            };

            try
            {
                if (conexion.EjecutarSQL(updateQuery, parametros))
                {
                    MessageBox.Show("Contraseña cambiada correctamente. Volverá al login.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al cambiar la contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cambiar la contraseña: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;
        private void toolStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
        private void btnCambiarTema_Click(object sender, EventArgs e)
        {
            if (temaActual == Temas.Light)
                temaActual = Temas.Dark;
            else
                temaActual = Temas.Light;

            DiseñoGlobal.AplicarTema(this, temaActual);
            DiseñoGlobal.AplicarFormatoBotones(this, temaActual);
            DiseñoGlobal.AplicarTinteToolStripButtons(this, temaActual.ForeColor);

            foreach (Form child in this.MdiChildren)
            {
                DiseñoGlobal.AplicarTema(child, temaActual);
                DiseñoGlobal.AplicarFormatoBotones(child, temaActual);
                DiseñoGlobal.AplicarTinteToolStripButtons(child, temaActual.ForeColor);
            }
        }
    }

    // Clase auxiliar para MessageBox temporal
    public static class MessageBoxTemporal
    {
        public static void Show(string text, string caption, int timeout)
        {
            using (var msgBox = new Form())
            {
                msgBox.StartPosition = FormStartPosition.CenterScreen;
                msgBox.FormBorderStyle = FormBorderStyle.FixedDialog;
                msgBox.MinimizeBox = false;
                msgBox.MaximizeBox = false;
                msgBox.ControlBox = false;
                msgBox.Text = caption;
                msgBox.Size = new Size(350, 150);
                Label lbl = new Label() { Text = text, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Arial", 12, FontStyle.Bold) };
                msgBox.Controls.Add(lbl);
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = timeout;
                timer.Tick += (s, e) => { msgBox.Close(); };
                timer.Start();
                msgBox.ShowDialog();
            }
        }
    }
}