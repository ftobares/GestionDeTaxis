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
BEGIN TRANSACTION
CREATE TABLE GD1C2012.FEMIG.relojes ( 
	nroSerieReloj numeric(18) NOT NULL PRIMARY KEY CLUSTERED IDENTITY(10000,1),
	marca varchar(255) NOT NULL,
	modelo varchar(255) NOT NULL,
	fechaVersion datetime NOT NULL,
	anulado bit default 0 -- 0: El reloj está activo 1: El reloj esta inhabilitado
);

CREATE TABLE GD1C2012.FEMIG.marcas_autos (
	marca varchar(255) NOT NULL PRIMARY KEY CLUSTERED
);

CREATE TABLE GD1C2012.FEMIG.autos ( 
	patente varchar(10) NOT NULL PRIMARY KEY CLUSTERED,
	marca varchar(255) NOT NULL,
	modelo varchar(255) NOT NULL,
	licencia varchar(26) NOT NULL UNIQUE,
	rodado varchar(10) NOT NULL,
	nroSerieReloj numeric(18) NOT NULL UNIQUE FOREIGN KEY REFERENCES GD1C2012.FEMIG.relojes(nroSerieReloj),
	anulado bit default 0, -- 0: El auto está activo 1: El auto esta inhabilitado
	constraint fk_marca foreign key (marca) references GD1C2012.FEMIG.marcas_autos (marca)
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
	turnoID numeric(20) NOT NULL PRIMARY KEY CLUSTERED IDENTITY(1,1),
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
	turnoID numeric(20) NOT NULL,
	patente varchar(10),
	constraint pk_choferautoturno primary key CLUSTERED (dniChofer, turnoID),
	constraint fk_cat_chofer foreign key (dniChofer) references GD1C2012.FEMIG.choferes(dniChofer),
	constraint fk_cat_turno foreign key (turnoID) references GD1C2012.FEMIG.turnos(turnoID)
);

CREATE TABLE GD1C2012.FEMIG.clientes ( 
	dniCliente numeric(18) NOT NULL PRIMARY KEY CLUSTERED,
	nombre varchar(255) NOT NULL,
	apellido varchar(255) NOT NULL,
	telefono numeric(18) NOT NULL,
	direccion varchar(255) NOT NULL,
	email varchar(255) NOT NULL,
	fechaNacimiento datetime NOT NULL,
	anulado bit default 0 -- 0: El cliente está activo 1: El cliente esta inhabilitado
);

CREATE TABLE GD1C2012.FEMIG.facturas ( 
	codFactura numeric(18) NOT NULL PRIMARY KEY CLUSTERED IDENTITY(100000,1),
	fecha_inicio datetime NOT NULL,
	fecha_fin datetime NOT NULL,
	dniCliente numeric(18) NOT NULL,
	importe_total numeric(18) DEFAULT 0 NOT NULL
);

CREATE TABLE GD1C2012.FEMIG.rendicion ( 
	fecha datetime NOT NULL,
	dniChofer numeric(18) NOT NULL,
	turnoID numeric(20) NOT NULL,
	importe numeric(10) DEFAULT 0 NOT NULL,
	constraint pk_rendicion primary key CLUSTERED (fecha, dniChofer, turnoID),
	constraint fk_rendicion_cat foreign key (dniChofer, turnoID) references GD1C2012.FEMIG.ChoferAutoTurno(dniChofer, turnoID)
);

CREATE TABLE GD1C2012.FEMIG.viajes ( 
	viajeID numeric(18) NOT NULL PRIMARY KEY CLUSTERED IDENTITY(1,1),
	tipoViaje varchar(10) NOT NULL,
	cantFichas numeric(18) NOT NULL,
	fecha datetime NOT NULL,
	dniCliente numeric(18) NOT NULL,
	codFactura numeric(18) NOT NULL,
	dniChofer numeric(18) NOT NULL,
	turnoID numeric(20) NOT NULL,
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
	password varchar(64) NOT NULL,
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
END TRANSACTION
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
BEGIN TRANSACTION migracion;

BEGIN TRY
INSERT INTO FEMIG.turnos (horaInicio,horaFin,descripcion,valorFicha,valorBandera)
SELECT turno_hora_inicio,turno_hora_fin,turno_descripcion,turno_valor_ficha,turno_valor_bandera
FROM gd_esquema.maestra
group by turno_hora_inicio,turno_hora_fin,turno_descripcion,turno_valor_ficha,turno_valor_bandera
order by turno_hora_inicio asc;

INSERT INTO FEMIG.clientes (dniCliente,nombre,apellido,telefono,direccion,email,fechaNacimiento) 
VALUES (0,'clienteCalle','clienteCalle',0,'no aplica','no aplica',getdate());

INSERT INTO FEMIG.clientes (dniCliente,nombre,apellido,telefono,direccion,email,fechaNacimiento)
SELECT cliente_dni,cliente_nombre,cliente_apellido,cliente_telefono,cliente_direccion,cliente_mail,cliente_fecha_nac
FROM  gd_esquema.maestra
WHERE cliente_dni IS NOT NULL
group by cliente_dni,cliente_nombre,cliente_apellido,cliente_telefono,cliente_direccion,cliente_mail,cliente_fecha_nac
order by cliente_dni asc;

SET IDENTITY_INSERT FEMIG.facturas ON
INSERT INTO FEMIG.facturas (codFactura,fecha_inicio,fecha_fin,dniCliente)
VALUES (0,getdate(),getdate(),0);
SET IDENTITY_INSERT FEMIG.facturas OFF

INSERT INTO FEMIG.facturas (fecha_inicio,fecha_fin,dniCliente)
SELECT factura_fecha_inicio,factura_fecha_fin,cliente_dni
FROM gd_esquema.maestra
WHERE factura_fecha_inicio IS NOT NULL
AND factura_fecha_fin IS NOT NULL
group by factura_fecha_inicio,factura_fecha_fin,cliente_dni
order by cliente_dni,factura_fecha_inicio asc;

INSERT INTO FEMIG.relojes (marca,modelo,fechaVersion)
SELECT reloj_marca,reloj_modelo,reloj_fecha_ver
FROM gd_esquema.maestra
group by reloj_marca,reloj_modelo,reloj_fecha_ver
order by reloj_marca asc;

INSERT INTO GD1C2012.FEMIG.marcas_autos (marca)
VALUES ('Otra');

INSERT INTO GD1C2012.FEMIG.marcas_autos (marca)
SELECT auto_marca
FROM gd_esquema.maestra
group by auto_marca
order by auto_marca asc;

INSERT INTO FEMIG.autos (patente,marca,modelo,licencia,rodado,nroSerieReloj)
SELECT gd.auto_patente,gd.auto_marca,gd.auto_modelo,gd.auto_licencia,gd.auto_rodado,rel.nroSerieReloj
FROM gd_esquema.maestra gd, femig.relojes rel
WHERE rel.modelo = gd.reloj_modelo
and rel.marca = gd.reloj_marca
group by gd.auto_patente,gd.auto_marca,gd.auto_modelo,gd.auto_licencia,gd.auto_rodado,rel.nroSerieReloj
order by auto_patente asc;

INSERT INTO FEMIG.choferes (dniChofer,nombre,apellido,direccion,telefono,email,fechaNacimiento)
SELECT chofer_dni,chofer_nombre,chofer_apellido,chofer_direccion,chofer_telefono,chofer_mail,chofer_fecha_nac
FROM gd_esquema.maestra
group by chofer_dni,chofer_nombre,chofer_apellido,chofer_direccion,chofer_telefono,chofer_mail,chofer_fecha_nac
order by chofer_dni asc;

/*Testear
INSERT INTO GD1C2012.FEMIG.ChoferAutoTurno (fecha,dniChofer,turnoID,patente)
SELECT gd.viaje_fecha, ch.dniChofer, tur.turnoID, at.patente, count(*)
FROM gd_esquema.maestra gd, femig.choferes ch, femig.turnos tur, femig.autos at
WHERE gd.chofer_dni = ch.dniChofer
and gd.turno_descripcion = tur.descripcion
and gd.auto_patente = at.patente
group by gd.viaje_fecha, ch.dniChofer, tur.turnoID, at.patente
order by dniChofer, viaje_fecha asc;

INSERT INTO FEMIG.viajes (tipoViaje,cantFichas,fecha,dniCliente,codFactura,dniChofer,turnoID)
SELECT 'cliente',gd.viaje_cant_fichas, gd.viaje_fecha, gd.dniCliente,fac.codFactura,cat.dniChofer,
cat.turnoID
FROM  gd_esquema.maestra gd, femig.facturas fac, femig.choferautoturno cat
where gd.dniCliente = fac.dniCliente
and gd.factura_fecha_inicio = fac.fecha_incio
and gd.factura_fecha_fin = fac.fecha_fin
and gd.viaje_fecha = cat.fecha;

INSERT INTO FEMIG.viajes (tipoViaje,cantFichas,fecha,dniCliente,codFactura,dniChofer,turnoID)
SELECT 'calle',gd.viaje_cant_fichas, gd.viaje_fecha, 0, 0,cat.dniChofer, cat.turnoID
FROM  gd_esquema.maestra gd, femig.choferautoturno cat
where gd.dniCliente is null
and gd.factura_fecha_inicio is null
and gd.factura_fecha_fin is null
and gd.viaje_fecha = cat.fecha;

INSERT INTO FEMIG.rendicion (fecha,auto_patente,importe,cantidad_viajes)
*/

COMMIT TRANSACTION migracion;

END TRY

BEGIN CATCH
	PRINT 'Se ha procudido un error en la migracion de los datos'
	PRINT ERROR_NUMBER()
	PRINT ERROR_MESSAGE()
END CATCH
/*++++++++++++++++++++++++++++++++++++++*/
/*		Store Procedures				*/
/*++++++++++++++++++++++++++++++++++++++*/

--crear usuarios

