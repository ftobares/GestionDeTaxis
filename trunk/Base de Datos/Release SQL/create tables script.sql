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
CREATE TABLE GD1C2012.FEMIG.autos ( 
	patente varchar(10) NOT NULL,
	marca varchar(255) NOT NULL,
	modelo varchar(255) NOT NULL,
	licencia varchar(26) NOT NULL UNIQUE,
	rodado varchar(10) NOT NULL,
	nroSerieReloj varchar(18) NOT NULL UNIQUE,
	anulado varchar(1),
	constraint pk_auto primary key (patente),
	constraint fk_auto_reloj foreign key (nroSerieReloj) references GD1C2012.FEMIG.relojes(nroSerieReloj)
);

CREATE TABLE GD1C2012.FEMIG.choferes ( 
	dniChofer numeric(18) NOT NULL,
	nombre varchar(255) NOT NULL,
	apellido varchar(255) NOT NULL,
	direccion varchar(255) NOT NULL,
	telefono numeric(18) NOT NULL,
	email varchar(50) UNIQUE,
	fechaNacimiento datetime NOT NULL,
	anulado varchar(1),
	constraint pk_chofer primary key (dniChofer),
);

CREATE TABLE GD1C2012.FEMIG.ChoferAutoTurno ( 
	fecha datetime NOT NULL,
	dniChofer numeric(18) NOT NULL,
	turnoID varchar(20) NOT NULL,
	patente varchar(10),
	constraint pk_choferautoturno primary key (dniChofer, turnoID),
	constraint fk_cat_chofer foreign key (dniChofer) references GD1C2012.FEMIG.choferes(dniChofer),
	constraint fk_cat_turno foreign key (turnoID) references GD1C2012.FEMIG.turnos(turnoID)
);

CREATE TABLE GD1C2012.FEMIG.clientes ( 
	dniCliente numeric(18) NOT NULL,
	nombre varchar(255) NOT NULL,
	apellido varchar(255) NOT NULL,
	telefono numeric(18) NOT NULL,
	direccion varchar(255) NOT NULL,
	email varchar(255),
	fechaNacimiento datetime NOT NULL,
	anulado varchar(1)
);
ALTER TABLE clientes
	ADD CONSTRAINT UQ_Cliente_email UNIQUE (email);
ALTER TABLE clientes
	ADD CONSTRAINT UQ_Cliente_telefono UNIQUE (telefono);
ALTER TABLE clientes ADD CONSTRAINT PK_Cliente 
	PRIMARY KEY CLUSTERED (dniCliente);

CREATE TABLE GD1C2012.FEMIG.facturas ( 
	codFactura numeric(18) NOT NULL,
	fecha_inicio datetime NOT NULL,
	fecha_fin datetime NOT NULL,
	dniCliente numeric(18) NOT NULL,
	importe_total numeric(18) NOT NULL
);
ALTER TABLE facturas
	ADD CONSTRAINT UQ_facturas_codFactura UNIQUE (codFactura);
ALTER TABLE facturas ADD CONSTRAINT PK_facturas 
	PRIMARY KEY CLUSTERED (codFactura);

CREATE TABLE GD1C2012.FEMIG.relojes ( 
	nroSerieReloj varchar(18) NOT NULL,
	marca varchar(255) NOT NULL,
	modelo varchar(255) NOT NULL,
	fechaVersion datetime NOT NULL,
	anulado varchar(1)
);
ALTER TABLE relojes ADD CONSTRAINT PK_Reloj 
	PRIMARY KEY CLUSTERED (nroSerieReloj);

CREATE TABLE GD1C2012.FEMIG.rendicion ( 
	fecha datetime NOT NULL,
	dniChofer numeric(18) NOT NULL,
	turnoID varchar(20) NOT NULL
);
ALTER TABLE rendicion ADD CONSTRAINT PK_rendicion 
	PRIMARY KEY CLUSTERED (fecha, dniChofer, turnoID);
ALTER TABLE rendicion ADD CONSTRAINT FK_rendicion_ChoferAutoTurno 
	FOREIGN KEY (dniChofer, turnoID) REFERENCES ChoferAutoTurno (dniChofer, turnoID);

CREATE TABLE GD1C2012.FEMIG.turnos ( 
	turnoID varchar(20) NOT NULL,
	horaInicio numeric(18) NOT NULL,
	horaFin numeric(18) NOT NULL,
	descripcion varchar(255) NOT NULL,
	valorFicha numeric(18,2) NOT NULL,
	valorBandera numeric(18,2) NOT NULL,
	anulado varchar(1)
);
ALTER TABLE turnos ADD CONSTRAINT PK_Turno 
	PRIMARY KEY CLUSTERED (turnoID);

CREATE TABLE GD1C2012.FEMIG.viajes ( 
	viajeID numeric(18) NOT NULL,
	tipoViaje varchar(10) NOT NULL,
	cantFichas numeric(18) NOT NULL,
	fecha datetime NOT NULL,
	dniCliente numeric(18) NOT NULL,
	codFactura numeric(18),
	dniChofer numeric(18) NOT NULL,
	turnoID varchar(20) NOT NULL
);
ALTER TABLE viajes ADD CONSTRAINT PK_Viaje 
	PRIMARY KEY CLUSTERED (viajeID);
ALTER TABLE viajes ADD CONSTRAINT FK_Viaje_ChoferAutoTurno 
	FOREIGN KEY (dniChofer, turnoID) REFERENCES ChoferAutoTurno (dniChofer, turnoID);
ALTER TABLE viajes ADD CONSTRAINT FK_Viaje_Factura 
	FOREIGN KEY (codFactura) REFERENCES Factura (codFactura);
ALTER TABLE viajes ADD CONSTRAINT FK_Viaje_Cliente 
	FOREIGN KEY (dniCliente) REFERENCES Cliente (dniCliente);