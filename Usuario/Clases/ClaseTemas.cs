using System;
using System.Drawing;

namespace Usuario.Clases
{
    /// <summary>
    /// Representa un tema visual reutilizable para la aplicación.
    /// </summary>
    public class Tema
    {
        /// <summary>
        /// Color de fondo principal.
        /// </summary>
        public Color Fondo { get; set; }
        /// <summary>
        /// Color de texto principal.
        /// </summary>
        public Color ForeColor { get; set; }
        /// <summary>
        /// Color de fondo de los botones.
        /// </summary>
        public Color BtnColor { get; set; }
        /// <summary>
        /// Color de texto de los botones.
        /// </summary>
        public Color BtnForeColor { get; set; }
        /// <summary>
        /// Color de fondo de los cuadros de texto.
        /// </summary>
        public Color TxtBoxColor { get; set; }
        /// <summary>
        /// Color de texto de los cuadros de texto.
        /// </summary>
        public Color TxtBoxForeColor { get; set; }
    }

    /// <summary>
    /// Proporciona temas visuales predefinidos y utilidades para gestionarlos.
    /// </summary>
    public static class Temas
    {
        /// <summary>
        /// Tema claro por defecto.
        /// </summary>
        public static Tema Light = new Tema
        {
            Fondo = Color.White,
            ForeColor = Color.Black,
            BtnColor = Color.LightGray,
            BtnForeColor = Color.Black,
            TxtBoxColor = Color.White,
            TxtBoxForeColor = Color.Black,
        };

        /// <summary>
        /// Tema oscuro por defecto.
        /// </summary>
        public static Tema Dark = new Tema
        {
            Fondo = Color.FromArgb(9, 29, 15),
            ForeColor = Color.White,
            BtnColor = Color.FromArgb(30, 50, 35),
            BtnForeColor = Color.White,
            TxtBoxColor = Color.FromArgb(20, 40, 25),
            TxtBoxForeColor = Color.White,
        };

        /// <summary>
        /// Permite agregar un tema personalizado.
        /// </summary>
        public static Tema CrearTemaPersonalizado(Color fondo, Color foreColor, Color btnColor, Color btnForeColor, Color txtBoxColor, Color txtBoxForeColor)
        {
            return new Tema
            {
                Fondo = fondo,
                ForeColor = foreColor,
                BtnColor = btnColor,
                BtnForeColor = btnForeColor,
                TxtBoxColor = txtBoxColor,
                TxtBoxForeColor = txtBoxForeColor
            };
        }
    }
}
