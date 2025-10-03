using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Usuario;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            // Crear instancia del formulario Login
            Login login = new Login();

            // Ocultar la pantalla de inicio
            this.Hide();

            // Mostrar el login
            login.ShowDialog();

            // Cuando se cierre el login, se cierra la pantalla de inicio también
            this.Close();
        }
    }
}
