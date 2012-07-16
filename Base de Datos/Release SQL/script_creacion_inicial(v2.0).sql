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
ALTER TABLE GD1C2012.FEMIG.viajes ADD CONSTRAINT FK_Viaje_ChoferAutoTurno 
	FOREIGN KEY (asignacionId) REFERENCES GD1C2012.FEMIG.ChoferAutoTurno (asignacionId);

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

/*++++++++++++++++++++++++++++++++++++++*/
/*		Store Procedures				*/
/*++++++++++++++++++++++++++++++++++++++*/
go
USE [GD1C2012]
GO
/****** Object:  StoredProcedure [FEMIG].[eliminarCliente]    Script Date: 06/27/2012 02:34:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [FEMIG].[eliminarCliente] 
	@pDniCliente			NUMERIC(18)
AS
BEGIN
	update femig.clientes set anulado = '1' where dniCliente = @pDniCliente
END

GO
/****** Object:  StoredProcedure [FEMIG].[crearCliente]    Script Date: 06/27/2012 02:34:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [FEMIG].[crearCliente] 
	@pDniCliente		NUMERIC(18),
	@pNombre			VARCHAR(255),
	@pApellido			VARCHAR(255),
	@pTelefono			numeric(18),
	@pDireccion			VARCHAR(255),
	@pEmail				VARCHAR(255),
	@pFechaNacimiento 	DATETIME,
	@pAnulado			BIT,
	@retCatchError		VARCHAR(MAX) out
AS
BEGIN
	--Controlo que no haya duplicados de DniCliente
	if exists (select 1 from FEMIG.clientes where dniCliente = @pDniCliente)
	begin
		set @retCatchError = 'Ya existe un cliente con el mismo DNI ' + cast(@pDniCliente as varchar) + '.'
		return
	end

	--Controlo que no haya duplicados de telefono
	if exists (select 1 from FEMIG.clientes where telefono = @pTelefono)
	begin
		set @retCatchError = 'Ya existe un cliente con el mismo DNI ' + cast(@pDniCliente as varchar) + '.'
		return
	end

	INSERT INTO [GD1C2012].[FEMIG].[clientes]
           (dniCliente,nombre,apellido,telefono,direccion,email,fechaNacimiento,anulado)
    VALUES
           (@pDniCliente
           ,@pNombre
           ,@pApellido
           ,@pTelefono
           ,@pDireccion
           ,@pEmail
		   ,@pFechaNacimiento
           ,'0')
	
END

GO
/****** Object:  StoredProcedure [FEMIG].[crearAuto]    Script Date: 06/27/2012 02:34:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [FEMIG].[crearAuto] 
	@pPatente			VARCHAR(10),
	@pMarca				VARCHAR(255),
	@pModelo			VARCHAR(255),
	@pLicencia			VARCHAR(26),
	@pRodado			VARCHAR(10),
	@pNroSerieReloj		VARCHAR(18),
	@pAnulado			BIT,
	@pRetCatchError		VARCHAR(1000) out
AS
BEGIN
	--Controlo que no haya duplicados de Patente
	if exists (select 1 from FEMIG.autos where patente = @pPatente)
	begin
		set @pRetCatchError = 'Ya existe un auto con la patente ' + cast(@pPatente as varchar) + '.'
		return
	end

	--Controlo que no haya 2 autos activos con el mismo reloj
	if exists (select 1 from FEMIG.autos where nroSerieReloj = @pNroSerieReloj and isnull(anulado,'0')='0')
	begin
		set @pRetCatchError = 'Ya existe un auto con el reloj ' + cast(@pNroSerieReloj as varchar) + '.'
		return
	end

	INSERT INTO [GD1C2012].[FEMIG].[autos]
           (patente,marca,modelo,licencia,rodado,nroSerieReloj,anulado)
    VALUES
           (@pPatente
           ,@pMarca
           ,@pModelo
           ,@pLicencia
           ,@pRodado
           ,@pNroSerieReloj
           ,'0')
	
END

GO
/****** Object:  StoredProcedure [FEMIG].[editarAuto]    Script Date: 06/27/2012 02:34:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [FEMIG].[editarAuto] 
	@pPatente			VARCHAR(10),
	@pMarca				VARCHAR(255),
	@pModelo			VARCHAR(255),
	@pLicencia			VARCHAR(26),
	@pRodado			VARCHAR(10),
	@pNroSerieReloj		NUMERIC(18,0),
	@pAnulado			BIT,
	@pRetCatchError		VARCHAR(1000) out
AS
BEGIN
	--Controlo que no haya duplicados de Patente
	if not exists (select 1 from FEMIG.autos where patente = @pPatente)
	begin
		set @pRetCatchError = 'No existe un auto con la patente ' + cast(@pPatente as varchar) + '.'
		return
	end

	--Controlo que no haya 2 autos activos con el mismo reloj
	if exists (select 1 from FEMIG.autos where patente <> @pPatente and nroSerieReloj = @pNroSerieReloj and isnull(anulado,'0')='0')
	begin
		set @pRetCatchError = 'Ya existe un auto con el reloj ' + cast(@pNroSerieReloj as varchar) + '.'
		return
	end

	UPDATE [GD1C2012].[FEMIG].[autos]
	   SET [marca] = @pMarca
		  ,[modelo] = @pModelo
		  ,[licencia] = @pLicencia
		  ,[rodado] = @pRodado
		  ,[nroSerieReloj] = @pNroSerieReloj
		  ,[anulado] = @pAnulado
	 WHERE patente = @pPatente
	
END

GO
/****** Object:  StoredProcedure [FEMIG].[eliminarAuto]    Script Date: 06/27/2012 02:34:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [FEMIG].[eliminarAuto] 
	@pPatente			VARCHAR(10)
AS
BEGIN
	update femig.autos set anulado = '1' where patente = @pPatente
END

GO
/****** Object:  StoredProcedure [FEMIG].[crearChofer]    Script Date: 06/27/2012 02:34:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [FEMIG].[crearChofer] 
	@pDniChofer			NUMERIC(18,0),
	@pNombre			VARCHAR(255),
	@pApellido			VARCHAR(255),
	@pDireccion			VARCHAR(255),
	@pTelefono			NUMERIC(18,0),
	@pEmail				VARCHAR(50),
	@pFechaNacimiento	DATETIME,
	@pAnulado			BIT,
	@pRetCatchError		VARCHAR(1000) out
AS
BEGIN
	--Controlo que no haya duplicados de Patente
	if exists (select 1 from FEMIG.choferes where dniChofer = @pDniChofer)
	begin
		set @pRetCatchError = 'Ya existe un chofer con el Dni: ' + cast(@pDniChofer as varchar) + '.'
		return
	end

	--Controlo que no haya 2 autos activos con el mismo reloj
	if exists (select 1 from FEMIG.choferes where email = @pEmail)
	begin
		set @pRetCatchError = 'Ya existe un chofer con el email ' + @pEmail + '.'
		return
	end

	INSERT INTO [GD1C2012].[FEMIG].[choferes]
           ([dniChofer],[nombre],[apellido],[direccion],[telefono],[email],[fechaNacimiento],[anulado])
     VALUES
           (@pDniChofer
           ,@pNombre
           ,@pApellido
           ,@pDireccion
           ,@pTelefono
           ,@pEmail
           ,@pFechaNacimiento
           ,'0')	
END

GO
/****** Object:  StoredProcedure [FEMIG].[editarChofer]    Script Date: 06/27/2012 02:34:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [FEMIG].[editarChofer] 
	@pDniChofer			NUMERIC(18,0),
	@pNombre			VARCHAR(255),
	@pApellido			VARCHAR(255),
	@pDireccion			VARCHAR(255),
	@pTelefono			NUMERIC(18,0),
	@pEmail				VARCHAR(50),
	@pFechaNacimiento	DATETIME,
	@pAnulado			BIT,
	@pRetCatchError		VARCHAR(1000) out
AS
BEGIN
	--Controlo que no haya duplicados de Patente
	if not exists (select 1 from FEMIG.choferes where dniChofer = @pDniChofer)
	begin
		set @pRetCatchError = 'No existe un chofer con Dni ' + cast(@pDniChofer as varchar) + '.'
		return
	end

	--Controlo que no haya 2 autos activos con el mismo reloj
	if exists (select 1 from FEMIG.choferes where dniChofer <> @pDniChofer and email = @pEmail)
	begin
		set @pRetCatchError = 'Ya existe un chofer con el email ' + cast(@pEmail as varchar) + '.'
		return
	end

	UPDATE [GD1C2012].[FEMIG].[choferes]
	   SET [nombre] = @pNombre
		  ,[apellido] = @pApellido
		  ,[direccion] = @pDireccion
		  ,[telefono] = @pTelefono
		  ,[email] = @pEmail
		  ,[fechaNacimiento] = @pFechaNacimiento
		  ,[anulado] = @pAnulado
	 WHERE dniChofer = @pDniChofer
		
END

GO
/****** Object:  StoredProcedure [FEMIG].[eliminarChofer]    Script Date: 06/27/2012 02:34:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [FEMIG].[eliminarChofer] 
	@pDniChofer			VARCHAR(10)
AS
BEGIN
	update femig.choferes set anulado = '1' where dniChofer = @pDniChofer
END

GO
/****** Object:  StoredProcedure [FEMIG].[crearTurno]    Script Date: 06/27/2012 02:34:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [FEMIG].[crearTurno] 
	/*@pTurnoId			NUMERIC(18,0),
	@pDescripcion		VARCHAR(10),
	@pHoraInicio		VARCHAR(255),
	@pHoraFin			VARCHAR(255),
	@pValorFicha		VARCHAR(26),
	@pValorBandera		VARCHAR(10),
	@pAnulado			BIT,
	@pRetCatchError		VARCHAR(1000) out*/
	@pTurnoId			NUMERIC(18,0),
	@pDescripcion		VARCHAR(255),
	@pHoraInicio		NUMERIC(18,0),
	@pHoraFin			NUMERIC(18,0),
	@pValorFicha		NUMERIC(18,2),
	@pValorBandera		NUMERIC(18,2),
	@pAnulado			BIT,
	@pRetCatchError		VARCHAR(1000) out
AS
BEGIN

	--Controlo si 2 turnos activos solapan horarios
	IF exists	(SELECT	1 FROM femig.turnos
				WHERE ISNULL(anulado,'0')='0'
						AND ((@pHoraInicio >= horaInicio AND @pHoraInicio <= horaFin)
						OR (@pHoraFin >= horaInicio AND @pHoraFin <= horaFin)))
	BEGIN
		set @pRetCatchError = 'El turno que intenta ingresar se solapa con otros horarios.'
		return
	END
	
	INSERT INTO [GD1C2012].[FEMIG].[turnos]
           (horaInicio,horaFin,descripcion,valorFicha,valorBandera,anulado)
    VALUES
           (@pHoraInicio
           ,@pHoraFin
           ,@pDescripcion
           ,@pValorFicha
           ,@pValorBandera
           ,'0')	
END

GO
/****** Object:  StoredProcedure [FEMIG].[editarTurno]    Script Date: 06/27/2012 02:34:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [FEMIG].[editarTurno] 
	@pTurnoId			NUMERIC(18,0),
	@pDescripcion		VARCHAR(255),
	@pHoraInicio		NUMERIC(18,0),
	@pHoraFin			NUMERIC(18,0),
	@pValorFicha		NUMERIC(18,2),
	@pValorBandera		NUMERIC(18,2),
	@pAnulado			BIT,
	@pRetCatchError		VARCHAR(1000) out
AS
BEGIN
	--Controlo si 2 turnos activos solapan horarios
	iF exists	(SELECT	1 FROM femig.turnos
				WHERE	ISNULL(anulado,'0')='0'
						AND ((@pHoraInicio >= horaInicio AND @pHoraInicio <= horaFin)
						OR (@pHoraFin >= horaInicio AND @pHoraFin <= horaFin)))
	begin
		set @pRetCatchError = 'El turno que intenta editar se solapa con otros horarios.'
		return
	END
	
	UPDATE [GD1C2012].[FEMIG].[turnos]
	   SET [horaInicio] = @pHoraInicio
		  ,[horaFin] = @pHoraFin
		  ,[descripcion] = @pDescripcion
		  ,[valorFicha] = @pValorFicha
		  ,[valorBandera] = @pValorBandera
		  ,[anulado] = @pAnulado
	 WHERE turnoID = @pTurnoID
end

GO
/****** Object:  StoredProcedure [FEMIG].[eliminarTurno]    Script Date: 06/27/2012 02:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [FEMIG].[eliminarTurno] 
	@pTurnoId			VARCHAR(10)
AS
BEGIN
	update femig.turnos set anulado = '1' where turnoID = @pTurnoId
END

GO
/****** Object:  StoredProcedure [FEMIG].[crearRendicion]    Script Date: 06/27/2012 02:34:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [FEMIG].[crearRendicion] 
	@pFecha datetime,
	@pDniChofer numeric(18),
	@pTurnoID varchar(20),
	@pImporteTotal numeric(18,5) out,
	@pCodRendicion	numeric(18) out,
	@pRetCatchError		VARCHAR(MAX) out
AS
DECLARE @iAsignacionID numeric(18)
DECLARE @iValorFicha numeric(18,2)
DECLARE @iValorBandera numeric(18,2)
DECLARE @sPatente varchar(10)
DECLARE @sNroSerieReloj varchar(18)
BEGIN

	SET @pImporteTotal = 0

	--Controlo si hay 2 Rendiciones para el mismo chofer a la misma Fecha y el mismo turno
	iF exists	(SELECT	1 FROM femig.Rendiciones
				WHERE	 (DATEDIFF(day , fecha, @pFecha)=0) AND (turnoID = @pTurnoID)
						AND (@pDniChofer = dniChofer) )
	begin
	set @pRetCatchError = 'La rendicion que intenta ingresar ya fue ingresada.'
		return
	end

	--Controlo los datos de la rendicion
	SELECT TOP(1) @iAsignacionID = asignacionId, @sPatente = patente FROM femig.ChoferAutoTurno where (turnoID=@pTurnoID) AND (dniChofer = @pDniChofer) AND (datediff(day,fecha,@pFecha)=0)
	IF (isnull(@iAsignacionID,0) = 0)
	begin
		set @pRetCatchError = 'Los datos de la rendicion son incorrectos'
		return 
	end
	
	--Controlo que el reloj este habilitado
	if exists (select 1 from FEMIG.relojes r where (select a.nroSerieReloj from FEMIG.Autos a where patente = @sPatente) = r.nroSerieReloj and r.anulado = 1)
	begin
		set @pRetCatchError = 'El rleoj se encuentra inhabilitado'
		return
	end

	SELECT @iValorFicha = valorFicha, @iValorBandera = valorBandera FROM femig.Turnos where turnoID = @pTurnoID
	
	SELECT @pImporteTotal = SUM(@iValorBandera + (cantFichas * @iValorFicha)) FROM femig.viajes 
				WHERE datediff(day,@pFecha,fecha)= 0 AND asignacionID = @iAsignacioniD AND codRendicion is null
		
	INSERT INTO [GD1C2012].[FEMIG].[Rendiciones]
           (fecha,dniChofer,turnoID,importeTotal)
    VALUES
           (@pFecha
           ,@pDniChofer
           ,@pTurnoID
           ,@pImporteTotal)
	
	SELECT @pCodRendicion = max(codRendicion) from femig.Rendiciones
	
	UPDATE femig.Viajes 
		SET codRendicion = @pCodRendicion
			WHERE asignacionID = @iASignacionID
END

GO
/****** Object:  StoredProcedure [FEMIG].[editarChoferAutoTurno]    Script Date: 06/27/2012 02:34:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [FEMIG].[editarChoferAutoTurno] 
	@pId_Asign 			numeric(18),
	@pFecha 			datetime,
	@pDniChofer		 	numeric(18),
	@pTurnoID 			numeric(20),
	@pPatente 			varchar(10),
	@retCatchError		VARCHAR(MAX) out
AS
BEGIN

	UPDATE [GD1C2012].[FEMIG].[ChoferAutoTurno]
	   SET [fecha] = @pFecha
		  ,[dniChofer] = @pDniChofer
		  ,[turnoID] = @pTurnoID
		  ,[patente] = @pPatente
		  ,[anulado] = 0 
	 WHERE asignacionID= @pId_Asign
	
END

GO
/****** Object:  StoredProcedure [FEMIG].[eliminarChoferAutoTurno]    Script Date: 06/27/2012 02:34:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [FEMIG].[eliminarChoferAutoTurno] 
	@pId_Asign			NUMERIC(18)
AS
BEGIN
	update femig.ChoferAutoTurno set anulado = '1' where asignacionID = @pId_Asign
END

GO
/****** Object:  StoredProcedure [FEMIG].[crearViaje]    Script Date: 06/27/2012 02:34:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [FEMIG].[crearViaje] 
	@pTipoViaje varchar(10),
	@pDniChofer numeric(18) ,
	@pTurnoID numeric(18) ,
	@pCantFichas numeric(18) ,
	@pFecha datetime ,
	@pDniCliente numeric(18),
	@pRetCatchError		VARCHAR(MAX) out
AS
DECLARE @iAsignacionID numeric(18) 
DECLARE @sPatente varchar(10)
BEGIN

	--Controlo que no sea el mismo viaje
	if exists (select 1 from FEMIG.viajes where dniCliente = @pDniCliente and datediff(mi,fecha,@pFecha)=0 )
	begin
		set @pRetCatchError = 'Ya fue asignado un viaje para ese cliente en esa fecha y hora'
		return
	end
	
	--Controlo los datos del viaje
	SELECT TOP(1) @iAsignacionID = asignacionId FROM femig.ChoferAutoTurno where (turnoID=@pTurnoID) AND (dniChofer = @pDniChofer) AND (datediff(day,fecha,@pFecha)=0)
	IF (isnull(@iAsignacionID,0) = 0)
	begin
		set @pRetCatchError = 'Los datos del Viaje son incorrectos'
		return 
	end

	--Controlo que el reloj este habilitado
	select @sPatente = patente from femig.choferAutoTurno where asignacionID = @iAsignacionID
	if exists (select 1 from FEMIG.relojes r where (select a.nroSerieReloj from FEMIG.Autos a where patente = @sPatente) = r.nroSerieReloj and r.anulado = 1)
	begin
		set @pRetCatchError = 'El rleoj se encuentra inhabilitado'
		return
	end

	--Controlo que el cliente este habilitado
	if exists (select 1 from FEMIG.clientes where dniCliente = @pDniCliente and anulado = 1)
	begin
		set @pRetCatchError = 'El cliente ' + cast(@pDniCliente as varchar) + ' se encuentra inhabilitado.'
		return
	end
	
	--Controlo que la asignacion este habilitada
	if exists (select 1 from FEMIG.ChoferAutoTurno where asignacionID = @iAsignacionID and anulado = 1)
	begin
		set @pRetCatchError = 'El chofer ' + cast(@pDniChofer as varchar) + ' se encuentra inhabilitado en ese turno para esa fecha.'
		return
	end
	
	INSERT INTO [GD1C2012].[FEMIG].[Viajes]
           (tipoViaje,asignacionId,cantFichas,fecha,dniCliente)
    VALUES
           (@pTipoViaje
           ,@iAsignacionID
           ,@pCantFichas
           ,@pFecha
           ,@pDniCliente)
	
END

GO
/****** Object:  StoredProcedure [FEMIG].[crearChoferAutoTurno]    Script Date: 06/27/2012 02:34:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [FEMIG].[crearChoferAutoTurno] 
	@pFecha 			datetime,
	@pDniChofer		 	numeric(18),
	@pTurnoID 			numeric(20),
	@pPatente 			varchar(10),
	@retCatchError		VARCHAR(MAX) out
AS
BEGIN

	--Controlo que para una fecha, no haya dos turnos iguales con el mismo chofer
	if exists (select 1 from FEMIG.ChoferAutoTurno where @pDniChofer=dniChofer AND datediff(day,fecha,@pFecha)=0 AND turnoID = @pTurnoID)
	begin
		set @retCatchError = 'Ya fue asignado el chofer ' + cast(@pDniChofer as varchar) + ' para la fecha ' + cast(@pFecha as varchar) + ', el turno ' + cast(@pTurnoID as varchar) + '.'
		return
	end

	--Controlo que una misma fecha un taxi no puede tener 2 turnos iguales
	if exists (select 1 from FEMIG.ChoferAutoTurno where datediff(day,fecha,@pFecha)=0 AND turnoID = @pTurnoID AND patente = @pPatente)
	begin
		set @retCatchError = 'Ya fue asignado el auto ' + cast(@pPatente as varchar) + ' para la fecha ' + cast(@pFecha as varchar) + ', el turno ' + cast(@pTurnoID as varchar) + '.'
		return
	end
	
	INSERT INTO [GD1C2012].[FEMIG].[ChoferAutoTurno]
           (fecha,dniChofer,turnoID,patente)
    VALUES
           (@pFecha
           ,@pDniChofer
           ,@pTurnoID
           ,@pPatente)
END

GO
/****** Object:  StoredProcedure [FEMIG].[editarCliente]    Script Date: 06/27/2012 02:34:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [FEMIG].[editarCliente] 
	@pDniCliente		numeric(18),
	@pNombre			VARCHAR(255),
	@pApellido			VARCHAR(255),
	@pTelefono			numeric(18),
	@pDireccion			VARCHAR(255),
	@pEmail				VARCHAR(255),
	@pFechaNacimiento 	DATETIME,
	@pAnulado			BIT,
	@rRetCatchError		VARCHAR(MAX) out
AS
BEGIN
	--Controlo que no haya duplicados de Patente
	if not exists (select 1 from FEMIG.clientes where dniCliente = @pDniCliente)
	begin
		set @rRetCatchError = 'No existe un cliente con el mismo DNI ' + @pDniCliente + '.'
		return
	end

	UPDATE [GD1C2012].[FEMIG].[clientes]
	   SET [dniCliente] = @pDniCliente
		  ,[nombre] = @pNombre
		  ,[apellido] = @pApellido
		  ,[telefono] = @pTelefono
		  ,[direccion] = @pDireccion
		  ,[email] = @pEmail
		  ,[fechaNacimiento] = @pFechaNacimiento
	 WHERE dniCliente = @pDniCliente
	
END

GO
/****** Object:  StoredProcedure [FEMIG].[crearFacturacion]    Script Date: 06/27/2012 02:34:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [FEMIG].[crearFacturacion] 
	@pFechaInicio datetime,
	@pFechaFin datetime,
	@pDniCliente numeric(18,0),
	@pImporteTotal numeric(18,2) out,
	@pCodFactura numeric(18) out,
	@pRetCatchError		VARCHAR(MAX) out
AS
DECLARE @iAsignacionID numeric(18,0)
BEGIN

	--Controlo que las fechas no sean iguales
	if (@pFechaInicio = @pFechaFin)
	begin
		set @pRetCatchError = 'Las fechas no pueden ser iguales. Las fechas se toman desde las 0hs.'
		return
	end
	--Controlo que el cliente este habilitado
	if not exists (select 1 from FEMIG.clientes where dniCliente = @pDniCliente)
	begin
		set @pRetCatchError = 'El cliente ' + cast(@pDniCliente as varchar) + ' no existe.'
		return
	end

	--Controlo que el cliente este habilitado
	if exists (select 1 from FEMIG.clientes where dniCliente = @pDniCliente and anulado = 1)
	begin
		set @pRetCatchError = 'El cliente ' + cast(@pDniCliente as varchar) + ' se encuentra inhabilitado.'
		return
	end

----------------------------------------------------
--******************REVISARRRR**********************--
----------------------------------------------------

	CREATE TABLE #ImportesCliente (viajeID numeric(18,0) PRIMARY KEY, cantFichas numeric(18,0), turnoID numeric(18,0));
	INSERT INTO #ImportesCliente (viajeID, cantFichas, turnoID)
	SELECT vi.viajeID, vi.cantFichas, cat.turnoID FROM Femig.viajes vi
	INNER JOIN GD1C2012.FEMIG.ChoferAutoTurno cat on cat.asignacionId = vi.asignacionId
	WHERE vi.dniCliente = @pDniCliente AND vi.fecha BETWEEN CONVERT(varchar(8), @pFechaInicio, 112) AND CONVERT(varchar(8), @pFechaFin, 112) AND vi.codFactura is null;
	
	SELECT @pImporteTotal = SUM(tur.valorBandera + (iC.CantFichas * tur.valorFicha)) FROM #ImportesCliente iC
	INNER JOIN GD1C2012.FEMIG.turnos tur on tur.turnoID = iC.turnoID;

	if (isnull(@pImporteTotal,0)=0)
	begin
		set @pRetCatchError = 'No existen viajes en el rango de la fecha para el cliente ' + cast(@pDniCliente as varchar) + '.'
		return
	end

	INSERT INTO [GD1C2012].[FEMIG].[Facturas]
           (fechaInicio,fechaFin,dniCliente,importeTotal)
    VALUES
           (@pFechaInicio
           ,@pFechaFin
           ,@pDniCliente
           ,@pImporteTotal)
	
	SELECT @pCodFactura = max(codFactura) from femig.Facturas;
	UPDATE femig.Viajes
		SET codFactura = @pCodFactura
			WHERE viajeID IN (SELECT ic.viajeID FROM #ImportesCliente ic where viajeID = ic.viajeID)
	DROP TABLE #ImportesCliente

END

GO
/****** Object:  StoredProcedure [FEMIG].[editarPantalla]    Script Date: 06/27/2012 02:34:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [FEMIG].[editarPantalla] 
	@pPantallaID		VARCHAR(255),
	@pDescripcion		VARCHAR(255),
	@pRetCatchError		VARCHAR(1000) out
AS
BEGIN
	--Controlo que no haya duplicados de Patente
	if not exists (select 1 from FEMIG.Pantalla where pantallaID = @pPantallaID)
	begin
		set @pRetCatchError = 'No existe la Pantalla ' + cast(@pPantallaID as varchar) + '.'
		return
	END
		
	UPDATE [GD1C2012].[FEMIG].[Pantalla]
	   SET [descripcion] = @pDescripcion
	 WHERE pantallaID = @pPantallaID
		
END

GO
/****** Object:  StoredProcedure [FEMIG].[getPantallasDeRol]    Script Date: 06/27/2012 02:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [FEMIG].[getPantallasDeRol]
	@pRolID	VARCHAR(20)
AS
BEGIN
	SELECT 'True' AS chk,P.PANTALLAID AS pantallaID,P.DESCRIPCION 
	FROM FEMIG.ROLPANTALLA RP
	INNER JOIN FEMIG.PANTALLA P ON (RP.PANTALLAID = P.PANTALLAID)
	WHERE ROLID = @pRolID
	UNION
	SELECT 'False' AS chk,PANTALLAID AS pantallaID,P.DESCRIPCION  FROM FEMIG.PANTALLA P
	WHERE NOT EXISTS (SELECT 1 FROM FEMIG.ROLPANTALLA RP WHERE RP.ROLID = @pRolID AND RP.PANTALLAID = P.PANTALLAID)
END

GO
/****** Object:  StoredProcedure [FEMIG].[ObtenerFuncionalidades]    Script Date: 06/27/2012 02:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [FEMIG].[ObtenerFuncionalidades]
	@pUsuarioID	 varchar(20)	
AS
BEGIN
	Select P.pantallaID, P.descripcion
    from FEMIG.Usuario U
    inner join FEMIG.RolUsuario RU on (U.usuarioID = RU.usuarioID)
    inner join FEMIG.Rol R on (RU.rolID = R.rolID)
    inner join FEMIG.RolPantalla RP on (R.rolID = RP.rolID)
    inner join FEMIG.Pantalla P on (RP.pantallaID = P.pantallaID)
    where	isnull(U.anulado,'0')='0'
            and isnull(R.anulado,'0')='0'
            and U.usuarioID = @pUsuarioID
            and isnull(RP.acceso,'0')='1'
    ORDER BY P.DESCRIPCION
END

GO
/****** Object:  StoredProcedure [FEMIG].[getRolesDeUsuario]    Script Date: 06/27/2012 02:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [FEMIG].[getRolesDeUsuario]
	@pUsuarioID	VARCHAR(20)
AS
BEGIN
	SELECT 'True' AS chk,R.ROLID AS rolID,R.DESCRIPCION 
	FROM FEMIG.ROLUSUARIO RU
	INNER JOIN FEMIG.ROL R ON (RU.ROLID = R.ROLID)
	WHERE RU.usuarioID = @pUsuarioID
	UNION
	SELECT 'False' AS chk,ROLID AS rolID,R.DESCRIPCION  FROM FEMIG.ROL R
	WHERE NOT EXISTS (SELECT 1 FROM FEMIG.ROLUSUARIO RU WHERE RU.UsuarioID = @pUsuarioID AND RU.ROLID = R.ROLID)
END

GO
/****** Object:  StoredProcedure [FEMIG].[crearRol]    Script Date: 06/27/2012 02:34:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [FEMIG].[crearRol] 
	@pRolID				VARCHAR(20),
	@pDescripcion		VARCHAR(50),
	@pAnulado			BIT,
	@pRetCatchError		VARCHAR(1000) out
AS
BEGIN
	if exists (select 1 from FEMIG.Rol where rolID = @pRolID)
	begin
		set @pRetCatchError = 'Ya existe el rol ' + @pRolID + '.'
		return
	end

	INSERT INTO [GD1C2012].[FEMIG].[Rol]
           (rolID, descripcion, anulado)
    VALUES
           (@pRolID
           ,@pDescripcion
           ,@pAnulado)
	
END

GO
/****** Object:  StoredProcedure [FEMIG].[eliminarRol]    Script Date: 06/27/2012 02:34:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [FEMIG].[eliminarRol] 
	@pRolID			VARCHAR(20)
AS
BEGIN
	update femig.Rol set anulado = '1' where rolID = @pRolID
END
GO
/****** Object:  StoredProcedure [FEMIG].[editarRol]    Script Date: 06/27/2012 02:34:48 ******/
SET ANSI_NULLS ON

GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [FEMIG].[editarRol] 
	@pRolID				VARCHAR(20),
	@pDescripcion		VARCHAR(50),
	@pAnulado			BIT,
	@pRetCatchError		VARCHAR(1000) out
AS
BEGIN
	--Controlo que no haya duplicados de Patente
	if not exists (select 1 from FEMIG.Rol where rolID = @pRolID)
	begin
		set @pRetCatchError = 'No existe el Rol ' + @pRolID + '.'
		return
	end

	UPDATE [GD1C2012].[FEMIG].[Rol]
	   SET [descripcion] = @pDescripcion
		  ,[anulado] = @pAnulado
	 WHERE rolID = @pRolID
	
END

GO
/****** Object:  StoredProcedure [FEMIG].[AsignarDesasignarRolPantalla]    Script Date: 06/27/2012 02:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [FEMIG].[AsignarDesasignarRolPantalla]
	@pRolID			VARCHAR(20),
	@pPantallaID	VARCHAR(255)
AS
BEGIN
	
	IF NOT EXISTS (SELECT 1 FROM FEMIG.ROLPANTALLA WHERE ROLID = @pRolID AND PANTALLAID = @pPantallaID)
		INSERT INTO FEMIG.ROLPANTALLA VALUES (@pRolID, @pPantallaID, '1')
	ELSE
		DELETE FROM FEMIG.ROLPANTALLA WHERE ROLID = @pRolID AND PANTALLAID = @pPantallaID
	
END

GO
/****** Object:  StoredProcedure [FEMIG].[verificarCredencialesLogueo]    Script Date: 06/27/2012 02:34:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [FEMIG].[verificarCredencialesLogueo]
	@pUsuario	VARCHAR(20),
	@pClave		VARCHAR(100),
	@pResultado	BIT OUT

AS
DECLARE @clave VARCHAR(100)
BEGIN
	
	SELECT @clave = password from Usuario where usuarioID = @pUsuario AND ISNULL(anulado,'0')='0'

	set @pResultado = 0

	if @clave = @pClave
		Set @pResultado = 1
	else
		Set @pResultado = 0

	return @pResultado
		
END

GO
/****** Object:  StoredProcedure [FEMIG].[crearUsuario]    Script Date: 06/27/2012 02:34:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [FEMIG].[crearUsuario] 
	@pUsuarioID			VARCHAR(20),
	@pNombre			VARCHAR(50),
	@pApellido			VARCHAR(50),
	@pEmail				VARCHAR(100),
	@pPassword			VARCHAR(64),
	@pCantMaxIntentos	NUMERIC(18,0),
	@pAnulado			BIT,
	@pRetCatchError		VARCHAR(1000) out
AS
BEGIN
	--Controlo que no haya duplicados de Patente
	if exists (select 1 from FEMIG.Usuario where usuarioID = @pUsuarioID)
	begin
		set @pRetCatchError = 'Ya existe el usuario ' + @pUsuarioID + '.'
		return
	end

	--Controlo que no haya 2 autos activos con el mismo reloj
	if exists (select 1 from FEMIG.Usuario where email = @pEmail and isnull(anulado,'0')='0')
	begin
		set @pRetCatchError = 'Ya existe un usuario con el email ' + cast(@pEmail as varchar) + '.'
		return
	END
	
	INSERT INTO [GD1C2012].[FEMIG].[Usuario]
           (usuarioID,nombre,apellido,email,password,cantIntentosFallo,cantMaxIntentos,anulado)
    VALUES
           (@pUsuarioID
           ,@pNombre
           ,@pApellido
           ,@pEmail
           ,@pPassword
           ,0
           ,@pCantMaxIntentos
           ,@pAnulado)
	
END

GO
/****** Object:  StoredProcedure [FEMIG].[editarUsuario]    Script Date: 06/27/2012 02:34:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [FEMIG].[editarUsuario] 
	@pUsuarioID			VARCHAR(20),
	@pNombre			VARCHAR(50),
	@pApellido			VARCHAR(50),
	@pEmail				VARCHAR(100),
	@pPassword			VARCHAR(64),
	@pCantMaxIntentos	NUMERIC(18,0),
	@pAnulado			BIT,
	@pRetCatchError		VARCHAR(1000) out
AS
BEGIN
	--Controlo que no haya duplicados de Usuario ID
	if not exists (select 1 from FEMIG.Usuario where usuarioID = @pUsuarioID)
	begin
		set @pRetCatchError = 'No existe el usuario ID ' + @pUsuarioID + '.'
		return
	end

	--Controlo que no haya 2 Usuarios activos con el mismo reloj
	if exists (select 1 from FEMIG.Usuario where usuarioID <> @pUsuarioID and email = @pEmail and isnull(anulado,'0')='0')
	begin
		set @pRetCatchError = 'Ya existe un usuario con el email ' + cast(@pEmail as varchar) + '.'
		return
	end

	UPDATE [GD1C2012].[FEMIG].[Usuario]
	   SET [nombre] = @pNombre
		  ,[apellido] = @pApellido
		  ,[email] = @pEmail
		  ,[password] = @pPassword
		  ,[cantMaxIntentos] = @pCantMaxIntentos
		  ,[anulado] = @pAnulado
	 WHERE usuarioID = @pUsuarioID
	
END

GO
/****** Object:  StoredProcedure [FEMIG].[eliminarUsuario]    Script Date: 06/27/2012 02:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [FEMIG].[eliminarUsuario] 
	@pUsuarioID			VARCHAR(20)
AS
BEGIN
	update femig.Usuario set anulado = '1' where usuarioID = @pUsuarioID
END

GO
/****** Object:  StoredProcedure [FEMIG].[AsignarDesasignarRolUsuario]    Script Date: 06/27/2012 02:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [FEMIG].[AsignarDesasignarRolUsuario]
	@pUsuarioID		VARCHAR(20),
	@pRolID			VARCHAR(255)
AS
BEGIN
	
	IF NOT EXISTS (SELECT 1 FROM FEMIG.ROLUSUARIO WHERE USUARIOID = @pUsuarioID AND ROLID = @pRolID)
		INSERT INTO FEMIG.ROLUSUARIO VALUES (@pUsuarioID, @pRolID)
	ELSE
		DELETE FROM FEMIG.ROLUSUARIO WHERE USUARIOID = @pUsuarioID AND ROLID = @pRolID
	
END

GO
/****** Object:  StoredProcedure [FEMIG].[crearReloj]    Script Date: 06/27/2012 02:34:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [FEMIG].[crearReloj] 
	@pNroSerieReloj		NUMERIC(18,0),
	@pMarca				VARCHAR(255),
	@pModelo			VARCHAR(255),
	@pFechaVersion		DATETIME,
	@pAnulado			BIT,
	@pRetCatchError		VARCHAR(1000) out
AS
BEGIN
	--Controlo que no haya duplicados de Patente
	if exists (select 1 from FEMIG.relojes where nroSerieReloj = @pNroSerieReloj)
	begin
		set @pRetCatchError = 'Ya existe un reloj con la serie ' + @pNroSerieReloj + '.'
		return
	end

	INSERT INTO [GD1C2012].[FEMIG].[relojes]
           (nroSerieReloj,marca,modelo,fechaVersion,anulado)
    VALUES
           (@pNroSerieReloj
           ,@pMarca
           ,@pModelo
           ,@pFechaVersion
           ,'0')
	
END

GO
/****** Object:  StoredProcedure [FEMIG].[editarReloj]    Script Date: 06/27/2012 02:34:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [FEMIG].[editarReloj] 
	@pNroSerieReloj		NUMERIC(18,0),
	@pMarca				VARCHAR(255),
	@pModelo			VARCHAR(255),
	@pFechaVersion		DATETIME,
	@pAnulado			BIT,
	@pRetCatchError		VARCHAR(1000) out
AS
BEGIN
	--Controlo que no haya duplicados de Patente
	if not exists (select 1 from FEMIG.relojes where nroSerieReloj = @pNroSerieReloj)
	begin
		set @pRetCatchError = 'No existe un reloj con la serie ' + @pNroSerieReloj + '.'
		return
	end

	UPDATE [GD1C2012].[FEMIG].[relojes]
	   SET [marca] = @pMarca
		  ,[modelo] = @pModelo
		  ,[fechaVersion] = @pFechaVersion
		  ,[anulado] = @pAnulado
	 WHERE nroSerieReloj = @pNroSerieReloj
	
END

GO
/****** Object:  StoredProcedure [FEMIG].[eliminarReloj]    Script Date: 06/27/2012 02:34:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [FEMIG].[eliminarReloj] 
	@pNroSerieReloj			VARCHAR(10)
AS
BEGIN
	update femig.relojes set anulado = '1' where nroSerieReloj = @pNroSerieReloj
END
GO

/*++++++++++++++++++++++++++++++++++++++*/
/*		Triggers						*/
/*++++++++++++++++++++++++++++++++++++++*/
GO
/****** Object:  Trigger femig.modifRelecionAuto    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER femig.modifRelecionAuto
ON femig.autos
AFTER UPDATE

AS 

DECLARE @anulado BIT
DECLARE @patente VARCHAR(10)
DECLARE @dniChofer NUMERIC(18,0)
DECLARE @turnoID NUMERIC(18,0)

if update(anulado)
BEGIN

	-- SET NOCOUNT ON impide que se generen mensajes de texto con cada instrucción 

	SET NOCOUNT ON;

	SELECT TOP(1) @anulado = anulado, @patente = patente FROM INSERTED
	if(@anulado = 1)
	begin
		UPDATE femig.ChoferAutoTurno SET anulado = @anulado WHERE patente = @patente
	end
	else
	begin
		UPDATE cat SET anulado = @anulado FROM femig.choferAutoTurno cat WHERE patente = @patente AND 
			NOT EXISTS (select 1 from femig.choferes c where c.dniChofer=cat.dniChofer AND anulado = 1) AND
				NOT EXISTS (select 1 from femig.turnos t where t.turnoID=cat.turnoID AND anulado = 1)
	end
END
GO
/*--------------------------------------------*/
GO
/****** Object:  Trigger femig.modifRelecionChofer    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER femig.modifRelecionChofer
ON femig.choferes
AFTER UPDATE

AS 

DECLARE @anulado BIT
DECLARE @patente VARCHAR(10)
DECLARE @dniChofer NUMERIC(18,0)
DECLARE @turnoID NUMERIC(18,0)

if update(anulado)
BEGIN

	-- SET NOCOUNT ON impide que se generen mensajes de texto con cada instrucción 

	SET NOCOUNT ON;

	SELECT TOP(1) @anulado = anulado, @dniChofer = dniChofer FROM INSERTED
	if(@anulado = 1)
	begin
		UPDATE femig.ChoferAutoTurno SET anulado = @anulado WHERE dniChofer = @dniChofer 
	end
	else
	begin
		UPDATE cat SET anulado = @anulado FROM femig.choferAutoTurno cat WHERE dniChofer = @dniChofer AND 
			NOT EXISTS (select 1 from femig.autos a where a.patente=cat.patente AND anulado = 1) AND
				NOT EXISTS (select 1 from femig.turnos t where t.turnoID=cat.turnoID AND anulado = 1)
	end

END
GO

/*--------------------------------------------*/
GO
/****** Object:  Trigger femig.modifRelecionTurno    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER femig.modifRelecionTurno
ON femig.turnos
AFTER UPDATE

AS 

DECLARE @anulado BIT
DECLARE @patente VARCHAR(10)
DECLARE @dniChofer NUMERIC(18,0)
DECLARE @turnoID NUMERIC(18,0)

if update(anulado)
BEGIN

	-- SET NOCOUNT ON impide que se generen mensajes de texto con cada instrucción 
	
	SET NOCOUNT ON;
	
	SELECT TOP(1) @anulado = anulado, @turnoID = turnoID FROM INSERTED
	if(@anulado = 1)
	begin
		UPDATE femig.ChoferAutoTurno SET anulado = @anulado WHERE turnoID = @turnoID 
	end
	else
	begin
		UPDATE cat SET anulado = @anulado FROM femig.choferAutoTurno cat WHERE turnoID = @turnoID AND 
			NOT EXISTS (select 1 from femig.autos a where a.patente=cat.patente AND anulado = 1) AND
				NOT EXISTS (select 1 from femig.choferes c where c.dniChofer=cat.dniChofer AND anulado = 1)
	end

END
GO