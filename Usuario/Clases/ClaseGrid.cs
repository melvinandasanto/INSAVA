using System.Data;
using Usuario.Clases;
using System.Data.SqlClient;

namespace Usuario.Clases
{
    public class GRID
    {
        private ClaseConexion _conexion;

        public GRID(ClaseConexion conexion)
        {
            _conexion = conexion;
        }

        // Devuelve todos los registros de la tabla indicada
        public DataTable Listar(string nombreTabla)
        {
            string sql = $"SELECT * FROM {nombreTabla}";
            return _conexion.Tabla(sql);
        }
    }
}
