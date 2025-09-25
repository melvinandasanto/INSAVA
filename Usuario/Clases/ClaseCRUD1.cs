using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms; // Agregar esta línea para importar el espacio de nombres necesario

namespace Usuario.Clases
{
    public class CRUD
    {
        private string _tabla;
        private ClaseConexion _conexion;

        public CRUD(string tabla, ClaseConexion conexion)
        {
            _tabla = tabla;
            _conexion = conexion;
        }

        /// <summary>
        /// Devuelve true si existe un registro con el ID indicado.
        /// </summary>
        public bool BuscarPorId(string idField, int id)
        {
            string sql = $"SELECT * FROM {_tabla} WHERE {idField} = @id";

            SqlParameter[] parametros =
            {
                new SqlParameter("@id", SqlDbType.Int) { Value = id }
            };

            var tabla = _conexion.Tabla(sql, parametros);
            return tabla.Rows.Count > 0;
        }

        /// <summary>
        /// Devuelve true si existe un registro que cumpla el campo indicado.
        /// </summary>
        public bool BuscarPorCampo(string campo, string valor)
        {
            string sql = $"SELECT * FROM {_tabla} WHERE {campo} = @valor";

            SqlParameter[] parametros =
            {
                new SqlParameter("@valor", SqlDbType.VarChar) { Value = valor }
            };

            var tabla = _conexion.Tabla(sql, parametros);
            return tabla.Rows.Count > 0;
        }

        /// <summary>
        /// Devuelve una sola fila (DataRow) si existe un registro que cumpla el campo indicado.
        /// </summary>
        public DataRow BuscarRegistroPorCampo(string campo, string valor)
        {
            string sql = $"SELECT * FROM {_tabla} WHERE {campo} = @valor";

            SqlParameter[] parametros =
            {
                new SqlParameter("@valor", SqlDbType.VarChar) { Value = valor }
            };

            var tabla = _conexion.Tabla(sql, parametros);

            if (tabla.Rows.Count > 0)
                return tabla.Rows[0];
            else
                return null;
        }

        /// <summary>
        /// Devuelve una sola fila (DataRow) si existe un registro con el ID indicado.
        /// </summary>
        public DataRow BuscarRegistroPorId(string idField, int id)
        {
            string sql = $"SELECT * FROM {_tabla} WHERE {idField} = @id";

            var parametros = new[]
            {
        new SqlParameter("@id", SqlDbType.Int) { Value = id }
    };

            DataTable dt = _conexion.Tabla(sql, parametros);

            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }


        /// <summary>
        /// Inserta un registro usando parámetros.
        /// </summary>
        public bool Insertar(Dictionary<string, object> campos)
        {
            var columnas = string.Join(", ", campos.Keys);
            var parametros = string.Join(", ", campos.Keys.Select(k => "@" + k));

            string sql = $"INSERT INTO {_tabla} ({columnas}) VALUES ({parametros})";

            var parametrosLista = campos.Select(kv =>
                new SqlParameter("@" + kv.Key, kv.Value ?? DBNull.Value)
            ).ToArray();

            return _conexion.EjecutarSQL(sql, parametrosLista);
        }

        /// <summary>
        /// Edita un registro existente por ID usando parámetros.
        /// </summary>
        public bool Editar(string idField, int id, Dictionary<string, object> campos)
        {
            try
            {
                var setClauses = new List<string>();
                var parametros = new List<SqlParameter>();

                foreach (var campo in campos)
                {
                    setClauses.Add($"{campo.Key} = @{campo.Key}");
                    parametros.Add(new SqlParameter($"@{campo.Key}", campo.Value ?? DBNull.Value));
                }

                string setSql = string.Join(", ", setClauses);
                string sql = $"UPDATE {_tabla} SET {setSql} WHERE {idField} = @id";

                parametros.Add(new SqlParameter("@id", id));

                var conexion = _conexion;
                int filasAfectadas = conexion.EjecutarSQLConFilas(sql, parametros.ToArray());

                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar: " + ex.Message); // Esto ahora funcionará correctamente
                return false;
            }
        }


        /// <summary>
        /// Elimina un registro por ID usando parámetros.
        /// </summary>
        public bool Eliminar(string idField, int id)
        {
            string sql = $"DELETE FROM {_tabla} WHERE {idField} = @id";

            SqlParameter[] parametros =
            {
                new SqlParameter("@id", id)
            };

            return _conexion.EjecutarSQL(sql, parametros);
        }

        internal bool Editar(string idField, string id, Dictionary<string, object> campos)
        {
            throw new NotImplementedException();
        }
    }
}