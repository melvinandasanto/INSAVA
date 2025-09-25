-- Script de creaci�n de la base de datos y todas las tablas ordenadas por dependencias
use master 
go
CREATE DATABASE SISTEMASEMILLA;
GO
USE SISTEMASEMILLA;
GO

-- 1. Cat�logos b�sicos
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

-- 2. Geograf�a y direcci�n
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
('Atl�ntida'), ('Col�n'), ('Comayagua'), ('Cop�n'),
('Cort�s'), ('Choluteca'), ('El Para�so'), ('Francisco Moraz�n'), ('Gracias a Dios'), ('Intibuc�'),
('Islas de la Bah�a'), ('La Paz'), ('Lempira'), ('Ocotepeque'), ('Olancho'),
('Santa B�rbara'), ('Valle'), ('Yoro');
GO

INSERT INTO MUNICIPIO (NombreMunicipio, IDDepartamento) VALUES
  /* Atl�ntida (ID = 1) */
  ('La Ceiba', 1), ('El Porvenir', 1), ('Esparta', 1), ('Jutiapa', 1), ('La Masica', 1), ('San Francisco', 1), ('Tela', 1), ('Arizona', 1),

  /* Col�n (ID = 2) */
  ('Trujillo', 2), ('Balfate', 2), ('Iriona', 2), ('Lim�n', 2), ('Sab�', 2), ('Santa Fe', 2), ('Santa Rosa de Agu�n', 2), ('Sonaguera', 2), ('Tocoa', 2), ('Bonito Oriental', 2),

  /* Comayagua (ID = 3) */
  ('Comayagua', 3), ('Ajuterique', 3), ('El Rosario', 3), ('Esqu�as', 3), ('Humuya', 3), ('La Libertad', 3), ('Laman�', 3), ('La Trinidad', 3), ('Lejaman�', 3), ('Me�mbar', 3), ('Minas de Oro', 3), ('Ojos de Agua', 3), ('San Jer�nimo', 3), ('San Jos� de Comayagua', 3), ('San Jos� del Potrero', 3), ('San Luis', 3), ('San Sebasti�n', 3), ('Siguatepeque', 3), ('Villa de San Antonio', 3), ('Las Lajas', 3), ('Taulab�', 3),

  /* Cop�n (ID = 4) */
  ('Santa Rosa de Cop�n', 4), ('Caba�as', 4), ('Concepci�n', 4), ('Cop�n Ruinas', 4), ('Corqu�n', 4), ('Cucuyagua', 4), ('Dolores', 4), ('Dulce Nombre', 4), ('El Para�so', 4), ('Florida', 4), ('La Jigua', 4), ('La Uni�n', 4), ('Nueva Arcadia', 4), ('San Agust�n', 4), ('San Antonio', 4), ('San Jer�nimo', 4), ('San Jos�', 4), ('San Juan de Opoa', 4), ('San Nicol�s', 4), ('San Pedro', 4),  ('Santa Rita', 4), ('Trinidad de Cop�n', 4), ('Veracruz', 4),

  /* Cort�s (ID = 5) */
  ('San Pedro Sula', 5), ('Choloma', 5), ('Omoa', 5), ('Pimienta', 5), ('Potrerillos', 5), ('Puerto Cort�s', 5), ('San Antonio de Cort�s', 5), ('San Francisco de Yojoa', 5), ('San Manuel', 5), ('Santa Cruz de Yojoa', 5), ('Villanueva', 5), ('La Lima', 5),

  /* Choluteca (ID = 6) */
  ('Choluteca', 6), ('Apacilagua', 6), ('Concepci�n de Mar�a', 6), ('Duyure', 6), ('El Corpus', 6), ('El Triunfo', 6), ('Marcovia', 6), ('Morolica', 6), ('Namasig�e', 6), ('Orocuina', 6), ('Pespire', 6), ('San Antonio de Flores', 6), ('San Isidro', 6), ('San Jos�', 6), ('San Marcos de Col�n', 6), ('Santa Ana de Yusguare', 6),

  /* El Para�so (ID = 7) */
  ('Yuscar�n', 7), ('Alauca', 7), ('Danl�', 7), ('El Para�so', 7), ('G�inope', 7), ('Jacaleapa', 7), ('Liure', 7), ('Morocel�', 7), ('Oropol�', 7), ('Potrerillos', 7), ('San Antonio de Flores', 7), ('San Lucas', 7), ('San Mat�as', 7), ('Soledad', 7), ('Teupasenti', 7), ('Texiguat', 7), ('Vado Ancho', 7), ('Yauyupe', 7), ('Trojes', 7),

  /* Francisco Moraz�n (ID = 8) */
  ('Distrito Central', 8), ('Alubar�n', 8), ('Cedros', 8), ('Curar�n', 8), ('El Porvenir', 8), ('Guaimaca', 8), ('La Libertad', 8), ('La Venta', 8), ('Lepaterique', 8), ('Maraita', 8), ('Marale', 8), ('Nueva Armenia', 8), ('Ojojona', 8), ('Orica', 8), ('Reitoca', 8), ('Sabanagrande', 8), ('San Antonio de Oriente', 8), ('San Buenaventura', 8), ('San Ignacio', 8), ('San Juan de Flores', 8), ('San Miguelito', 8), ('Santa Ana', 8), ('Santa Luc�a', 8), ('Talanga', 8), ('Tatumbla', 8), ('Valle de �ngeles', 8), ('Villa de San Francisco', 8), ('Vallecillo', 8),

  /* Gracias a Dios (ID = 9) */
  ('Puerto Lempira', 9), ('Brus Laguna', 9), ('Ahuas', 9), ('Juan Francisco Bulnes', 9), ('Ram�n Villeda Morales', 9), ('Wampusirpe', 9),

  /* Intibuc� (ID = 10) */
  ('La Esperanza', 10), ('Camasca', 10), ('Colomoncagua', 10), ('Concepci�n', 10), ('Dolores', 10), ('Intibuc�', 10), ('Jes�s de Otoro', 10), ('Magdalena', 10), ('Masaguara', 10), ('San Antonio', 10), ('San Isidro', 10), ('San Juan', 10),  ('San Marcos de la Sierra', 10), ('San Miguel Guancapla', 10), ('Santa Luc�a', 10), ('Yamaranguila', 10), ('San Francisco de Opalaca', 10),

  /* Islas de la Bah�a (ID = 11) */
  ('Roat�n', 11), ('Guanaja', 11), ('Jos� Santos Guardiola', 11), ('Utila', 11),

  /* La Paz (ID = 12) */
  ('La Paz', 12), ('Aguanqueterique', 12), ('Caba�as', 12), ('Cane', 12), ('Chinacla', 12), ('Guajiquiro', 12), ('Lauterique', 12), ('Marcala', 12), ('Mercedes de Oriente', 12), ('Opatoro', 12), ('San Antonio del Norte', 12), ('San Jos�', 12), ('San Juan', 12), ('San Pedro de Tutule', 12), ('Santa Ana', 12), ('Santa Elena', 12), ('Santa Mar�a', 12), ('Santiago de Puringla', 12), ('Yarula', 12),

  /* Lempira (ID = 13) */
  ('Gracias', 13),
  ('Bel�n', 13),
  ('Candelaria', 13),
  ('Cololaca', 13),
  ('Erandique', 13),
  ('Gualcince', 13),
  ('Guarita', 13),
  ('La Campa', 13),
  ('La Iguala', 13),
  ('Las Flores', 13),
  ('La Uni�n', 13),
  ('La Virtud', 13),
  ('Lepaera', 13),
  ('Mapulaca', 13),
  ('Piraera', 13),
  ('San Andr�s', 13),
  ('San Francisco', 13),
  ('San Juan Guarita', 13),
  ('San Manuel Colohete', 13),
  ('San Rafael', 13),
  ('San Sebasti�n', 13),
  ('Santa Cruz', 13),
  ('Talgua', 13),
  ('Tambla', 13),
  ('Tomal�', 13),
  ('Valladolid', 13),
  ('Virginia', 13),
  ('San Marcos de Caiqu�n', 13),

  /* Ocotepeque (ID = 14) */
  ('Nueva Ocotepeque', 14),
  ('Bel�n Gualcho', 14),
  ('Concepci�n', 14),
  ('Dolores Merend�n', 14),
  ('Fraternidad', 14),
  ('La Encarnaci�n', 14),
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
  ('Dulce Nombre de Culm�', 15),
  ('El Rosario', 15),
  ('Esquipulas del Norte', 15),
  ('Gualaco', 15),
  ('Guarizama', 15),
  ('Guata', 15),
  ('Guayape', 15),
  ('Jano', 15),
  ('La Uni�n', 15),
  ('Mangulile', 15),
  ('Manto', 15),
  ('Salam�', 15),
  ('San Esteban', 15),
  ('San Francisco de Becerra', 15),
  ('San Francisco de la Paz', 15),
  ('Santa Mar�a del Real', 15),
  ('Silca', 15),
  ('Yoc�n', 15),
  ('Patuca', 15),

  /* Santa B�rbara (ID = 16) */
  ('Santa B�rbara', 16),
  ('Arada', 16),
  ('Atima', 16),
  ('Azacualpa', 16),
  ('Ceguaca', 16),
  ('San Jos� de las Colinas', 16),
  ('Concepci�n del Norte', 16),
  ('Concepci�n del Sur', 16),
  ('Chinda', 16),
  ('El N�spero', 16),
  ('Gualala', 16),
  ('Ilama', 16),
  ('Macuelizo', 16),
  ('Naranjito', 16),
  ('Nuevo Celilac', 16),
  ('Petoa', 16),
  ('Protecci�n', 16),
  ('Quimist�n', 16),
  ('San Francisco de Ojuera', 16),
  ('San Luis', 16),
  ('San Marcos', 16),
  ('San Nicol�s', 16),
  ('San Pedro Zacapa', 16),
  ('Santa Rita', 16),
  ('San Vicente Centenario', 16),
  ('Trinidad', 16),
  ('Las Vegas', 16),
  ('Nueva Frontera', 16),

  /* Valle (ID = 17) */
  ('Nacaome', 17), ('Alianza', 17), ('Amapala', 17), ('Aramecina', 17), ('Caridad', 17), ('Goascor�n', 17), ('Langue', 17), ('San Francisco de Coray', 17), ('San Lorenzo', 17),

  /* Yoro (ID = 18) */
  ('Yoro', 18), ('Arenal', 18), ('El Negrito', 18), ('El Progreso', 18), ('Joc�n', 18), ('Moraz�n', 18), ('Olanchito', 18), ('Santa Rita', 18), ('Sulaco', 18), ('Victoria', 18), ('Yorito', 18)
;
GO


INSERT INTO TIPO_ORIGEN_SEMILLA (NombreOrigen) VALUES
('Stock'),
('Cliente');
GO

INSERT INTO METODO_PAGO (NombreMetodo)
VALUES
  ('Contado'),
  ('Cr�dito');
GO

INSERT INTO TIPO_TRANSACCION (NombreTipo) VALUES
('Venta de producto'),
('Maquila de plantulas'),
('Cr�dito / Cuenta'),
('Maquila');
GO

--PRUEBA INSERCIONES

Insert into USUARIO(NumeroIdentidad, PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, Clave, IDRol) 
values ('0318200601618', 'Melvin', 'Adan', 'Santos', 'Claros', 'melvinandasanto', 1),
('0801200618294', 'Juan', 'Daniel','Valverde','Elvir','juandval10',1),
('0101200601152','Christian','Jose','Lara','Rojas','christianjlara25',2),
('0318200502399','Oscar','Fernando','Vasquez','Fiallos','nosemeocurre',1);
GO