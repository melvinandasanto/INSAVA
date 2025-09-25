using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using Usuario.Clases;

namespace Usuario
{
    public partial class FBuscarClientes : Form
    {
        private ClaseConexion _conexionDB;
        public FBuscarClientes()
        {
            InitializeComponent();
            _conexionDB = new ClaseConexion();
        }

        private void txtBuscarCliente_TextChanged(object sender, EventArgs e)
        {
            BuscarClientes(txtBuscarCliente.Text);
        }

        private void BuscarClientes(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                dgvClientes.DataSource = null;
                return;
            }

            DataTable dtClientes = new DataTable();

            // Divide el término de búsqueda en palabras
            string[] palabras = searchTerm.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Construye las condiciones dinámicamente
            var conditions = new List<string>();
            var parametros = new List<SqlParameter>();

            for (int i = 0; i < palabras.Length; i++)
            {
                // Busca cada palabra en NombreCompleto o Telefono
                conditions.Add($"(IDCliente LIKE @param{i} OR NombreCompleto LIKE @param{i} OR Telefono LIKE @param{i})");
                parametros.Add(new SqlParameter($"@param{i}", SqlDbType.NVarChar) { Value = "%" + palabras[i] + "%" });
            }

            string whereClause = string.Join(" AND ", conditions);
            string query = $"SELECT * FROM VISTAFCLIENTE WHERE {whereClause}";

            try
            {
                dtClientes = _conexionDB.Tabla(query, parametros.ToArray());
                dgvClientes.DataSource = dtClientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar clientes: " + ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                DiseñoGlobal.AplicarEstiloDataGridView(dgvClientes, menu.temaActual);
            }
            else
            {
                DiseñoGlobal.AplicarEstiloDataGridView(dgvClientes, DiseñoGlobal.TemaLight);
            }
        }

        private void FBuscarClientes_Load(object sender, EventArgs e)
        {

        }
    }
}