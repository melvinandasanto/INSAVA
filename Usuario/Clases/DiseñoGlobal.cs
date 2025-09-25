using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Usuario.Clases
{
    /// <summary>
    /// Proporciona utilidades globales para aplicar estilos, temas y formatos a controles de la aplicaci�n.
    /// </summary>
    public static class Dise�oGlobal
    {
        // --- TEMAS ---
        public static void AplicarTema(Form form, Tema tema)
        {
            form.BackColor = tema.Fondo;
            form.ForeColor = tema.ForeColor;
            foreach (Control control in form.Controls)
            {
                AplicarTemaControl(control, tema);
            }
        }

        public static void AplicarTema(Control control, Tema tema)
        {
            if (control is Button)
            {
                AplicarFormatoBoton((Button)control, tema);
            }
            else if (control is TextBox)
            {
                control.BackColor = tema.TxtBoxColor;
                control.ForeColor = tema.TxtBoxForeColor;
            }
            else
            {
                control.BackColor = tema.Fondo;
                control.ForeColor = tema.ForeColor;
            }

            foreach (Control child in control.Controls)
            {
                AplicarTema(child, tema);
            }

            if (control is MenuStrip menuStrip)
            {
                menuStrip.BackColor = tema.Fondo;
                menuStrip.ForeColor = tema.ForeColor;
                foreach (ToolStripMenuItem item in menuStrip.Items)
                {
                    AplicarTemaMenuItem(item, tema);
                }
            }
        }

        private static void AplicarTemaControl(Control control, Tema tema)
        {
            if (control is Button)
            {
                AplicarFormatoBoton((Button)control, tema);
            }
            else if (control is TextBox)
            {
                control.BackColor = tema.TxtBoxColor;
                control.ForeColor = tema.TxtBoxForeColor;
            }
            else if (control is DataGridView)
            {
                control.BackColor = tema.TxtBoxColor;
                control.ForeColor = tema.TxtBoxForeColor;
            }

            else
            {
                control.BackColor = tema.Fondo;
                control.ForeColor = tema.ForeColor;
            }
            

            foreach (Control child in control.Controls)
            {
                AplicarTemaControl(child, tema);
            }

            if (control is MenuStrip menuStrip)
            {
                menuStrip.BackColor = tema.Fondo;
                menuStrip.ForeColor = tema.ForeColor;
                foreach (ToolStripMenuItem item in menuStrip.Items)
                {
                    AplicarTemaMenuItem(item, tema);
                }
            }
        }

        private static void AplicarTemaMenuItem(ToolStripMenuItem item, Tema tema)
        {
            item.BackColor = tema.Fondo;
            item.ForeColor = tema.ForeColor;
            foreach (ToolStripItem subItem in item.DropDownItems)
            {
                if (subItem is ToolStripMenuItem subMenuItem)
                    AplicarTemaMenuItem(subMenuItem, tema);
            }
        }

        // --- BOTONES ---
        public static void AplicarFormatoBoton(Button btn, Tema tema = null)
        {
            if (tema != null)
            {
                btn.BackColor = tema.BtnColor;
                btn.ForeColor = tema.BtnForeColor;
            }
            // Aqu� puedes agregar m�s formato, por ejemplo FlatStyle, bordes, etc.
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
        }

        public static void AplicarFormatoBotones(Control parent, Tema tema = null)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is Button btn)
                    AplicarFormatoBoton(btn, tema);

                if (control.HasChildren)
                    AplicarFormatoBotones(control, tema);
            }
        }

        // --- PICTUREBOX ---
        public static void AplicarTintePictureBox(PictureBox pictureBox, Color colorTinte, Dictionary<PictureBox, Image> imagenesOriginales = null)
        {
            if (pictureBox.Image == null) return;

            if (imagenesOriginales != null)
            {
                if (!imagenesOriginales.ContainsKey(pictureBox))
                    imagenesOriginales[pictureBox] = (Image)pictureBox.Image.Clone();

                pictureBox.Image = TintImageOptimizada(imagenesOriginales[pictureBox], colorTinte);
            }
            else
            {
                pictureBox.Image = TintImageOptimizada(pictureBox.Image, colorTinte);
            }
        }

        public static void AplicarTintePictureBoxLista(IEnumerable<PictureBox> pictureBoxes, Color colorTinte, Dictionary<PictureBox, Image> imagenesOriginales = null)
        {
            foreach (var pb in pictureBoxes)
            {
                AplicarTintePictureBox(pb, colorTinte, imagenesOriginales);
            }
        }

        // --- TOOLSTRIP BUTTONS ---
        public static void AplicarTinteToolStripButtons(Control parent, Color colorTinte)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is ToolStrip ts)
                {
                    foreach (ToolStripItem item in ts.Items)
                    {
                        if (item is ToolStripButton btn)
                        {
                            btn.ForeColor = colorTinte;
                            if (btn.Image != null)
                            {
                                // Guarda la imagen original solo la primera vez
                                if (btn.Tag == null || !(btn.Tag is Image))
                                    btn.Tag = btn.Image.Clone();

                                Image original = btn.Tag as Image;
                                btn.Image = TintImageOptimizada(original, colorTinte);
                            }
                        }
                    }
                }
                // Recursivo para controles hijos
                if (c.HasChildren)
                    AplicarTinteToolStripButtons(c, colorTinte);
            }
        }

        // Optimizaci�n: para �conos PNG negros con fondo transparente
        public static Image TintImageOptimizada(Image image, Color color)
        {
            if (image == null) return null;

            Bitmap bmp = new Bitmap(image.Width, image.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                // Solo cambia los p�xeles negros, respeta la transparencia
                for (int y = 0; y < image.Height; y++)
                {
                    for (int x = 0; x < image.Width; x++)
                    {
                        Color pixel = ((Bitmap)image).GetPixel(x, y);
                        if (pixel.A == 0)
                        {
                            bmp.SetPixel(x, y, Color.Transparent);
                        }
                        else if (pixel.R < 30 && pixel.G < 30 && pixel.B < 30)
                        {
                            // Si es negro, aplica el color deseado manteniendo la opacidad
                            Color nuevo = Color.FromArgb(pixel.A, color.R, color.G, color.B);
                            bmp.SetPixel(x, y, nuevo);
                        }
                        else
                        {
                            // Mantiene otros colores (por si acaso)
                            bmp.SetPixel(x, y, pixel);
                        }
                    }
                }
            }
            return bmp;
        }

        public static void AplicarTama�o(Control control, int width = 1680, int height = 945)
        {
            // Solo aplica a Forms y UserControls, excluyendo Login y FOLVIDOCONTRA
            if (control == null) return;
            var typeName = control.GetType().Name.ToLower();
            if ((control is Form || control is UserControl) &&
                !typeName.Contains("login") && !typeName.Contains("olvidocontra"))
            {
                control.Width = width;
                control.Height = height;
            }
        }

        // === Inicializaci�n del tema Light por defecto ===
        public static Tema TemaLight { get; } = new Tema
        {
            Fondo = Color.White,
            ForeColor = Color.Black,
            BtnColor = Color.LightGray,
            BtnForeColor = Color.Black,
            TxtBoxColor = Color.White,
            TxtBoxForeColor = Color.Black
        };


        public static void AplicarEstiloDataGridView(DataGridView dgv, Tema tema, Font fuente = null)
        {
            if (dgv == null || tema == null) return;

            // Fuente
            dgv.Font = fuente ?? new Font("Arial Rounded MT Bold", 10.5F, FontStyle.Regular);

            // Colores generales
            dgv.BackgroundColor = tema.Fondo;
            dgv.ForeColor = tema.ForeColor;
            dgv.GridColor = tema.ForeColor;

            // Encabezados
            dgv.ColumnHeadersDefaultCellStyle.BackColor = tema.Fondo;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = tema.ForeColor;
            dgv.ColumnHeadersDefaultCellStyle.Font = dgv.Font;

            // Filas
            dgv.DefaultCellStyle.BackColor = tema.TxtBoxColor;
            dgv.DefaultCellStyle.ForeColor = tema.TxtBoxForeColor;
            dgv.DefaultCellStyle.SelectionBackColor = tema.BtnColor;
            dgv.DefaultCellStyle.SelectionForeColor = tema.BtnForeColor;
            dgv.DefaultCellStyle.Font = dgv.Font;

            // Bordes y otros detalles
            dgv.EnableHeadersVisualStyles = false;
            dgv.RowHeadersDefaultCellStyle.BackColor = tema.Fondo;
            dgv.RowHeadersDefaultCellStyle.ForeColor = tema.ForeColor;
            dgv.RowHeadersDefaultCellStyle.Font = dgv.Font;
        }

        /// <summary>
        /// Guarda las preferencias de tema del usuario en memoria.
        /// </summary>
        private static Tema _temaUsuario;

        /// <summary>
        /// Establece el tema preferido del usuario.
        /// </summary>
        public static void GuardarTemaUsuario(Tema tema)
        {
            _temaUsuario = tema;
        }

        /// <summary>
        /// Obtiene el tema preferido del usuario.
        /// </summary>
        public static Tema ObtenerTemaUsuario()
        {
            return _temaUsuario ?? TemaLight;
        }

        /// <summary>
        /// Aplica un tema guardado al formulario.
        /// </summary>
        public static void AplicarTemaUsuario(Form form)
        {
            var tema = ObtenerTemaUsuario();
            AplicarTema(form, tema);
        }
    }
}