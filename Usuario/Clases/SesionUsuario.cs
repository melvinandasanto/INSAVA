using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuario.Clases
{
    /// <summary>
    /// Gestiona la sesión del usuario actual en el sistema.
    /// Proporciona información y utilidades para la sesión activa.
    /// </summary>
    public static class SesionUsuario
    {
        /// <summary>
        /// Identificador único del usuario.
        /// </summary>
        public static int IDUsuario { get; set; }
        /// <summary>
        /// Nombre completo del usuario.
        /// </summary>
        public static string NombreCompleto { get; set; }
        /// <summary>
        /// Correo electrónico del usuario.
        /// </summary>
        public static string Correo { get; set; }
        /// <summary>
        /// Rol o perfil del usuario.
        /// </summary>
        public static string RolNombre { get; set; }
        /// <summary>
        /// Fecha y hora de inicio de sesión.
        /// </summary>
        public static DateTime FechaInicioSesion { get; set; }
        /// <summary>
        /// Fecha y hora del último acceso.
        /// </summary>
        public static DateTime UltimoAcceso { get; set; }
        /// <summary>
        /// Token de autenticación (para APIs o sesiones avanzadas).
        /// </summary>
        public static string TokenAutenticacion { get; set; }
        /// <summary>
        /// Indica si la sesión está activa.
        /// </summary>
        public static bool SesionActiva { get; set; }

        /// <summary>
        /// Cierra la sesión y limpia los datos de usuario.
        /// </summary>
        public static void CerrarSesion()
        {
            IDUsuario = 0;
            NombreCompleto = null;
            Correo = null;
            RolNombre = null;
            FechaInicioSesion = DateTime.MinValue;
            UltimoAcceso = DateTime.MinValue;
            TokenAutenticacion = null;
            SesionActiva = false;
        }
    }
}
