/*+++++++++++++++++++++++++++++++++++++++
* Grupo: FEMIG							*			
*                                       *
* Integrantes:                          *
*	Emiliano Marcelo Ibarrola           *
*	Marcos Andres Ibarrola              *
*	Ignacio Angel Tata                  *
*	Fernando N. Tobares Garcia          *
*+++++++++++++++++++++++++++++++++++++++*/

/*++++++++++++++++++++++++++++++++++++++*/
/*Creacion del shema					*/
/*++++++++++++++++++++++++++++++++++++++*/
USE [GD1C2012]
GO
CREATE SCHEMA [FEMIG] AUTHORIZATION [gd]
GO

/*++++++++++++++++++++++++++++++++++++++*/
/*Creacion de tablas en la base de datos*/
/*++++++++++++++++++++++++++++++++++++++*/
CREATE TABLE GD1C2012.FEMIG.relojes ( 
	nroSerieReloj varchar(18) NOT NULL PRIMARY KEY CLUSTERED,
	marca varchar(255) NOT NULL,
	modelo varchar(255) NOT NULL,
	fechaVersion datetime NOT NULL,
	anulado bit default 0 -- 0: El reloj está activo 1: El reloj esta inhabilitado
);

CREATE TABLE GD1C2012.FEMIG.autos ( 
	patente varchar(10) NOT NULL PRIMARY KEY CLUSTERED,
	marca varchar(255) NOT NULL,
	modelo varchar(255) NOT NULL,
	licencia varchar(26) NOT NULL UNIQUE,
	rodado varchar(10) NOT NULL,
	nroSerieReloj varchar(18) NOT NULL UNIQUE FOREIGN KEY REFERENCES GD1C2012.FEMIG.relojes(nroSerieReloj),
	anulado bit default 0 -- 0: El auto está activo 1: El auto esta inhabilitado
);

CREATE TABLE GD1C2012.FEMIG.choferes ( 
	dniChofer numeric(18) NOT NULL PRIMARY KEY CLUSTERED,
	nombre varchar(255) NOT NULL,
	apellido varchar(255) NOT NULL,
	direccion varchar(255) NOT NULL,
	telefono numeric(18) NOT NULL,
	email varchar(50) UNIQUE,
	fechaNacimiento datetime NOT NULL,
	anulado bit default 0 -- 0: El chofer está activo 1: El chofer esta inhabilitado
);

CREATE TABLE GD1C2012.FEMIG.turnos ( 
	turnoID varchar(20) NOT NULL PRIMARY KEY CLUSTERED,
	horaInicio numeric(18) NOT NULL,
	horaFin numeric(18) NOT NULL,
	descripcion varchar(255) NOT NULL,
	valorFicha numeric(18,2) NOT NULL,
	valorBandera numeric(18,2) NOT NULL,
	anulado bit default 0 -- 0: El turno está activo 1: El turno esta inhabilitado
);

CREATE TABLE GD1C2012.FEMIG.ChoferAutoTurno ( 
	fecha datetime NOT NULL,
	dniChofer numeric(18) NOT NULL,
	turnoID varchar(20) NOT NULL,
	patente varchar(10),
	constraint pk_choferautoturno primary key CLUSTERED (dniChofer, turnoID),
	constraint fk_cat_chofer foreign key (dniChofer) references GD1C2012.FEMIG.choferes(dniChofer),
	constraint fk_cat_turno foreign key (turnoID) references GD1C2012.FEMIG.turnos(turnoID)
);

CREATE TABLE GD1C2012.FEMIG.clientes ( 
	dniCliente numeric(18) NOT NULL PRIMARY KEY CLUSTERED,
	nombre varchar(255) NOT NULL,
	apellido varchar(255) NOT NULL,
	telefono numeric(18) NOT NULL UNIQUE,
	direccion varchar(255) NOT NULL,
	email varchar(255) UNIQUE,
	fechaNacimiento datetime NOT NULL,
	anulado bit default 0 -- 0: El cliente está activo 1: El cliente esta inhabilitado
);

CREATE TABLE GD1C2012.FEMIG.facturas ( 
	codFactura numeric(18) NOT NULL PRIMARY KEY CLUSTERED,
	fecha_inicio datetime NOT NULL,
	fecha_fin datetime NOT NULL,
	dniCliente numeric(18) NOT NULL,
	importe_total numeric(18) NOT NULL
);

CREATE TABLE GD1C2012.FEMIG.rendicion ( 
	fecha datetime NOT NULL,
	dniChofer numeric(18) NOT NULL,
	turnoID varchar(20) NOT NULL,
	constraint pk_rendicion primary key CLUSTERED (fecha, dniChofer, turnoID),
	constraint fk_rendicion_cat foreign key (dniChofer, turnoID) references GD1C2012.FEMIG.ChoferAutoTurno(dniChofer, turnoID)
);

CREATE TABLE GD1C2012.FEMIG.viajes ( 
	viajeID numeric(18) NOT NULL PRIMARY KEY CLUSTERED,
	tipoViaje varchar(10) NOT NULL,
	cantFichas numeric(18) NOT NULL,
	fecha datetime NOT NULL,
	dniCliente numeric(18) NOT NULL,
	codFactura numeric(18),
	dniChofer numeric(18) NOT NULL,
	turnoID varchar(20) NOT NULL,
);
ALTER TABLE GD1C2012.FEMIG.viajes ADD CONSTRAINT FK_Viaje_ChoferAutoTurno FOREIGN KEY (dniChofer, turnoID) REFERENCES GD1C2012.FEMIG.ChoferAutoTurno (dniChofer, turnoID);
ALTER TABLE GD1C2012.FEMIG.viajes ADD CONSTRAINT FK_Viaje_Factura FOREIGN KEY (codFactura) REFERENCES GD1C2012.FEMIG.facturas (codFactura);
ALTER TABLE GD1C2012.FEMIG.viajes ADD CONSTRAINT FK_Viaje_Cliente FOREIGN KEY (dniCliente) REFERENCES GD1C2012.FEMIG.clientes (dniCliente);

CREATE TABLE GD1C2012.FEMIG.Pantalla ( 
	pantallaID varchar(255) NOT NULL PRIMARY KEY CLUSTERED,
	descripcion varchar(255) NOT NULL
);

CREATE TABLE GD1C2012.FEMIG.Rol ( 
	rolID varchar(20) NOT NULL PRIMARY KEY CLUSTERED,
	descripcion varchar(50) NOT NULL,
	anulado bit default 0  -- 0: El rol está activo 1: El rol esta inhabilitado 
);

CREATE TABLE GD1C2012.FEMIG.RolPantalla ( 
	rolID varchar(20) NOT NULL,
	pantallaID varchar(255) NOT NULL,
	acceso bit default 0,  -- 0 o null: no tiene acceso 1: tiene acceso
	constraint pk_rolespantallas primary key CLUSTERED (rolID, pantallaID),
	constraint fk_rp_pantalla foreign key (pantallaID) references GD1C2012.FEMIG.pantalla(pantallaID),
	constraint fk_rp_rol foreign key (rolID) references GD1C2012.FEMIG.rol(rolID)
);

CREATE TABLE GD1C2012.FEMIG.Usuario ( 
	usuarioID varchar(20) NOT NULL PRIMARY KEY CLUSTERED,
	nombre varchar(50) NOT NULL,
	apellido varchar(50) NOT NULL,
	email varchar(100),
	password varchar(50) NOT NULL,
	cantIntentosFallo numeric(18),
	cantMaxIntentos numeric(18),
	anulado bit default 0 -- 0: El usuario está activo 1: El usuario esta inhabilitado
);
	
CREATE TABLE GD1C2012.FEMIG.RolUsuario ( 
	usuarioID varchar(20) NOT NULL,
	rolID varchar(20) NOT NULL,
	constraint pk_rolesusuarios primary key CLUSTERED (usuarioID, rolID),
	constraint fk_ru_rol foreign key (rolID) references GD1C2012.FEMIG.rol(rolID),
	constraint fk_ru_usuario foreign key (usuarioID) references GD1C2012.FEMIG.usuario(usuarioID)
);

/*++++++++++++++++++++++++++++++++++++++*/
/*Creacion de Propiedades Extendidas	*/
/*++++++++++++++++++++++++++++++++++++++*/
GO
EXEC sp_addextendedproperty 'MS_Description', '0: El rol está activo
1: El rol esta inhabilitado', 'Schema', FEMIG, 'table', Rol, 'column', anulado;

EXEC sp_addextendedproperty 'MS_Description', '0 o null: no tiene acceso
1: tiene acceso', 'Schema', FEMIG, 'table', RolPantalla, 'column', acceso;

EXEC sp_addextendedproperty 'MS_Description', '0: El reloj está activo 
1: El reloj esta inhabilitado', 'Schema', FEMIG, 'table', relojes, 'column', anulado;

EXEC sp_addextendedproperty 'MS_Description', '0: El auto está activo 
1: El auto esta inhabilitado', 'Schema', FEMIG, 'table', autos, 'column', anulado;

EXEC sp_addextendedproperty 'MS_Description', '0: El chofer está activo 
1: El chofer esta inhabilitado', 'Schema', FEMIG, 'table', choferes, 'column', anulado;

EXEC sp_addextendedproperty 'MS_Description', '0: El turno está activo 
1: El turno esta inhabilitado', 'Schema', FEMIG, 'table', turnos, 'column', anulado;

EXEC sp_addextendedproperty 'MS_Description', '0: El cliente está activo 
1: El cliente esta inhabilitado', 'Schema', FEMIG, 'table', clientes, 'column', anulado;

EXEC sp_addextendedproperty 'MS_Description', '0: El usuario está activo 
1: El usuario esta inhabilitado', 'Schema', FEMIG, 'table', Usuario, 'column', anulado;
GO

/*++++++++++++++++++++++++++++++++++++++*/
/*		Migración de Datos				*/
/*++++++++++++++++++++++++++++++++++++++*/

CREATE PROCEDURE migracion_datos





