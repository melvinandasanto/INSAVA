using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Usuario.Clases
{
    public class ClaseBorrado
    {
        private ClaseConexion _conexion;

        public ClaseBorrado(ClaseConexion conexion)
        {
            _conexion = conexion;
        }

        /// <summary>
        /// Elimina un registro según las reglas de borrado lógico o físico.
        /// </summary>
        /// <param name="tabla">Tabla a afectar.</param>
        /// <param name="idField">Campo clave primaria.</param>
        /// <param name="id">Valor del ID.</param>
        /// <param name="campoActivo">Campo de activo (puede ser null).</param>
        /// <param name="dependencias">Consultas COUNT(*) para verificar dependencias.</param>
        /// <returns>True si la operación fue exitosa, false si falló.</returns>
        public bool EliminarSegunReglas(
            string tabla,
            string idField,
            int id,
            string campoActivo,
            List<string> dependencias)
        {
            try
            {
                var crud = new CRUD(tabla, _conexion);

                var parametros = new[]
                {
                    new SqlParameter("@id", SqlDbType.Int) { Value = id }
                };

                bool tieneDependencias = false;

                // Ejecutar cada consulta para ver si existen dependencias
                foreach (var sql in dependencias)
                {
                    var nuevosParametros = new[]
                    {
        new SqlParameter("@id", SqlDbType.Int) { Value = id }
    };

                    DataTable dt = _conexion.Tabla(sql, nuevosParametros);
                    if (dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0][0]) > 0)
                    {
                        tieneDependencias = true;
                        break;
                    }
                }

                DataRow registro = crud.BuscarRegistroPorId(idField, id);

                if (registro == null)
                    return false;

                bool activo = campoActivo != null && Convert.ToBoolean(registro[campoActivo]);

                if (activo && tieneDependencias)
                {
                    // Borrado lógico
                    Dictionary<string, object> campos = new Dictionary<string, object>
                    {
                        { campoActivo, false }
                    };
                    return crud.Editar(idField, id, campos);
                }
                else if (!tieneDependencias)
                {
                    // Borrado físico si NO hay dependencias (sin importar si está activo o inactivo)
                    bool eliminado = crud.Eliminar(idField, id);
                    if (eliminado)
                        MessageBox.Show("Eliminación física realizada correctamente.");
                    else
                        MessageBox.Show("No se pudo eliminar físicamente el registro.");
                    return eliminado;
                }
                else
                {
                    // Si está inactivo pero tiene dependencias, no se puede eliminar físicamente
                    MessageBox.Show("No se puede eliminar físicamente el registro porque tiene dependencias.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar eliminar el registro: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Elimina un registro usando la lógica de la clase de entidad.
        /// </summary>
        /// <param name="entidad">Instancia de la clase de entidad (por ejemplo, ClaseCLIENTE).</param>
        /// <param name="id">ID del registro a eliminar.</param>
        /// <param name="campoActivo">Nombre del campo de activo (puede ser null).</param>
        /// <param name="dependencias">Consultas COUNT(*) para verificar dependencias.</param>
        /// <returns>True si la operación fue exitosa, false si falló.</returns>
        public bool EliminarSegunReglasEntidad(
            dynamic entidad,
            int id,
            string campoActivo,
            List<string> dependencias)
        {
            try
            {
                var parametros = new[]
                {
                    new SqlParameter("@id", SqlDbType.Int) { Value = id }
                };

                bool tieneDependencias = false;

                // Verificar dependencias externas
                foreach (var sql in dependencias)
                {
                    var nuevosParametros = new[]
                    {
        new SqlParameter("@id", SqlDbType.Int) { Value = id }
    };

                    DataTable dt = _conexion.Tabla(sql, nuevosParametros);
                    if (dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0][0]) > 0)
                    {
                        tieneDependencias = true;
                        break;
                    }
                }


                // Buscar el registro usando la clase de entidad (carga en la instancia)
                if (!entidad.BuscarPorId(id))
                    return false;

                // Accede directamente a la propiedad de la instancia
                bool activo = campoActivo != null && Convert.ToBoolean(entidad.GetType().GetProperty(campoActivo).GetValue(entidad));

                if (activo && tieneDependencias)
                {
                    // Borrado lógico usando la clase de entidad
                    entidad.GetType().GetProperty(campoActivo).SetValue(entidad, false);
                    bool editado = entidad.Editar();
                    if (editado)
                        MessageBox.Show("Borrado lógico realizado correctamente.");
                    else
                        MessageBox.Show("No se pudo realizar el borrado lógico.");
                    return editado;
                }
                else if (!tieneDependencias)
                {
                    // Borrado físico usando la clase de entidad
                    bool eliminado = entidad.Eliminar();
                    if (eliminado)
                        MessageBox.Show("Eliminación física realizada correctamente.");
                    else
                        MessageBox.Show("No se pudo eliminar físicamente el registro.");
                    return eliminado;
                }
                else
                {
                    MessageBox.Show("No se puede eliminar físicamente el registro porque tiene dependencias.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar eliminar el registro: {ex.Message}");
                return false;
            }
        }
    }
}
