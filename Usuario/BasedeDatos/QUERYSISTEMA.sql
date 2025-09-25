-- Script de creación de la base de datos y todas las tablas ordenadas por dependencias
use master 
go
CREATE DATABASE SISTEMASEMILLA;
GO
USE SISTEMASEMILLA;
GO

-- 1. Catálogos básicos
CREATE TABLE ROL (
    IDRol INT IDENTITY(1,1) PRIMARY KEY,
    NombreRol VARCHAR(50) NOT NULL UNIQUE
);
GO

CREATE TABLE METODO_PAGO (
    IDMetodoPago INT IDENTITY(1,1) PRIMARY KEY,
    NombreMetodo VARCHAR(50) NOT NULL
);
GO

CREATE TABLE TIPO_TRANSACCION (
    IDTipoTransaccion INT IDENTITY(1,1) PRIMARY KEY,
    NombreTipo VARCHAR(100) NOT NULL
);
GO

CREATE TABLE TIPO_MOVIMIENTO (
    IDTipoMovimiento INT IDENTITY(1,1) PRIMARY KEY,
    NombreMovimiento VARCHAR(50) NOT NULL
);
GO

CREATE TABLE TIPO_ORIGEN_SEMILLA (
    IDTipoOrigen INT IDENTITY(1,1) PRIMARY KEY,
    NombreOrigen VARCHAR(50) NOT NULL
);
GO

-- 2. Geografía y dirección
CREATE TABLE DEPARTAMENTO (
    IDDepartamento INT IDENTITY(1,1) PRIMARY KEY,
    NombreDepartamento VARCHAR(100) NOT NULL
);
GO

CREATE TABLE MUNICIPIO (
    IDMunicipio INT IDENTITY(1,1) PRIMARY KEY,
    NombreMunicipio VARCHAR(100) NOT NULL,
    IDDepartamento INT NOT NULL,
    CONSTRAINT FK_Municipio_Departamento FOREIGN KEY (IDDepartamento)
        REFERENCES DEPARTAMENTO(IDDepartamento) ON DELETE CASCADE
);
GO

-- 3. Entidades principales
CREATE TABLE CLIENTE (
    IDCliente INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    RTN VARCHAR(50) NOT NULL,
    PrimerNombre VARCHAR(50) NOT NULL,
    SegundoNombre VARCHAR(50),
    PrimerApellido VARCHAR(50) NOT NULL,
    SegundoApellido VARCHAR(50),
    NumTel VARCHAR(15) NOT NULL,
    Activo BIT NOT NULL DEFAULT 1
);
GO

CREATE TABLE DIRECCION_CLIENTE (
    IDDireccion INT IDENTITY(1,1) PRIMARY KEY,
    IDCliente INT NOT NULL,
    Calle VARCHAR(200) NOT NULL,
    IDMunicipio INT NOT NULL,
    Activo BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_Direccion_Cliente FOREIGN KEY (IDCLiente)
        REFERENCES CLIENTE(IDCliente) ON DELETE CASCADE,
    CONSTRAINT FK_Direccion_Municipio FOREIGN KEY (IDMunicipio)
        REFERENCES MUNICIPIO(IDMunicipio) ON DELETE CASCADE
);
GO

CREATE TABLE PROVEEDOR (
    IDProveedor INT IDENTITY(1,1) PRIMARY KEY,
    NombreProveedor VARCHAR(100) NOT NULL,
    TelefonoProveedor VARCHAR(50) NOT NULL,
    Activo BIT NOT NULL DEFAULT 1
);
GO

CREATE TABLE USUARIO (
    IDUsuario INT IDENTITY(1,1) PRIMARY KEY,
    NumeroIdentidad VARCHAR(15) NOT NULL UNIQUE,
    PrimerNombre VARCHAR(50) NOT NULL,
    SegundoNombre VARCHAR(50),
    PrimerApellido VARCHAR(50) NOT NULL,
    SegundoApellido VARCHAR(50),
    Clave VARCHAR(100) NOT NULL,
    IDRol INT NOT NULL,
    Activo BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_Usuario_Rol FOREIGN KEY (IDRol)
        REFERENCES ROL(IDRol) ON DELETE CASCADE
);
GO

-- 4. Inventario y productos
CREATE TABLE PRODUCTO (
    IDProducto INT IDENTITY(1,1) PRIMARY KEY,
    Categoria VARCHAR(20) NOT NULL CHECK (Categoria IN ('Semilla','Producto')),
    Nombre VARCHAR(100) NOT NULL,
    Variedad VARCHAR(50),
    Descripcion VARCHAR(MAX),
    Cantidad DECIMAL(10,2) NOT NULL,
    PrecioUnitario DECIMAL(10,2) NOT NULL,
    PorcentajeGerminacion DECIMAL(4,2) CHECK (PorcentajeGerminacion BETWEEN 0 AND 1),
    PorcentajeGanancia DECIMAL(5,2) CHECK (PorcentajeGanancia >= 0),
    IDProveedor INT NULL,
    Activo BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_Producto_Proveedor FOREIGN KEY (IDProveedor)
        REFERENCES PROVEEDOR(IDProveedor)
);
GO

-- 5. Operaciones de venta y servicio
CREATE TABLE TRANSACCION (
    IDTransaccion INT IDENTITY(1,1) PRIMARY KEY,
    IDCliente INT NOT NULL,
    FechaEntrada DATETIME NOT NULL,
    FechaSalida DATETIME NULL,
    IDMetodoPago INT NULL,
    IDTipoTransaccion INT NOT NULL,
    Activo BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_Trans_Cliente FOREIGN KEY (IDCliente) REFERENCES CLIENTE(IDCliente),
    CONSTRAINT FK_Trans_Metodo FOREIGN KEY (IDMetodoPago)
        REFERENCES METODO_PAGO(IDMetodoPago),
    CONSTRAINT FK_Trans_Tipo FOREIGN KEY (IDTipoTransaccion)
        REFERENCES TIPO_TRANSACCION(IDTipoTransaccion)
);
GO

CREATE TABLE MOVIMIENTO_PRODUCTO (
    IDMovimiento INT IDENTITY(1,1) PRIMARY KEY,
    IDProducto INT NOT NULL,
    IDTipoMovimiento INT NOT NULL,
    CantidadMovida DECIMAL(10,2) NOT NULL,
    FechaMovimiento DATETIME NOT NULL DEFAULT GETDATE(),
    Descripcion VARCHAR(MAX),
    IDTransaccion INT NULL,
    Activo BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_MovProd_Prod FOREIGN KEY (IDProducto)
        REFERENCES PRODUCTO(IDProducto),
    CONSTRAINT FK_MovProd_TipoMov FOREIGN KEY (IDTipoMovimiento)
        REFERENCES TIPO_MOVIMIENTO(IDTipoMovimiento),
    CONSTRAINT FK_MovProd_Trans FOREIGN KEY (IDTransaccion)
        REFERENCES TRANSACCION(IDTransaccion)
);
GO

CREATE TABLE VENTA_PRODUCTO (
    IDVentaProducto INT IDENTITY(1,1) PRIMARY KEY,
    IDTransaccion INT NOT NULL,
    IDProducto INT NOT NULL,
    CantidadVendida DECIMAL(10,2) NOT NULL,
    PrecioUnitario DECIMAL(10,2) NOT NULL,
    Activo BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_VentaProd_Trans FOREIGN KEY (IDTransaccion)
        REFERENCES TRANSACCION(IDTransaccion),
    CONSTRAINT FK_VentaProd_Prod FOREIGN KEY (IDProducto)
        REFERENCES PRODUCTO(IDProducto)
);
GO

CREATE TABLE MAQUILA_SEMILLA (
    IDMaquila INT IDENTITY(1,1) PRIMARY KEY,
    IDTransaccion INT NOT NULL,
    IDProducto INT NOT NULL,
    CantidadMaquilada DECIMAL(10,2) NOT NULL,
    PrecioPorUnidad DECIMAL(10,2) NOT NULL,
    Total AS (CantidadMaquilada * PrecioPorUnidad) PERSISTED,
    FechaInicio DATE NOT NULL,
    FechaEntrega DATE NOT NULL,
    Estado VARCHAR(20) NOT NULL DEFAULT 'Pendiente'
        CHECK (Estado IN ('Pendiente','En proceso','Entregado','Cancelado')),
    Observaciones VARCHAR(MAX),
    CONSTRAINT FK_Maquila_Trans FOREIGN KEY (IDTransaccion)
        REFERENCES TRANSACCION(IDTransaccion),
    CONSTRAINT FK_Maquila_Prod FOREIGN KEY (IDProducto)
        REFERENCES PRODUCTO(IDProducto)
);
GO

-- 6. Pagos, cuentas y abonos
CREATE TABLE DETALLE_PAGO (
    IDDetallePago INT IDENTITY(1,1) PRIMARY KEY,
    IDTransaccion INT NOT NULL,
    MetodoPagoDescripcion VARCHAR(100),
    ReferenciaPago VARCHAR(100),
    Banco VARCHAR(100),
    MontoPagado DECIMAL(10,2) NOT NULL,
    CONSTRAINT FK_DetPag_Trans FOREIGN KEY (IDTransaccion)
        REFERENCES TRANSACCION(IDTransaccion)
);
GO

CREATE TABLE CUENTA_POR_COBRAR (
    IDCuenta INT IDENTITY(1,1) PRIMARY KEY,
    IDTransaccion INT NOT NULL,
    MontoTotal DECIMAL(10,2) NOT NULL,
    SaldoPendiente DECIMAL(10,2) NOT NULL,
    FechaInicio DATETIME NOT NULL DEFAULT GETDATE(),
    Activo BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_CXC_Trans FOREIGN KEY (IDTransaccion)
        REFERENCES TRANSACCION(IDTransaccion)
);
GO

CREATE TABLE ABONO (
    IDAbono INT IDENTITY(1,1) PRIMARY KEY,
    IDCuenta INT NOT NULL,
    FechaAbono DATETIME NOT NULL DEFAULT GETDATE(),
    MontoAbonado DECIMAL(10,2) NOT NULL,
    Activo BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_Abono_CXC FOREIGN KEY (IDCuenta)
        REFERENCES CUENTA_POR_COBRAR(IDCuenta)
);
GO

--INSERCIONES FIJAS

INSERT INTO ROL (NombreRol) VALUES ('ADMIN'), ('EMPLEADO');
GO


INSERT INTO TIPO_MOVIMIENTO (NombreMovimiento) VALUES
('Retiro'),
('Ingreso');
GO

INSERT INTO DEPARTAMENTO (NombreDepartamento) VALUES
('Atlántida'), ('Colón'), ('Comayagua'), ('Copán'),
('Cortés'), ('Choluteca'), ('El Paraíso'), ('Francisco Morazán'), ('Gracias a Dios'), ('Intibucá'),
('Islas de la Bahía'), ('La Paz'), ('Lempira'), ('Ocotepeque'), ('Olancho'),
('Santa Bárbara'), ('Valle'), ('Yoro');
GO

INSERT INTO MUNICIPIO (NombreMunicipio, IDDepartamento) VALUES
  /* Atlántida (ID = 1) */
  ('La Ceiba', 1), ('El Porvenir', 1), ('Esparta', 1), ('Jutiapa', 1), ('La Masica', 1), ('San Francisco', 1), ('Tela', 1), ('Arizona', 1),

  /* Colón (ID = 2) */
  ('Trujillo', 2), ('Balfate', 2), ('Iriona', 2), ('Limón', 2), ('Sabá', 2), ('Santa Fe', 2), ('Santa Rosa de Aguán', 2), ('Sonaguera', 2), ('Tocoa', 2), ('Bonito Oriental', 2),

  /* Comayagua (ID = 3) */
  ('Comayagua', 3), ('Ajuterique', 3), ('El Rosario', 3), ('Esquías', 3), ('Humuya', 3), ('La Libertad', 3), ('Lamaní', 3), ('La Trinidad', 3), ('Lejamaní', 3), ('Meámbar', 3), ('Minas de Oro', 3), ('Ojos de Agua', 3), ('San Jerónimo', 3), ('San José de Comayagua', 3), ('San José del Potrero', 3), ('San Luis', 3), ('San Sebastián', 3), ('Siguatepeque', 3), ('Villa de San Antonio', 3), ('Las Lajas', 3), ('Taulabé', 3),

  /* Copán (ID = 4) */
  ('Santa Rosa de Copán', 4), ('Cabañas', 4), ('Concepción', 4), ('Copán Ruinas', 4), ('Corquín', 4), ('Cucuyagua', 4), ('Dolores', 4), ('Dulce Nombre', 4), ('El Paraíso', 4), ('Florida', 4), ('La Jigua', 4), ('La Unión', 4), ('Nueva Arcadia', 4), ('San Agustín', 4), ('San Antonio', 4), ('San Jerónimo', 4), ('San José', 4), ('San Juan de Opoa', 4), ('San Nicolás', 4), ('San Pedro', 4),  ('Santa Rita', 4), ('Trinidad de Copán', 4), ('Veracruz', 4),

  /* Cortés (ID = 5) */
  ('San Pedro Sula', 5), ('Choloma', 5), ('Omoa', 5), ('Pimienta', 5), ('Potrerillos', 5), ('Puerto Cortés', 5), ('San Antonio de Cortés', 5), ('San Francisco de Yojoa', 5), ('San Manuel', 5), ('Santa Cruz de Yojoa', 5), ('Villanueva', 5), ('La Lima', 5),

  /* Choluteca (ID = 6) */
  ('Choluteca', 6), ('Apacilagua', 6), ('Concepción de María', 6), ('Duyure', 6), ('El Corpus', 6), ('El Triunfo', 6), ('Marcovia', 6), ('Morolica', 6), ('Namasigüe', 6), ('Orocuina', 6), ('Pespire', 6), ('San Antonio de Flores', 6), ('San Isidro', 6), ('San José', 6), ('San Marcos de Colón', 6), ('Santa Ana de Yusguare', 6),

  /* El Paraíso (ID = 7) */
  ('Yuscarán', 7), ('Alauca', 7), ('Danlí', 7), ('El Paraíso', 7), ('Güinope', 7), ('Jacaleapa', 7), ('Liure', 7), ('Morocelí', 7), ('Oropolí', 7), ('Potrerillos', 7), ('San Antonio de Flores', 7), ('San Lucas', 7), ('San Matías', 7), ('Soledad', 7), ('Teupasenti', 7), ('Texiguat', 7), ('Vado Ancho', 7), ('Yauyupe', 7), ('Trojes', 7),

  /* Francisco Morazán (ID = 8) */
  ('Distrito Central', 8), ('Alubarén', 8), ('Cedros', 8), ('Curarén', 8), ('El Porvenir', 8), ('Guaimaca', 8), ('La Libertad', 8), ('La Venta', 8), ('Lepaterique', 8), ('Maraita', 8), ('Marale', 8), ('Nueva Armenia', 8), ('Ojojona', 8), ('Orica', 8), ('Reitoca', 8), ('Sabanagrande', 8), ('San Antonio de Oriente', 8), ('San Buenaventura', 8), ('San Ignacio', 8), ('San Juan de Flores', 8), ('San Miguelito', 8), ('Santa Ana', 8), ('Santa Lucía', 8), ('Talanga', 8), ('Tatumbla', 8), ('Valle de Ángeles', 8), ('Villa de San Francisco', 8), ('Vallecillo', 8),

  /* Gracias a Dios (ID = 9) */
  ('Puerto Lempira', 9), ('Brus Laguna', 9), ('Ahuas', 9), ('Juan Francisco Bulnes', 9), ('Ramón Villeda Morales', 9), ('Wampusirpe', 9),

  /* Intibucá (ID = 10) */
  ('La Esperanza', 10), ('Camasca', 10), ('Colomoncagua', 10), ('Concepción', 10), ('Dolores', 10), ('Intibucá', 10), ('Jesús de Otoro', 10), ('Magdalena', 10), ('Masaguara', 10), ('San Antonio', 10), ('San Isidro', 10), ('San Juan', 10),  ('San Marcos de la Sierra', 10), ('San Miguel Guancapla', 10), ('Santa Lucía', 10), ('Yamaranguila', 10), ('San Francisco de Opalaca', 10),

  /* Islas de la Bahía (ID = 11) */
  ('Roatán', 11), ('Guanaja', 11), ('José Santos Guardiola', 11), ('Utila', 11),

  /* La Paz (ID = 12) */
  ('La Paz', 12), ('Aguanqueterique', 12), ('Cabañas', 12), ('Cane', 12), ('Chinacla', 12), ('Guajiquiro', 12), ('Lauterique', 12), ('Marcala', 12), ('Mercedes de Oriente', 12), ('Opatoro', 12), ('San Antonio del Norte', 12), ('San José', 12), ('San Juan', 12), ('San Pedro de Tutule', 12), ('Santa Ana', 12), ('Santa Elena', 12), ('Santa María', 12), ('Santiago de Puringla', 12), ('Yarula', 12),

  /* Lempira (ID = 13) */
  ('Gracias', 13),
  ('Belén', 13),
  ('Candelaria', 13),
  ('Cololaca', 13),
  ('Erandique', 13),
  ('Gualcince', 13),
  ('Guarita', 13),
  ('La Campa', 13),
  ('La Iguala', 13),
  ('Las Flores', 13),
  ('La Unión', 13),
  ('La Virtud', 13),
  ('Lepaera', 13),
  ('Mapulaca', 13),
  ('Piraera', 13),
  ('San Andrés', 13),
  ('San Francisco', 13),
  ('San Juan Guarita', 13),
  ('San Manuel Colohete', 13),
  ('San Rafael', 13),
  ('San Sebastián', 13),
  ('Santa Cruz', 13),
  ('Talgua', 13),
  ('Tambla', 13),
  ('Tomalá', 13),
  ('Valladolid', 13),
  ('Virginia', 13),
  ('San Marcos de Caiquín', 13),

  /* Ocotepeque (ID = 14) */
  ('Nueva Ocotepeque', 14),
  ('Belén Gualcho', 14),
  ('Concepción', 14),
  ('Dolores Merendón', 14),
  ('Fraternidad', 14),
  ('La Encarnación', 14),
  ('La Labor', 14),
  ('Lucerna', 14),
  ('Mercedes', 14),
  ('San Fernando', 14),
  ('San Francisco del Valle', 14),
  ('San Jorge', 14),
  ('San Marcos', 14),
  ('Santa Fe', 14),
  ('Sensenti', 14),
  ('Sinuapa', 14),

  /* Olancho (ID = 15) */
  ('Juticalpa', 15),
  ('Campamento', 15),
  ('Catacamas', 15),
  ('Concordia', 15),
  ('Dulce Nombre de Culmí', 15),
  ('El Rosario', 15),
  ('Esquipulas del Norte', 15),
  ('Gualaco', 15),
  ('Guarizama', 15),
  ('Guata', 15),
  ('Guayape', 15),
  ('Jano', 15),
  ('La Unión', 15),
  ('Mangulile', 15),
  ('Manto', 15),
  ('Salamá', 15),
  ('San Esteban', 15),
  ('San Francisco de Becerra', 15),
  ('San Francisco de la Paz', 15),
  ('Santa María del Real', 15),
  ('Silca', 15),
  ('Yocón', 15),
  ('Patuca', 15),

  /* Santa Bárbara (ID = 16) */
  ('Santa Bárbara', 16),
  ('Arada', 16),
  ('Atima', 16),
  ('Azacualpa', 16),
  ('Ceguaca', 16),
  ('San José de las Colinas', 16),
  ('Concepción del Norte', 16),
  ('Concepción del Sur', 16),
  ('Chinda', 16),
  ('El Níspero', 16),
  ('Gualala', 16),
  ('Ilama', 16),
  ('Macuelizo', 16),
  ('Naranjito', 16),
  ('Nuevo Celilac', 16),
  ('Petoa', 16),
  ('Protección', 16),
  ('Quimistán', 16),
  ('San Francisco de Ojuera', 16),
  ('San Luis', 16),
  ('San Marcos', 16),
  ('San Nicolás', 16),
  ('San Pedro Zacapa', 16),
  ('Santa Rita', 16),
  ('San Vicente Centenario', 16),
  ('Trinidad', 16),
  ('Las Vegas', 16),
  ('Nueva Frontera', 16),

  /* Valle (ID = 17) */
  ('Nacaome', 17), ('Alianza', 17), ('Amapala', 17), ('Aramecina', 17), ('Caridad', 17), ('Goascorán', 17), ('Langue', 17), ('San Francisco de Coray', 17), ('San Lorenzo', 17),

  /* Yoro (ID = 18) */
  ('Yoro', 18), ('Arenal', 18), ('El Negrito', 18), ('El Progreso', 18), ('Jocón', 18), ('Morazán', 18), ('Olanchito', 18), ('Santa Rita', 18), ('Sulaco', 18), ('Victoria', 18), ('Yorito', 18)
;
GO


INSERT INTO TIPO_ORIGEN_SEMILLA (NombreOrigen) VALUES
('Stock'),
('Cliente');
GO

INSERT INTO METODO_PAGO (NombreMetodo)
VALUES
  ('Contado'),
  ('Crédito');
GO

INSERT INTO TIPO_TRANSACCION (NombreTipo) VALUES
('Venta de producto'),
('Maquila de plantulas'),
('Crédito / Cuenta'),
('Maquila');
GO

--PRUEBA INSERCIONES

Insert into USUARIO(NumeroIdentidad, PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, Clave, IDRol) 
values ('0318200601618', 'Melvin', 'Adan', 'Santos', 'Claros', 'melvinandasanto', 1),
('0801200618294', 'Juan', 'Daniel','Valverde','Elvir','juandval10',1),
('0101200601152','Christian','Jose','Lara','Rojas','christianjlara25',2),
('0318200502399','Oscar','Fernando','Vasquez','Fiallos','nosemeocurre',1);
GO