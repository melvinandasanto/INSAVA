using System;
using System.Collections.Generic;
using System.Data;

namespace Usuario.Clases
{
    public static class ClaseFiltroActivo
    {
        public static DataTable FiltrarTabla(string nombreTabla, string filtro)
        {
            var tablasPermitidas = new List<string>
            {
                "CLIENTE",
                "PROVEEDOR",
                "SEMILLA",
                "INVENTARIO_PRODUCTO",
                "SEMILLERO",
                "USUARIO",
                "MOVIMIENTO_SEMILLA",
                "MOVIMIENTO_PRODUCTO",
                "TRANSACCION",
                "CUENTA_POR_COBRAR",
                "ABONO",
                "VENTA_PRODUCTO",
                "VENTA_PLANTULAS",
                "RECEPCION_SEMILLA",
                "USO_SEMILLAS",
                "PRODUCTO" // Add this line
            };

            if (!tablasPermitidas.Contains(nombreTabla.ToUpper()))
                throw new ArgumentException($"La tabla '{nombreTabla}' no está permitida.");

            var conexion = new ClaseConexion();

            string consulta;

            if (nombreTabla.ToUpper() == "USUARIO")
            {
                // Usar la vista VISTAFUSUARIO
                if (filtro == "Activos")
                    consulta = "SELECT * FROM VISTAFUSUARIO WHERE Activo = 1";
                else if (filtro == "Inactivos")
                    consulta = "SELECT * FROM VISTAFUSUARIO WHERE Activo = 0";
                else
                    consulta = "SELECT * FROM VISTAFUSUARIO";
            }
            else if (nombreTabla.ToUpper() == "CLIENTE")
            {
                // Usar la vista VISTAFCLIENTE
                if (filtro == "Activos")
                    consulta = "SELECT * FROM VISTAFCLIENTE WHERE Activo = 1";
                else if (filtro == "Inactivos")
                    consulta = "SELECT * FROM VISTAFCLIENTE WHERE Activo = 0";
                else
                    consulta = "SELECT * FROM VISTAFCLIENTE";
            }
            else
            {
                if (filtro == "Activos")
                    consulta = $"SELECT * FROM {nombreTabla} WHERE Activo = 1";
                else if (filtro == "Inactivos")
                    consulta = $"SELECT * FROM {nombreTabla} WHERE Activo = 0";
                else
                    consulta = $"SELECT * FROM {nombreTabla}";
            }

            return conexion.Tabla(consulta);
        }
    }
}
