using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Usuario.Clases
{
    /// <summary>
    /// Gestiona permisos de acceso y visibilidad de controles según el rol del usuario.
    /// Permite asignar, consultar y verificar permisos dinámicamente.
    /// </summary>
    public static class Permisos
    {
        // Diccionario de permisos por rol y acción
        private static Dictionary<string, HashSet<string>> permisosPorRol = new Dictionary<string, HashSet<string>>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Aplica permisos generales a un formulario o UserControl (bloquea botones de eliminar/borrar).
        /// </summary>
        public static void AplicarPermisos(Control controlRaiz)
        {
            if (EsAdministrador())
                return;

            foreach (Control control in controlRaiz.Controls)
            {
                AplicarPermisosControl(control);
            }
        }

        /// <summary>
        /// Oculta opciones del menú principal para empleados.
        /// </summary>
        public static void AplicarPermisosMenu(FMENU menu)
        {
            if (EsAdministrador())
                return;

            foreach (Control ctrl in menu.Controls)
            {
                if (ctrl is ToolStrip ts)
                {
                    foreach (ToolStripItem item in ts.Items)
                    {
                        if (item.Name.ToLower().Contains("usuario") ||
                            item.Name.ToLower().Contains("cliente") ||
                            item.Name.ToLower().Contains("inventario"))
                        {
                            item.Visible = false;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Asigna un permiso a un rol específico.
        /// </summary>
        public static void AsignarPermiso(string rol, string permiso)
        {
            if (!permisosPorRol.ContainsKey(rol))
                permisosPorRol[rol] = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            permisosPorRol[rol].Add(permiso);
        }

        /// <summary>
        /// Verifica si el usuario actual tiene un permiso específico.
        /// </summary>
        public static bool TienePermiso(string permiso)
        {
            if (EsAdministrador()) return true;
            if (string.IsNullOrEmpty(SesionUsuario.RolNombre)) return false;
            if (!permisosPorRol.ContainsKey(SesionUsuario.RolNombre)) return false;
            return permisosPorRol[SesionUsuario.RolNombre].Contains(permiso);
        }

        /// <summary>
        /// Obtiene la lista de permisos asignados a un rol.
        /// </summary>
        public static IEnumerable<string> ObtenerPermisosDeRol(string rol)
        {
            if (permisosPorRol.ContainsKey(rol))
                return permisosPorRol[rol];
            return Enumerable.Empty<string>();
        }

        /// <summary>
        /// Aplica permisos a controles internos (deshabilita botones de eliminar/borrar).
        /// </summary>
        private static void AplicarPermisosControl(Control control)
        {
            if (control is Button boton)
            {
                if (boton.Name.ToLower().Contains("eliminar") ||
                    boton.Name.ToLower().Contains("borrar"))
                {
                    boton.Enabled = false;
                }
            }
            else if (control is ToolStrip toolStrip)
            {
                foreach (ToolStripItem item in toolStrip.Items)
                {
                    if (item.Name.ToLower().Contains("eliminar") ||
                        item.Name.ToLower().Contains("borrar"))
                    {
                        item.Enabled = false;
                    }
                }
            }

            foreach (Control hijo in control.Controls)
            {
                AplicarPermisosControl(hijo);
            }
        }

        /// <summary>
        /// Verifica si el usuario actual es administrador.
        /// </summary>
        private static bool EsAdministrador()
        {
            return !string.IsNullOrEmpty(SesionUsuario.RolNombre) &&
                   SesionUsuario.RolNombre.Equals("Administrador", StringComparison.OrdinalIgnoreCase);
        }
    }
}
