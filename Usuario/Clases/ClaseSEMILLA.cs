using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Usuario.Clases;

namespace Usuario
{
    /// <summary>
    /// Representa una semilla del sistema y proporciona utilidades para manipular semillas.
    /// </summary>
    public class ClaseSEMILLA
    {
        private int _idSemilla;
        private string _tipoFruto;
        private string _variedad;
        private decimal _precioPorSemilla;
        private int _idSemillero;
        private int? _idProveedor;
        private decimal? _porcentajeGerminacion;
        private decimal? _porcentajeGanancia;
        private bool _activo;

        private CRUD crud;

        public ClaseSEMILLA()
        {
            Reiniciar();
            var conexion = new ClaseConexion();
            crud = new CRUD("SEMILLA", conexion);
        }

        public int IDSemilla
        {
            get => _idSemilla;
            set => _idSemilla = value;
        }

        public string TipoFruto
        {
            get => _tipoFruto;
            set => _tipoFruto = value;
        }

        public string Variedad
        {
            get => _variedad;
            set => _variedad = value;
        }

        public decimal PrecioPorSemilla
        {
            get => _precioPorSemilla;
            set => _precioPorSemilla = value;
        }

        public int IDSemillero
        {
            get => _idSemillero;
            set => _idSemillero = value;
        }

        public int? IDProveedor
        {
            get => _idProveedor;
            set => _idProveedor = value;
        }

        public decimal? PorcentajeGerminacion
        {
            get => _porcentajeGerminacion;
            set => _porcentajeGerminacion = value;
        }

        public decimal? PorcentajeGanancia
        {
            get => _porcentajeGanancia;
            set => _porcentajeGanancia = value;
        }

        public bool Activo
        {
            get => _activo;
            set => _activo = value;
        }

        /// <summary>
        /// Reinicia los valores de la semilla.
        /// </summary>
        public void Reiniciar()
        {
            _idSemilla = 0;
            _tipoFruto = string.Empty;
            _variedad = string.Empty;
            _precioPorSemilla = 0;
            _idSemillero = 0;
            _idProveedor = null;
            _porcentajeGerminacion = null;
            _porcentajeGanancia = null;
            _activo = true;
        }

        /// <summary>
        /// Guarda una nueva semilla.
        /// </summary>
        public bool Guardar()
        {
            var campos = new Dictionary<string, object>
            {
                ["TipoFruto"] = _tipoFruto,
                ["Variedad"] = _variedad,
                ["PrecioPorSemilla"] = _precioPorSemilla,
                ["IDSemillero"] = _idSemillero,
                ["IDProveedor"] = _idProveedor.HasValue ? (object)_idProveedor : DBNull.Value,
                ["PorcentajeGerminacion"] = _porcentajeGerminacion.HasValue ? (object)_porcentajeGerminacion : DBNull.Value,
                ["PorcentajeGanancia"] = _porcentajeGanancia.HasValue ? (object)_porcentajeGanancia : DBNull.Value,
                ["Activo"] = _activo ? 1 : 0
            };

            return crud.Insertar(campos);
        }

        /// <summary>
        /// Edita una semilla existente.
        /// </summary>
        public bool Editar()
        {
            if (_idSemilla == 0)
                throw new InvalidOperationException("Debe especificar el ID de la semilla para editar.");

            var campos = new Dictionary<string, object>
            {
                ["TipoFruto"] = _tipoFruto,
                ["Variedad"] = _variedad,
                ["PrecioPorSemilla"] = _precioPorSemilla,
                ["IDSemillero"] = _idSemillero,
                ["IDProveedor"] = _idProveedor.HasValue ? (object)_idProveedor : DBNull.Value,
                ["PorcentajeGerminacion"] = _porcentajeGerminacion.HasValue ? (object)_porcentajeGerminacion : DBNull.Value,
                ["PorcentajeGanancia"] = _porcentajeGanancia.HasValue ? (object)_porcentajeGanancia : DBNull.Value,
                ["Activo"] = _activo ? 1 : 0
            };

            return crud.Editar("IDSemilla", _idSemilla, campos);
        }

        /// <summary>
        /// Elimina una semilla (borrado lógico).
        /// </summary>
        public bool Eliminar()
        {
            if (_idSemilla == 0)
                throw new InvalidOperationException("Debe especificar el ID de la semilla para eliminar.");

            var campos = new Dictionary<string, object>
            {
                ["Activo"] = 0
            };

            return crud.Editar("IDSemilla", _idSemilla, campos);
        }

        /// <summary>
        /// Busca una semilla por ID.
        /// </summary>
        public bool BuscarPorId(int id)
        {
            var row = crud.BuscarRegistroPorId("IDSemilla", id);
            if (row != null)
            {
                _idSemilla = Convert.ToInt32(row["IDSemilla"]);
                _tipoFruto = row["TipoFruto"].ToString();
                _variedad = row["Variedad"].ToString();
                _precioPorSemilla = Convert.ToDecimal(row["PrecioPorSemilla"]);
                _idSemillero = Convert.ToInt32(row["IDSemillero"]);
                _idProveedor = row["IDProveedor"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["IDProveedor"]);
                _porcentajeGerminacion = row["PorcentajeGerminacion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(row["PorcentajeGerminacion"]);
                _porcentajeGanancia = row["PorcentajeGanancia"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(row["PorcentajeGanancia"]);
                _activo = Convert.ToBoolean(row["Activo"]);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Llena un DataGridView con las semillas.
        /// </summary>
        public void CargarSemillas(DataGridView grid, bool soloActivas = true)
        {
            var conexion = new ClaseConexion();
            string consulta = soloActivas
                ? "SELECT * FROM SEMILLA WHERE Activo = 1"
                : "SELECT * FROM SEMILLA";

            var dt = conexion.Tabla(consulta);
            grid.DataSource = dt;

            if (grid.Columns.Contains("IDSemilla"))
                grid.Columns["IDSemilla"].HeaderText = "ID Semilla";
        }

        /// <summary>
        /// Obtiene las semillas.
        /// </summary>
        public DataTable ObtenerSemillas(bool soloActivas = true)
        {
            var conexion = new ClaseConexion();
            string consulta = soloActivas
                ? "SELECT * FROM SEMILLA WHERE Activo = 1"
                : "SELECT * FROM SEMILLA";
            return conexion.Tabla(consulta);
        }

        /// <summary>
        /// Crea una copia superficial de la semilla.
        /// </summary>
        public ClaseSEMILLA Clonar()
        {
            return (ClaseSEMILLA)this.MemberwiseClone();
        }

        /// <summary>
        /// Compara esta semilla con otra por ID.
        /// </summary>
        public bool EsIgual(ClaseSEMILLA otra)
        {
            if (otra == null) return false;
            return this.IDSemilla == otra.IDSemilla;
        }

        /// <summary>
        /// Valida si la semilla tiene los datos mínimos requeridos.
        /// </summary>
        public bool EsValida()
        {
            return !string.IsNullOrWhiteSpace(TipoFruto) && PrecioPorSemilla >= 0 && IDSemillero > 0;
        }

        /// <summary>
        /// Obtiene una lista de semillas filtradas por variedad.
        /// </summary>
        public static List<ClaseSEMILLA> FiltrarPorVariedad(List<ClaseSEMILLA> semillas, string variedad)
        {
            return semillas?.FindAll(s => s.Variedad?.IndexOf(variedad, StringComparison.OrdinalIgnoreCase) >= 0) ?? new List<ClaseSEMILLA>();
        }
    }
}
