using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Usuario;
using Usuario.Clases;

public class ClasePROVEEDOR
{
    private int _idProveedor;
    private string _nombreProveedor;
    private string _telefonoProveedor; // Nuevo campo
    private bool _activo;

    private CRUD crud;

    public ClasePROVEEDOR()
    {
        Reiniciar();
        var conexion = new ClaseConexion();
        crud = new CRUD("PROVEEDOR", conexion);
    }

    public int IDProveedor
    {
        get => _idProveedor;
        set => _idProveedor = value;
    }

    public string NombreProveedor
    {
        get => _nombreProveedor;
        set => _nombreProveedor = value;
    }

    public string TelefonoProveedor // Propiedad nueva
    {
        get => _telefonoProveedor;
        set => _telefonoProveedor = value;
    }

    public bool Activo
    {
        get => _activo;
        set => _activo = value;
    }

    public void Reiniciar()
    {
        _idProveedor = 0;
        _nombreProveedor = string.Empty;
        _telefonoProveedor = string.Empty; // Reiniciar
        _activo = true;
    }

    public bool Guardar()
    {
        var campos = new Dictionary<string, object>
        {
            ["NombreProveedor"] = _nombreProveedor,
            ["TelefonoProveedor"] = _telefonoProveedor, // Nuevo campo
            ["Activo"] = _activo ? 1 : 0
        };

        return crud.Insertar(campos);
    }

    public bool Editar()
    {
        if (_idProveedor == 0)
            throw new InvalidOperationException("Debe especificar el ID del proveedor para editar.");

        var campos = new Dictionary<string, object>
        {
            ["NombreProveedor"] = _nombreProveedor,
            ["TelefonoProveedor"] = _telefonoProveedor, // Nuevo campo
            ["Activo"] = _activo ? 1 : 0
        };

        return crud.Editar("IDProveedor", _idProveedor, campos);
    }

    public bool Eliminar()
    {
        if (_idProveedor == 0)
            throw new InvalidOperationException("Debe especificar el ID del proveedor para eliminar.");

        var campos = new Dictionary<string, object>
        {
            ["Activo"] = 0
        };

        return crud.Editar("IDProveedor", _idProveedor, campos);
    }

    public bool BuscarPorId(int id)
    {
        var row = crud.BuscarRegistroPorId("IDProveedor", id);
        if (row != null)
        {
            _idProveedor = Convert.ToInt32(row["IDProveedor"]);
            _nombreProveedor = row["NombreProveedor"].ToString();
            _telefonoProveedor = row.Table.Columns.Contains("TelefonoProveedor") && row["TelefonoProveedor"] != DBNull.Value
                ? row["TelefonoProveedor"].ToString()
                : string.Empty;
            _activo = Convert.ToBoolean(row["Activo"]);
            return true;
        }
        return false;
    }

    public bool ExistePorNombre(string nombre)
    {
        return crud.BuscarPorCampo("NombreProveedor", nombre);
    }

    public ClasePROVEEDOR BuscarPorNombre(string nombre)
    {
        var row = crud.BuscarRegistroPorCampo("NombreProveedor", nombre);
        if (row != null)
        {
            var proveedor = new ClasePROVEEDOR
            {
                IDProveedor = Convert.ToInt32(row["IDProveedor"]),
                NombreProveedor = row["NombreProveedor"].ToString(),
                TelefonoProveedor = row.Table.Columns.Contains("TelefonoProveedor") && row["TelefonoProveedor"] != DBNull.Value
                    ? row["TelefonoProveedor"].ToString()
                    : string.Empty,
                Activo = Convert.ToBoolean(row["Activo"])
            };
            return proveedor;
        }
        return null;
    }

    public void CargarProveedores(DataGridView grid, bool soloActivos = true)
    {
        var conexion = new ClaseConexion();
        string consulta = soloActivos
            ? "SELECT * FROM PROVEEDOR WHERE Activo = 1"
            : "SELECT * FROM PROVEEDOR";

        var dt = conexion.Tabla(consulta);
        grid.DataSource = dt;

        if (grid.Columns.Contains("IDProveedor"))
            grid.Columns["IDProveedor"].HeaderText = "ID Proveedor";
        if (grid.Columns.Contains("NombreProveedor"))
            grid.Columns["NombreProveedor"].HeaderText = "Nombre del Proveedor";
        if (grid.Columns.Contains("TelefonoProveedor"))
            grid.Columns["TelefonoProveedor"].HeaderText = "Teléfono";
    }

    public DataTable ObtenerProveedores(bool soloActivos = true)
    {
        var conexion = new ClaseConexion();
        string consulta = soloActivos
            ? "SELECT * FROM PROVEEDOR WHERE Activo = 1"
            : "SELECT * FROM PROVEEDOR";
        return conexion.Tabla(consulta);
    }
}
