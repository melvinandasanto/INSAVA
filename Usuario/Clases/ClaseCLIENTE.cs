using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Usuario.Clases;

namespace Usuario
{
    /// <summary>
    /// Representa un cliente del sistema.
    /// </summary>
    public class ClaseCLIENTE
    {
        private int _id;
        private string _numeroIdentidad;
        private string _primerNombre;
        private string _segundoNombre;
        private string _primerApellido;
        private string _segundoApellido;
        private string _numTel;
        private bool _activo;

        private CRUD crud;

        public ClaseCLIENTE()
        {
            Reiniciar();
            var conexion = new ClaseConexion();
            crud = new CRUD("CLIENTE", conexion);
        }

        public int Id
        {
            get => _id;
            set => _id = value;
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

        public string NumTel
        {
            get => _numTel;
            set => _numTel = value;
        }

        public bool Activo
        {
            get => _activo;
            set => _activo = value;
        }

        /// <summary>
        /// Reinicia los valores del objeto cliente.
        /// </summary>
        public void Reiniciar()
        {
            _id = 0;
            _numeroIdentidad = string.Empty;
            _primerNombre = string.Empty;
            _segundoNombre = string.Empty;
            _primerApellido = string.Empty;
            _segundoApellido = string.Empty;
            _numTel = string.Empty;
            _activo = true;

        }

        /// <summary>
        /// Guarda un nuevo cliente en la base de datos.
        /// </summary>
        public bool Guardar()
        {
            var campos = new Dictionary<string, object>
            {
                ["NumeroIdentidad"] = _numeroIdentidad,
                ["PrimerNombre"] = _primerNombre,
                ["SegundoNombre"] = string.IsNullOrEmpty(_segundoNombre) ? (object)DBNull.Value : _segundoNombre,
                ["PrimerApellido"] = _primerApellido,
                ["SegundoApellido"] = string.IsNullOrEmpty(_segundoApellido) ? (object)DBNull.Value : _segundoApellido,
                ["NumTel"] = _numTel,
                ["Activo"] = _activo ? 1 : 0
            };

            return crud.Insertar(campos);
        }

        /// <summary>
        /// Edita un cliente existente en la base de datos.
        /// </summary>
        public bool Editar()
        {
            if (_id == 0)
                throw new InvalidOperationException("Debe especificar el ID del cliente para editar.");

            var campos = new Dictionary<string, object>
            {
                ["NumeroIdentidad"] = _numeroIdentidad,
                ["PrimerNombre"] = _primerNombre,
                ["SegundoNombre"] = string.IsNullOrEmpty(_segundoNombre) ? (object)DBNull.Value : _segundoNombre,
                ["PrimerApellido"] = _primerApellido,
                ["SegundoApellido"] = string.IsNullOrEmpty(_segundoApellido) ? (object)DBNull.Value : _segundoApellido,
                ["NumTel"] = _numTel,
                ["Activo"] = _activo ? 1 : 0
            };

            return crud.Editar("IDCliente", _id, campos);
        }

        /// <summary>
        /// Elimina un cliente de la base de datos.
        /// </summary>
        public bool Eliminar()
        {
            string sql = "DELETE FROM CLIENTE WHERE IDCliente = @id";
            var parametros = new[] { new SqlParameter("@id", SqlDbType.Int) { Value = this.Id } };
            ClaseConexion conexion = new ClaseConexion();
            return conexion.EjecutarSQL(sql, parametros);
        }

        /// <summary>
        /// Busca un cliente por ID y carga sus datos en la clase.
        /// </summary>
        public bool BuscarPorId(int id)
        {
            var row = crud.BuscarRegistroPorId("IDCliente", id);
            if (row != null)
            {
                _id = Convert.ToInt32(row["IDCliente"]);
                _numeroIdentidad = row["NumeroIdentidad"].ToString();
                _primerNombre = row["PrimerNombre"].ToString();
                _segundoNombre = row["SegundoNombre"] == DBNull.Value ? "" : row["SegundoNombre"].ToString();
                _primerApellido = row["PrimerApellido"].ToString();
                _segundoApellido = row["SegundoApellido"] == DBNull.Value ? "" : row["SegundoApellido"].ToString();
                _numTel = row["NumTel"].ToString();
                _activo = Convert.ToBoolean(row["Activo"]);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Verifica si existe un cliente por su Número de Identidad.
        /// </summary>
        public bool ExistePorNumeroIdentidad(string numeroIdentidad)
        {
            return crud.BuscarPorCampo("NumeroIdentidad", numeroIdentidad);
        }

        /// <summary>
        /// Busca un cliente por Número de Identidad y devuelve una instancia de ClaseCLIENTE.
        /// </summary>
        public ClaseCLIENTE BuscarPorNumeroIdentidad(string numeroIdentidad)
        {
            var row = crud.BuscarRegistroPorCampo("NumeroIdentidad", numeroIdentidad);
            if (row != null)
            {
                var cliente = new ClaseCLIENTE
                {
                    Id = Convert.ToInt32(row["IDCliente"]),
                    NumeroIdentidad = row["NumeroIdentidad"].ToString(),
                    PrimerNombre = row["PrimerNombre"].ToString(),
                    SegundoNombre = row["SegundoNombre"] == DBNull.Value ? "" : row["SegundoNombre"].ToString(),
                    PrimerApellido = row["PrimerApellido"].ToString(),
                    SegundoApellido = row["SegundoApellido"] == DBNull.Value ? "" : row["SegundoApellido"].ToString(),
                    NumTel = row["NumTel"].ToString(),
                    Activo = Convert.ToBoolean(row["Activo"])
                };
                return cliente;
            }
            return null;
        }

        /// <summary>
        /// Llena un DataGridView con todos los clientes activos.
        /// </summary>
        public void CargarClientes(DataGridView grid, bool soloActivos = true)
        {
            var conexion = new ClaseConexion();
            var gridHelper = new GRID(conexion);

            string consulta = soloActivos
                ? "SELECT * FROM CLIENTE WHERE Activo = 1"
                : "SELECT * FROM CLIENTE";

            DataTable dt = conexion.Tabla(consulta);
            grid.DataSource = dt;

            if (grid.Columns.Contains("id"))
                grid.Columns["id"].HeaderText = "ID Cliente";
        }

        /// <summary>
        /// Obtiene una tabla con todos los clientes.
        /// </summary>
        public DataTable ObtenerClientes(bool soloActivos = true)
        {
            var conexion = new ClaseConexion();
            string consulta = soloActivos
                ? "SELECT * FROM CLIENTE WHERE Activo = 1"
                : "SELECT * FROM CLIENTE";
            return conexion.Tabla(consulta);
        }

        /// <summary>
        /// Obtiene una tabla con los Número de Identidad de los clientes.
        /// </summary>
        public DataTable ObtenerNumerosIdentidad(bool soloActivos = true)
        {
            var conexion = new ClaseConexion();
            string consulta = soloActivos
                ? "SELECT NumeroIdentidad FROM CLIENTE WHERE Activo = 1"
                : "SELECT NumeroIdentidad FROM CLIENTE";
            return conexion.Tabla(consulta);
        }
    }
}
