using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Usuario.Clases
{
    class ClasePin
    {
        private string _pin;
        private int _longitud;
        private int intentosPin = 0;
        private const int maxIntentos = 3;

        public ClasePin(int longitud)
        {
            _longitud = longitud;
            GenerarPin();
        }

        public void GenerarPin()
        {
            Random r = new Random();
            _pin = "";
            for (int c = 0; c < _longitud; c++)
            {
                _pin += r.Next(10).ToString();
            }
        }

        // Nueva lógica para login
        public bool ValidarPinLogin(string pinIngresado, Form loginForm, Tema temaActual)
        {
            if (pinIngresado == _pin)
            {
                intentosPin = 0;
                return true;
            }
            else
            {
                intentosPin++;
                int intentosRestantes = maxIntentos - intentosPin;
                MessageBox.Show($"Contraseña incorrecta. Intentos restantes: {intentosRestantes}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (intentosPin >= maxIntentos)
                {
                    var result = MessageBox.Show(
                        "Ha fallado todos los intentos. Su cuenta ha sido bloqueada.\n¿Desea recuperar la contraseña o salir?",
                        "Cuenta bloqueada",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.Yes)
                    {
                        // Recuperar contraseña
                        FOLVIDOCONTRA recuperar = new FOLVIDOCONTRA(temaActual);
                        loginForm.Hide();
                        recuperar.FormClosed += (s, e) => loginForm.Show();
                        recuperar.Show();
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
                return false;
            }
        }

        public String Pin
        {
            get { return _pin; }
        }
    }
}
