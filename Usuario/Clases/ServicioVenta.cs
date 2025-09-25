using System;
using System.Data;
using System.Data.SqlClient;

namespace Usuario.Clases
{
    public static class ServicioVenta
    {
        public static void RegistrarVenta(DataTable detalle, int idCliente, int idMetodoPago, ClaseConexion conexion)
        {
            if (detalle == null || detalle.Rows.Count == 0)
                throw new Exception("No hay detalles de venta.");

            // 1. Crear una única transacción (idTipoTransaccion = 1 por defecto)
            string sqlTrans = "INSERT INTO TRANSACCION (IDCliente, FechaEntrada, IDMetodoPago, IDTipoTransaccion) VALUES (@IDCliente, @Fecha, @IDMetodoPago, 1); SELECT SCOPE_IDENTITY();";
            SqlParameter[] parametrosTrans = {
        new SqlParameter("@IDCliente", idCliente),
        new SqlParameter("@Fecha", DateTime.Now),
        new SqlParameter("@IDMetodoPago", idMetodoPago)
    };
            int idTransaccion = conexion.EjecutarSQLConFilas(sqlTrans, parametrosTrans);

            // 2. Procesar cada fila del detalle
            foreach (DataRow row in detalle.Rows)
            {
                string tipoOperacion = row.Table.Columns.Contains("TipoOperacion") ? row["TipoOperacion"].ToString() : "Venta";

                if (tipoOperacion == "Venta")
                {
                    int idProducto = Convert.ToInt32(row["IDProducto"]);
                    decimal cantidad = Convert.ToDecimal(row["Cantidad"]);
                    decimal total = row.Table.Columns.Contains("Subtotal") ? Convert.ToDecimal(row["Subtotal"]) : 0;

                    // Insertar en VENTA_PRODUCTO
                    string sqlVenta = "INSERT INTO VENTA_PRODUCTO (IDTransaccion, IDProducto, CantidadVendida, TotalVenta) VALUES (@IDTransaccion, @IDProducto, @Cantidad, @Total)";
                    SqlParameter[] parametrosVenta = {
                new SqlParameter("@IDTransaccion", idTransaccion),
                new SqlParameter("@IDProducto", idProducto),
                new SqlParameter("@Cantidad", cantidad),
                new SqlParameter("@Total", total)
            };
                    conexion.EjecutarSQL(sqlVenta, parametrosVenta);

                    // Registrar movimiento de salida
                    string sqlMov = "INSERT INTO MOVIMIENTO_PRODUCTO (IDProducto, IDTipoMovimiento, CantidadMovida, FechaMovimiento, Descripcion, IDTransaccion) VALUES (@IDProducto, 2, @Cantidad, @Fecha, @Descripcion, @IDTransaccion)";
                    SqlParameter[] parametrosMov = {
                new SqlParameter("@IDProducto", idProducto),
                new SqlParameter("@Cantidad", cantidad),
                new SqlParameter("@Fecha", DateTime.Now),
                new SqlParameter("@Descripcion", "Venta de producto"),
                new SqlParameter("@IDTransaccion", idTransaccion)
            };
                    conexion.EjecutarSQL(sqlMov, parametrosMov);

                    // Actualizar stock
                    string sqlStock = "UPDATE PRODUCTO SET Cantidad = Cantidad - @Cantidad WHERE IDProducto = @IDProducto";
                    SqlParameter[] parametrosStock = {
                new SqlParameter("@Cantidad", cantidad),
                new SqlParameter("@IDProducto", idProducto)
            };
                    conexion.EjecutarSQL(sqlStock, parametrosStock);
                }
                else if (tipoOperacion == "Maquila")
                {
                    int? idProductoNullable = row.Table.Columns.Contains("IDProducto") && row["IDProducto"] != DBNull.Value ? (int?)Convert.ToInt32(row["IDProducto"]) : null;
                    object idProductoValue = idProductoNullable.HasValue ? (object)idProductoNullable.Value : DBNull.Value;

                    decimal cantidadMaquilada = Convert.ToDecimal(row["Cantidad"]);
                    decimal precioPorUnidad = Convert.ToDecimal(row["PrecioUnitario"]);

                    string sqlMaquila = "INSERT INTO MAQUILA_SEMILLA (IDTransaccion, OrigenSemilla, IDProducto, CantidadMaquilada, PrecioPorUnidad, FechaInicio, FechaEntrega) VALUES (@IDTransaccion, @OrigenSemilla, @IDProducto, @CantidadMaquilada, @PrecioPorUnidad, @FechaInicio, @FechaEntrega)";
                    SqlParameter[] parametrosMaquila = {
                new SqlParameter("@IDTransaccion", idTransaccion),
                new SqlParameter("@OrigenSemilla", "Cliente"),
                new SqlParameter("@IDProducto", idProductoValue),
                new SqlParameter("@CantidadMaquilada", cantidadMaquilada),
                new SqlParameter("@PrecioPorUnidad", precioPorUnidad),
                new SqlParameter("@FechaInicio", DateTime.Now),
                new SqlParameter("@FechaEntrega", DateTime.Now)
            };
                    conexion.EjecutarSQL(sqlMaquila, parametrosMaquila);
                }
            }
        }

    }
}