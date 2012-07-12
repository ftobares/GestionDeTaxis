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

CREATE TABLE GD1C2012.FEMIG.marcas_autos (
	marca varchar(255) NOT NULL PRIMARY KEY CLUSTERED
);

CREATE TABLE GD1C2012.FEMIG.autos ( 
	patente varchar(10) NOT NULL PRIMARY KEY CLUSTERED,
	marca varchar(255) NOT NULL,
	modelo varchar(255) NOT NULL,
	licencia varchar(26) NOT NULL,
	rodado varchar(10) NOT NULL,
	nroSerieReloj varchar(18) NOT NULL FOREIGN KEY REFERENCES GD1C2012.FEMIG.relojes(nroSerieReloj),
	anulado bit default 0, -- 0: El auto está activo 1: El auto esta inhabilitado
	constraint fk_marca foreign key (marca) references GD1C2012.FEMIG.marcas_autos (marca)
);

CREATE TABLE GD1C2012.FEMIG.choferes ( 
	dniChofer numeric(18) NOT NULL PRIMARY KEY CLUSTERED,
	nombre varchar(255) NOT NULL,
	apellido varchar(255) NOT NULL,
	direccion varchar(255) NOT NULL,
	telefono numeric(18) NOT NULL,
	email varchar(50) NOT NULL,
	fechaNacimiento datetime NOT NULL,
	anulado bit default 0 -- 0: El chofer está activo 1: El chofer esta inhabilitado
);

CREATE TABLE GD1C2012.FEMIG.turnos ( 
	turnoID numeric(18) NOT NULL PRIMARY KEY CLUSTERED IDENTITY(1,1),
	horaInicio numeric(18) NOT NULL,
	horaFin numeric(18) NOT NULL,
	descripcion varchar(255) NOT NULL,
	valorFicha numeric(18,2) NOT NULL,
	valorBandera numeric(18,2) NOT NULL,
	anulado bit default 0 -- 0: El turno está activo 1: El turno esta inhabilitado
);

CREATE TABLE GD1C2012.FEMIG.ChoferAutoTurno ( 
	asignacionId numeric(18) NOT NULL PRIMARY KEY CLUSTERED IDENTITY(1,1),
	dniChofer numeric(18) NOT NULL,
	turnoID numeric(18) NOT NULL,
	patente varchar(10) NOT NULL,
	fecha datetime NOT NULL,
	anulado bit default 0 -- 0: La asignacion está activa 1: La aasignacion esta inhabilitada
);

ALTER TABLE GD1C2012.FEMIG.ChoferAutoTurno ADD CONSTRAINT FK_ChoferAutoTurno_Chofer 
	FOREIGN KEY (dniChofer) REFERENCES GD1C2012.FEMIG.Choferes (dniChofer)

ALTER TABLE GD1C2012.FEMIG.ChoferAutoTurno ADD CONSTRAINT FK_ChoferAutoTurno_Turno 
	FOREIGN KEY (turnoID) REFERENCES GD1C2012.FEMIG.Turnos (turnoID)
	
ALTER TABLE GD1C2012.FEMIG.ChoferAutoTurno ADD CONSTRAINT FK_ChoferAutoTurno_Auto
	FOREIGN KEY (patente) REFERENCES GD1C2012.FEMIG.Autos (patente)	
	
CREATE INDEX index_cat_dniChofer ON FEMIG.ChoferAutoTurno (dniChofer);

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

CREATE TABLE GD1C2012.FEMIG.Facturas ( 
	codFactura numeric(18) NOT NULL PRIMARY KEY CLUSTERED IDENTITY(100000,1),
	fechaInicio datetime NOT NULL,
	fechaFin datetime NOT NULL,
	dniCliente numeric(18) NOT NULL,
	importeTotal numeric(18,2) DEFAULT 0 NOT NULL
);

CREATE INDEX index_fac_dniCliente ON FEMIG.Facturas (dniCliente);

CREATE TABLE GD1C2012.FEMIG.Rendiciones ( 
	codRendicion numeric(18) NOT NULL PRIMARY KEY CLUSTERED IDENTITY(1,1),
	fecha datetime NOT NULL,
	dniChofer numeric(18) NOT NULL,
	turnoID varchar(20) NOT NULL,
	importeTotal numeric(18,2) NOT NULL
);

CREATE INDEX index_ren_dniChofer ON FEMIG.Rendiciones (dniChofer);

CREATE TABLE GD1C2012.FEMIG.viajes ( 
	viajeID numeric(18) NOT NULL PRIMARY KEY CLUSTERED IDENTITY(1,1),
	tipoViaje varchar(10) NOT NULL,
	asignacionId numeric(18) NOT NULL,
	cantFichas numeric(18) NOT NULL,
	fecha datetime NOT NULL,
	dniCliente numeric(18),
	codFactura numeric(18),
	codRendicion numeric(18)
);
ALTER TABLE GD1C2012.FEMIG.viajes ADD CONSTRAINT FK_Viaje_ChoferAutoTurno FOREIGN KEY (asignacionId) REFERENCES GD1C2012.FEMIG.ChoferAutoTurno (asignacionId);

ALTER TABLE GD1C2012.FEMIG.Viajes ADD CONSTRAINT FK_Viaje_Factura 
	FOREIGN KEY (codFactura) REFERENCES GD1C2012.FEMIG.Facturas (codFactura);

ALTER TABLE GD1C2012.FEMIG.Viajes ADD CONSTRAINT FK_Viaje_Rendicion 
	FOREIGN KEY (codRendicion) REFERENCES GD1C2012.FEMIG.Rendiciones (codRendicion);

ALTER TABLE GD1C2012.FEMIG.Viajes ADD CONSTRAINT FK_Viaje_Cliente 
	FOREIGN KEY (dniCliente) REFERENCES GD1C2012.FEMIG.Clientes (dniCliente);
	
CREATE INDEX index_via_dniCliente ON FEMIG.viajes (dniCliente);

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

	/*Inicio de Migración de la tabla Relojes*/
	BEGIN	
		DECLARE @nroSerie varchar(18);
		DECLARE @marca varchar(255);
		DECLARE @modelo varchar(255);
		DECLARE @fecha datetime;
		DECLARE @posicion int;
		DECLARE @alfabeto varchar(26);
		DECLARE @contador int;

		SET @contador = 1;
		SET @posicion = 1;
		SET @alfabeto = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'

		DECLARE insert_relojes CURSOR FOR
		SELECT DISTINCT(reloj_marca),reloj_modelo,reloj_fecha_ver
		FROM gd_esquema.maestra
		order by reloj_marca asc;

		OPEN insert_relojes;

		FETCH NEXT FROM insert_relojes
		INTO  @marca, @modelo, @fecha;

		WHILE @@FETCH_STATUS = 0
		BEGIN
			IF @posicion < 27
				BEGIN
					SELECT @nroSerie = CHAR(ASCII(SUBSTRING(@alfabeto, @posicion, 1))); 
					INSERT INTO FEMIG.relojes (nroSerieReloj,marca,modelo,fechaVersion)
					VALUES (@nroSerie+cast(@contador as varchar(999)),@marca,@modelo,cast(@fecha as varchar(255)));
					
					FETCH NEXT FROM insert_relojes
					INTO  @marca, @modelo, @fecha;

					SET @posicion = @posicion + 1;
					SET @contador = @contador + 1;
				END
			ELSE
				BEGIN
					SET @posicion = 1;

					SELECT @nroSerie = CHAR(ASCII(SUBSTRING(@alfabeto, @posicion, 1))); 
					INSERT INTO FEMIG.relojes (nroSerieReloj,marca,modelo,fechaVersion)
					VALUES (@nroSerie+cast(@contador as varchar(999)),@marca,@modelo,cast(@fecha as varchar(255)));
					
					FETCH NEXT FROM insert_relojes
					INTO  @marca, @modelo, @fecha;

					SET @posicion = @posicion + 1;
					SET @contador = @contador + 1;
				END
			
		END
		CLOSE insert_relojes;
		DEALLOCATE insert_relojes;
	END
	/*Finalización de Migración de la tabla Relojes*/

	INSERT INTO GD1C2012.FEMIG.marcas_autos (marca)
	VALUES ('Otra');

	INSERT INTO GD1C2012.FEMIG.marcas_autos (marca)
	SELECT DISTINCT(auto_marca)
	FROM gd_esquema.maestra
	order by auto_marca asc;

	INSERT INTO FEMIG.autos (patente,marca,modelo,licencia,rodado,nroSerieReloj)
	SELECT DISTINCT(gd.auto_patente),gd.auto_marca,gd.auto_modelo,gd.auto_licencia,gd.auto_rodado,rel.nroSerieReloj
	FROM gd_esquema.maestra gd, femig.relojes rel
	WHERE rel.modelo = gd.reloj_modelo
	and rel.marca = gd.reloj_marca
	order by auto_patente asc;

	INSERT INTO FEMIG.choferes (dniChofer,nombre,apellido,direccion,telefono,email,fechaNacimiento)
	SELECT DISTINCT(chofer_dni),chofer_nombre,chofer_apellido,chofer_direccion,chofer_telefono,chofer_mail,chofer_fecha_nac
	FROM gd_esquema.maestra
	order by chofer_dni asc;

	INSERT INTO FEMIG.turnos (horaInicio,horaFin,descripcion,valorFicha,valorBandera)
	SELECT DISTINCT(turno_hora_inicio),turno_hora_fin,turno_descripcion,turno_valor_ficha,turno_valor_bandera
	FROM gd_esquema.maestra
	order by turno_hora_inicio asc;

	INSERT INTO femig.ChoferAutoTurno (dniChofer,turnoID,patente,fecha)
	SELECT DISTINCT(ch.dniChofer), tr.turnoID, at.patente, dateadd(dd, datediff(dd,0,gd.viaje_fecha),0) as viaje_fecha
	FROM gd_esquema.maestra gd, femig.choferes ch, femig.autos at, femig.turnos tr
	WHERE gd.chofer_dni = ch.dniChofer
	AND gd.auto_patente = at.patente
	AND gd.turno_hora_inicio = tr.horaInicio
	and gd.turno_hora_fin = tr.horaFin
	order by ch.dniChofer, tr.turnoID;

	INSERT INTO FEMIG.clientes (dniCliente,nombre,apellido,telefono,direccion,email,fechaNacimiento) 
	VALUES (0,'clienteCalle','clienteCalle',0,'no aplica','no aplica',cast(0 as datetime));

	INSERT INTO FEMIG.clientes (dniCliente,nombre,apellido,telefono,direccion,email,fechaNacimiento)
	SELECT DISTINCT(cliente_dni),cliente_nombre,cliente_apellido,cliente_telefono,cliente_direccion,cliente_mail,cliente_fecha_nac
	FROM  gd_esquema.maestra
	WHERE cliente_dni IS NOT NULL
	order by cliente_dni asc;

	SET IDENTITY_INSERT FEMIG.facturas ON
	INSERT INTO FEMIG.facturas (codFactura,fechaInicio,fechaFin,dniCliente)
	VALUES (0,cast(0 as datetime),cast(0 as datetime),0);
	SET IDENTITY_INSERT FEMIG.facturas OFF

	INSERT INTO FEMIG.facturas (fechaInicio,fechaFin,dniCliente,importeTotal)
	select DISTINCT(factura_fecha_inicio),factura_fecha_fin, cliente_dni,
	SUM((viaje_cant_fichas * turno_valor_ficha) + turno_valor_bandera) as importeTotal
	from gd_esquema.maestra WHERE factura_fecha_inicio IS NOT NULL AND factura_fecha_fin IS NOT NULL
	group by cliente_dni, factura_fecha_inicio, factura_fecha_fin
	order by cliente_dni, factura_fecha_inicio;

	INSERT INTO femig.rendiciones (fecha,dniChofer,turnoID,importeTotal)
	select gd.rendicion_fecha, gd.chofer_dni, tr.turnoID,
	SUM(DISTINCT(gd.viaje_cant_fichas * gd.turno_valor_ficha) + gd.turno_valor_bandera) as importeTotal
	from gd_esquema.maestra gd, femig.turnos tr
	where gd.rendicion_fecha is not null 
	and tr.horaInicio = gd.turno_hora_inicio
	and tr.horaFin = gd.turno_hora_fin
	group by gd.rendicion_fecha, gd.chofer_dni, tr.turnoID
	order by chofer_dni, rendicion_fecha, turnoID;
	
	--Clientes
	INSERT INTO femig.viajes(fecha,tipoViaje,asignacionID,cantFichas,dniCliente,codFactura,codRendicion)
	select DISTINCT(m.viaje_fecha),(case when m.cliente_dni is null then 'calle' else 'cliente' end) as tipoViaje,
	cat.asignacionID,m.viaje_cant_fichas,m.cliente_dni,fac.codFactura,ren.codRendicion
	from femig.choferautoturno cat, femig.turnos tur, femig.facturas fac, femig.rendiciones ren, gd_esquema.maestra m
	where m.rendicion_fecha is null
	and m.factura_fecha_inicio is null
	and m.chofer_dni = cat.dniChofer
	and m.cliente_dni = fac.dniCliente
	and m.chofer_dni = ren.dniChofer
	and m.turno_hora_inicio = tur.horaInicio
	and m.turno_hora_fin = tur.horaFin
	and tur.turnoID = cat.turnoID
	and tur.turnoID = ren.turnoID
	and month(m.viaje_fecha) = month(fac.fechaInicio)
	and day(m.viaje_fecha) between (day(fac.fechaInicio)) and (day(fac.fechaFin))
	and month(m.viaje_fecha) = month(ren.fecha)
	and month(m.viaje_fecha) = month(cat.fecha)
	and day(m.viaje_fecha) = day(ren.fecha)
	and day(m.viaje_fecha) = day(cat.fecha)
	order by m.viaje_fecha,m.cliente_dni

	--Calle
	INSERT INTO femig.viajes(fecha,tipoViaje,asignacionID,cantFichas,dniCliente,codFactura,codRendicion)
	select DISTINCT(m.viaje_fecha),(case when m.cliente_dni is null then 'calle' else 'cliente' end) as tipoViaje,
	cat.asignacionID,m.viaje_cant_fichas,0,0,ren.codRendicion
	from femig.choferautoturno cat, femig.turnos tur, femig.rendiciones ren, gd_esquema.maestra m
	where m.rendicion_fecha is null
	and m.factura_fecha_inicio is null
	and m.cliente_dni is null
	and m.chofer_dni = cat.dniChofer
	and m.chofer_dni = ren.dniChofer
	and m.turno_hora_inicio = tur.horaInicio
	and m.turno_hora_fin = tur.horaFin
	and tur.turnoID = cat.turnoID
	and tur.turnoID = ren.turnoID
	and month(m.viaje_fecha) = month(ren.fecha)
	and month(m.viaje_fecha) = month(cat.fecha)
	and day(m.viaje_fecha) = day(ren.fecha)
	and day(m.viaje_fecha) = day(cat.fecha)
	order by m.viaje_fecha

/*++++++++++++++++++++++++++++++++++*/
/*		Carga de Funcionalidades	*/
/*++++++++++++++++++++++++++++++++++*/

	/*Carga Inicial de Pantalla*/
	INSERT INTO FEMIG.PANTALLA VALUES ('abmCliente','ABM Clientes')
	INSERT INTO FEMIG.PANTALLA VALUES ('abmRol','ABM Roles')
	INSERT INTO FEMIG.PANTALLA VALUES ('abmUsuario','ABM Usuarios')
	INSERT INTO FEMIG.PANTALLA VALUES ('abmAuto','ABM Autos')
	INSERT INTO FEMIG.PANTALLA VALUES ('abmReloj','ABM Relojes')
	INSERT INTO FEMIG.PANTALLA VALUES ('abmChofer','ABM Choferes')
	INSERT INTO FEMIG.PANTALLA VALUES ('abmTurno','ABM Turnos')
	INSERT INTO FEMIG.PANTALLA VALUES ('abmChoferAuto','Relación Chofer-Auto')
	INSERT INTO FEMIG.PANTALLA VALUES ('abmViaje','Cargar Viajes')
	INSERT INTO FEMIG.PANTALLA VALUES ('abmRendicion','Rendición de Cuenta')
	INSERT INTO FEMIG.PANTALLA VALUES ('abmFacturacion','Facturación')
	INSERT INTO FEMIG.PANTALLA VALUES ('abmListado','Listados Estadísticos')
	INSERT INTO FEMIG.PANTALLA VALUES ('abmPantalla','Pantallas del Sistema')
	
	insert into FEMIG.Rol values ('Administrador','Administrador de Sistema','0')

	insert into FEMIG.ROLPANTALLA
	select 'Administrador',PANTALLAID,'1' from FEMIG.PANTALLA

	INSERT INTO FEMIG.USUARIO VALUES ('Admin','Administrador','Administrador',null,'E6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7',0,10,'0')

	insert into FEMIG.rolusuario values ('Admin','Administrador')

COMMIT TRANSACTION migracion;

END TRY

BEGIN CATCH
	PRINT 'Warning: Se ha producido un error en la migracion de los datos'
	PRINT 'Numero de Error: '+cast(ERROR_NUMBER() as varchar(255))
	PRINT 'El error se ha producido en la linea: '+cast(ERROR_LINE() as varchar(255))
	PRINT ERROR_MESSAGE()
	PRINT 'La severidad del error es: '+cast(ERROR_SEVERITY() as varchar(255))
END CATCH
