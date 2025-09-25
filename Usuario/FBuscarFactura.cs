using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Usuario.Clases;

namespace Usuario
{
    public partial class FBuscarFactura : Form
    {
        private ClaseConexion _conexionDB;

        public FBuscarFactura()
        {
            InitializeComponent();
            _conexionDB = new ClaseConexion("DESKTOP-CE353KH", "SISTEMASEMILLA");
            CargarFacturas("");
        }

        private void txtBuscarFactura_TextChanged(object sender, EventArgs e)
        {
            CargarFacturas(txtBuscarFactura.Text);
        }

        private void CargarFacturas(string searchTerm)
        {
            DataTable dtFacturas = new DataTable();

            string baseQuery = "SELECT NumeroFactura, FechaFactura, NombreCompletoCliente, TipoTransaccion, MetodoPago, NombreProductoDetalle, Cantidad, PrecioUnitarioVenta, SubtotalLinea FROM VISTAFactura";

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                try
                {
                    dtFacturas = _conexionDB.Tabla(baseQuery + " ORDER BY FechaFactura DESC, NumeroFactura DESC", null);
                    dgvFacturas.DataSource = dtFacturas;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar facturas: " + ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }


            string[] palabras = searchTerm.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var conditions = new List<string>();
            var parametros = new List<SqlParameter>();

            for (int i = 0; i < palabras.Length; i++)
            {
                conditions.Add($"(CAST(NumeroFactura AS VARCHAR(50)) LIKE @param{i} OR NombreCompletoCliente LIKE @param{i} OR NombreProductoDetalle LIKE @param{i} OR MetodoPago LIKE @param{i})");
                parametros.Add(new SqlParameter($"@param{i}", SqlDbType.NVarChar) { Value = "%" + palabras[i] + "%" });
            }

            string whereClause = string.Join(" AND ", conditions);
            string finalQuery = $"{baseQuery} WHERE {whereClause} ORDER BY FechaFactura DESC, NumeroFactura DESC";

            try
            {
                dtFacturas = _conexionDB.Tabla(finalQuery, parametros.ToArray());
                dgvFacturas.DataSource = dtFacturas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar facturas: " + ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Aplica el tema y formato global
            DiseñoGlobal.AplicarTema(this, DiseñoGlobal.TemaLight);
            DiseñoGlobal.AplicarFormatoBotones(this, DiseñoGlobal.TemaLight);
            // Aplica el tema actual al DataGridView si el formulario principal lo tiene
            var menu = FindForm() as FMENU;
            if (menu != null)
            {
                DiseñoGlobal.AplicarEstiloDataGridView(dgvFacturas, menu.temaActual);
            }
            else
            {
                DiseñoGlobal.AplicarEstiloDataGridView(dgvFacturas, DiseñoGlobal.TemaLight);
            }
        }
    }
}