using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Usuario.Clases;

namespace Usuario
{
    /// <summary>
    /// Representa un rol del sistema.
    /// </summary>
    public class ClaseROL
    {
        private int _idRol;
        private string _nombreRol;

        private CRUD crud;

        public ClaseROL()
        {
            Reiniciar();
            var conexion = new ClaseConexion();
            crud = new CRUD("ROL", conexion);
        }

        public int IDRol
        {
            get => _idRol;
            set => _idRol = value;
        }

        public string NombreRol
        {
            get => _nombreRol;
            set => _nombreRol = value;
        }

        /// <summary>
        /// Reinicia los valores del rol.
        /// </summary>
        public void Reiniciar()
        {
            _idRol = 0;
            _nombreRol = string.Empty;
        }

        /// <summary>
        /// Guarda un nuevo rol.
        /// </summary>
        public bool Guardar()
        {
            var campos = new Dictionary<string, object>
            {
                ["NombreRol"] = _nombreRol
            };

            return crud.Insertar(campos);
        }

        /// <summary>
        /// Edita un rol existente.
        /// </summary>
        public bool Editar()
        {
            if (_idRol == 0)
                throw new InvalidOperationException("Debe especificar el ID del rol para editar.");

            var campos = new Dictionary<string, object>
            {
                ["NombreRol"] = _nombreRol
            };

            return crud.Editar("IDRol", _idRol, campos);
        }

        /// <summary>
        /// Elimina un rol (solo si decides permitirlo).
        /// </summary>
        public bool Eliminar()
        {
            if (_idRol == 0)
                throw new InvalidOperationException("Debe especificar el ID del rol para eliminar.");

            // Si quieres borrar físicamente:
            return crud.Eliminar("IDRol", _idRol);
        }

        /// <summary>
        /// Busca un rol por ID.
        /// </summary>
        public bool BuscarPorId(int id)
        {
            var row = crud.BuscarRegistroPorId("IDRol", id);
            if (row != null)
            {
                _idRol = Convert.ToInt32(row["IDRol"]);
                _nombreRol = row["NombreRol"].ToString();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Busca un rol por nombre.
        /// </summary>
        public bool ExistePorNombre(string nombre)
        {
            return crud.BuscarPorCampo("NombreRol", nombre);
        }

        /// <summary>
        /// Llena un DataGridView con los roles.
        /// </summary>
        public void CargarRoles(DataGridView grid)
        {
            var conexion = new ClaseConexion();
            string consulta = "SELECT * FROM ROL";

            var dt = conexion.Tabla(consulta);
            grid.DataSource = dt;

            if (grid.Columns.Contains("IDRol"))
                grid.Columns["IDRol"].HeaderText = "ID Rol";
        }

        /// <summary>
        /// Obtiene la lista de roles.
        /// </summary>
        public DataTable ObtenerRoles()
        {
            var conexion = new ClaseConexion();
            string consulta = "SELECT * FROM ROL";
            return conexion.Tabla(consulta);
        }
    }
}
