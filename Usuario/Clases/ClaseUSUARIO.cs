using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Usuario.Clases;

namespace Usuario
{
    /// <summary>
    /// Representa un usuario del sistema.
    /// </summary>
    public class ClaseUSUARIO
    {
        // Campos privados
        private int _idUsuario;
        private string _numeroIdentidad;
        private string _primerNombre;
        private string _segundoNombre;
        private string _primerApellido;
        private string _segundoApellido;
        private string _clave;
        private int _idRol;
        private bool _activo;

        private CRUD crud;

        // Constructor
        public ClaseUSUARIO()
        {
            Reiniciar();
            var conexion = new ClaseConexion();
            crud = new CRUD("USUARIO", conexion);
        }

        // Propiedades públicas
        public int IDUsuario
        {
            get => _idUsuario;
            set => _idUsuario = value;
        }

        public string NumeroIdentidad
        {
            get => _numeroIdentidad;
            set => _numeroIdentidad = value;
        }

        public string PrimerNombre
        {
            get => _primerNombre;
            set => _primerNombre = value;
        }

        public string SegundoNombre
        {
            get => _segundoNombre;
            set => _segundoNombre = value;
        }

        public string PrimerApellido
        {
            get => _primerApellido;
            set => _primerApellido = value;
        }

        public string SegundoApellido
        {
            get => _segundoApellido;
            set => _segundoApellido = value;
        }

        public string Clave
        {
            get => _clave;
            set => _clave = value;
        }

        public int IDRol
        {
            get => _idRol;
            set => _idRol = value;
        }

        public bool Activo
        {
            get => _activo;
            set => _activo = value;
        }

        /// <summary>
        /// Reinicia todos los valores de la clase.
        /// </summary>
        public void Reiniciar()
        {
            _idUsuario = 0;
            _numeroIdentidad = string.Empty;
            _primerNombre = string.Empty;
            _segundoNombre = string.Empty;
            _primerApellido = string.Empty;
            _segundoApellido = string.Empty;
            _clave = string.Empty;
            _idRol = 0;
            _activo = true;
        }

        /// <summary>
        /// Guarda un nuevo usuario en la base de datos.
        /// </summary>
        public bool Guardar()
        {
            var campos = new Dictionary<string, object>
            {
                ["NumeroIdentidad"] = NumeroIdentidad,
                ["PrimerNombre"] = PrimerNombre,
                ["SegundoNombre"] = string.IsNullOrEmpty(SegundoNombre) ? (object)DBNull.Value : SegundoNombre,
                ["PrimerApellido"] = PrimerApellido,
                ["SegundoApellido"] = string.IsNullOrEmpty(SegundoApellido) ? (object)DBNull.Value : SegundoApellido,
                ["Clave"] = Clave,
                ["IDRol"] = IDRol,
                ["Activo"] = Activo ? 1 : 0
            };

            return crud.Insertar(campos);
        }

        /// <summary>
        /// Edita los datos de un usuario existente.
        /// </summary>
        public bool Editar()
        {
            if (IDUsuario == 0)
                throw new InvalidOperationException("Debe especificar el ID del usuario para editar.");

            var campos = new Dictionary<string, object>
            {
                ["NumeroIdentidad"] = NumeroIdentidad,
                ["PrimerNombre"] = PrimerNombre,
                ["SegundoNombre"] = string.IsNullOrEmpty(SegundoNombre) ? (object)DBNull.Value : SegundoNombre,
                ["PrimerApellido"] = PrimerApellido,
                ["SegundoApellido"] = string.IsNullOrEmpty(SegundoApellido) ? (object)DBNull.Value : SegundoApellido,
                ["Clave"] = Clave,
                ["IDRol"] = IDRol,
                ["Activo"] = Activo ? 1 : 0
            };

            return crud.Editar("IDUsuario", IDUsuario, campos);
        }

        /// <summary>
        /// Realiza un borrado lógico (UPDATE Activo = 0).
        /// </summary>
        public bool BorradoLogico()
        {
            if (IDUsuario == 0)
                throw new InvalidOperationException("Debe especificar el ID del usuario para eliminar.");

            var campos = new Dictionary<string, object>
            {
                ["Activo"] = 0
            };

            return crud.Editar("IDUsuario", IDUsuario, campos);
        }

        /// <summary>
        /// Realiza un borrado físico (DELETE).
        /// </summary>
        public bool Eliminar()
        {
            if (IDUsuario == 0)
                throw new Exception("IDUsuario no está asignado. No se puede eliminar.");

            return crud.Eliminar("IDUsuario", IDUsuario);
        }

        /// <summary>
        /// Busca un usuario por ID y carga sus datos en la clase.
        /// </summary>
        public bool BuscarPorId(int id)
        {
            var row = crud.BuscarRegistroPorId("IDUsuario", id);
            if (row != null)
            {
                LlenarDesdeRow(row);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Busca un usuario por número de identidad y devuelve la instancia cargada.
        /// </summary>
        public ClaseUSUARIO BuscarPorNumeroIdentidad(string numeroIdentidad)
        {
            var row = crud.BuscarRegistroPorCampo("NumeroIdentidad", numeroIdentidad);
            if (row != null)
            {
                var usuario = new ClaseUSUARIO();
                usuario.LlenarDesdeRow(row);
                return usuario;
            }

            return null;
        }

        /// <summary>
        /// Llena los campos de la clase desde un DataRow.
        /// </summary>
        private void LlenarDesdeRow(DataRow row)
        {
            IDUsuario = Convert.ToInt32(row["IDUsuario"]);
            NumeroIdentidad = row["NumeroIdentidad"].ToString();
            PrimerNombre = row["PrimerNombre"].ToString();
            SegundoNombre = row["SegundoNombre"] == DBNull.Value ? "" : row["SegundoNombre"].ToString();
            PrimerApellido = row["PrimerApellido"].ToString();
            SegundoApellido = row["SegundoApellido"] == DBNull.Value ? "" : row["SegundoApellido"].ToString();
            Clave = row["Clave"].ToString();
            IDRol = Convert.ToInt32(row["IDRol"]);
            Activo = Convert.ToBoolean(row["Activo"]);
        }

        /// <summary>
        /// Llena un DataGridView con los usuarios.
        /// </summary>
        public void CargarUsuarios(DataGridView grid, bool soloActivos = true)
        {
            try
            {
                var conexion = new ClaseConexion();

                string sql = soloActivos
                    ? @"SELECT * FROM VISTAFUSUARIO WHERE Activo = 1"
                    : @"SELECT * FROM VISTAFUSUARIO";

                DataTable dt = conexion.Tabla(sql);
                grid.DataSource = dt;

                if (grid.Columns.Contains("IDUsuario"))
                    grid.Columns["IDUsuario"].HeaderText = "ID Usuario";

                if (grid.Columns.Contains("NumeroIdentidad"))
                    grid.Columns["NumeroIdentidad"].HeaderText = "Número Identidad";

                if (grid.Columns.Contains("NombreCompleto"))
                    grid.Columns["NombreCompleto"].HeaderText = "Nombre Completo";

                if (grid.Columns.Contains("NombreRol"))
                    grid.Columns["NombreRol"].HeaderText = "Rol";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene todos los usuarios en un DataTable.
        /// </summary>
        public DataTable ObtenerUsuarios(bool soloActivos = true)
        {
            var conexion = new ClaseConexion();

            string sql = soloActivos
                ? "SELECT * FROM USUARIO WHERE Activo = 1"
                : "SELECT * FROM USUARIO";

            return conexion.Tabla(sql);
        }

        /// <summary>
        /// Verifica si existe un usuario por número de identidad.
        /// </summary>
        public bool ExistePorNumeroIdentidad(string numeroIdentidad)
        {
            var row = crud.BuscarRegistroPorCampo("NumeroIdentidad", numeroIdentidad);
            return row != null;
        }

        /// <summary>
        /// Autentica un usuario comparando identidad y clave.
        /// </summary>
        public bool Autenticar(string numeroIdentidad, string clave)
        {
            var row = crud.BuscarRegistroPorCampo("NumeroIdentidad", numeroIdentidad);
            if (row != null && row["Clave"].ToString() == clave)
            {
                LlenarDesdeRow(row);
                return true;
            }

            return false;
        }
    }
}
