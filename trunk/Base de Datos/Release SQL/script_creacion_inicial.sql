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

CREATE TABLE GD1C2012.FEMIG.Rendiciones ( 
	codRendicion numeric(18) NOT NULL PRIMARY KEY CLUSTERED IDENTITY(1,1),
	fecha datetime NOT NULL,
	dniChofer numeric(18) NOT NULL,
	turnoID varchar(20) NOT NULL,
	importeTotal numeric(18,2) NOT NULL
);

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

	/*Inicio de Migración de datos para la tabla Viajes*/
	BEGIN

		CREATE TABLE #maestra(
			chofer_dni numeric(8) NOT NULL,
			cliente_dni numeric(8),
			viaje_cant_fichas numeric(1) NOT NULL,
			viaje_fecha datetime NOT NULL
		);
		CREATE INDEX IDX_maestra_1 ON #maestra(chofer_dni);
		INSERT INTO #maestra (chofer_dni,cliente_dni,viaje_cant_fichas,viaje_fecha)
		SELECT chofer_dni,cliente_dni,viaje_cant_fichas,viaje_fecha
		FROM gd_esquema.maestra;

		INSERT INTO femig.viajes (tipoViaje,asignacionID,cantFichas,fecha,dniCliente,codFactura,codRendicion)
		SELECT 'cliente' as tipoViaje,cat.asignacionID,m.viaje_cant_fichas,m.viaje_fecha,m.cliente_dni,fac.codFactura,ren.codRendicion
		FROM #maestra m
		INNER JOIN femig.facturas fac ON m.cliente_dni = fac.dniCliente
		INNER JOIN femig.choferautoturno cat ON m.chofer_dni = cat.dniChofer
		INNER JOIN femig.rendiciones ren ON m.chofer_dni = ren.dniChofer
		WHERE m.cliente_dni is not null;

		INSERT INTO femig.viajes (tipoViaje,asignacionID,cantFichas,fecha,dniCliente,codFactura,codRendicion)
		SELECT 'calle' as tipoViaje,cat.asignacionID,m.viaje_cant_fichas,m.viaje_fecha,m.cliente_dni,fac.codFactura,ren.codRendicion
		FROM #maestra m
		INNER JOIN femig.facturas fac ON m.cliente_dni = fac.dniCliente
		INNER JOIN femig.choferautoturno cat ON m.chofer_dni = cat.dniChofer
		INNER JOIN femig.rendiciones ren ON m.chofer_dni = ren.dniChofer
		WHERE m.cliente_dni is not null;
		
		DROP TABLE #maestra;
	END
	/*Finalización de Migración de datos para la tabla Viajes*/

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

	/*ROL*/
	INSERT INTO FEMIG.Rol VALUES ('Administrador','Administrador de Sistema')
	
	INSERT INTO FEMIG.ROLPANTALLA
	SELECT 'Administrador',PANTALLAID,'1' FROM FEMIG.PANTALLA
	
	/*Carga Inicial de Usuario Administrador General*/
	INSERT INTO femig.usuario (nombre,apellido,email,password,cantIntentosFallo,cantMaxIntentos)
	VALUE('Admin','Administrador','admin@taxis.com.ar','E6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7',0,10)	
	
	INSERT INTO FEMIG.rolusuario VALUES ('Admin','Administrador')

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

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*PRC 0001 - Procedure Obtener Funcionalidades*/
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
END

/*PRC 0002 - Procedure Verificar Credenciales Logueo*/
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

/*PRC 0003 - Procedure Crear Auto*/
CREATE PROCEDURE [FEMIG].[crearAuto] 
	@pPatente			VARCHAR(10),
	@pMarca				VARCHAR(255),
	@pModelo			VARCHAR(255),
	@pLicencia			VARCHAR(26),
	@pRodado			VARCHAR(10),
	@pNroSerieReloj		NUMERIC(18,0),
	@pAnulado			BIT,
	@retCatchError		VARCHAR(MAX) out
AS
BEGIN
	--Controlo que no haya duplicados de Patente
	if exists (select 1 from FEMIG.autos where patente = @pPatente)
	begin
		set @retCatchError = 'Ya existe un auto con la patente ' + @pPatente + '.'
		return
	end

	--Controlo que no haya 2 autos activos con el mismo reloj
	if exists (select 1 from FEMIG.autos where nroSerieReloj = @pNroSerieReloj and isnull(anulado,'0')='0')
	begin
		set @retCatchError = 'Ya existe un auto con el reloj ' + cast(@pNroSerieReloj as varchar) + '.'
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

/*PRC 0004 - Procedure Editar Auto*/
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
		set @pRetCatchError = 'No existe un auto con la patente ' + @pPatente + '.'
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
	 WHERE patente = @pPatente
	
END

/*PRC 0005 - Procedure Eliminar Auto*/
CREATE PROCEDURE [FEMIG].[eliminarAuto] 
	@pPatente			VARCHAR(10)
AS
BEGIN
	update femig.autos set anulado = '1' where patente = @pPatente
END

/*PRC 0006 - Procedure Alta Cliente*/
CREATE PROCEDURE [FEMIG].[cliente] 
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
	--Controlo que no haya duplicados de Patente
	if exists (select 1 from FEMIG.cliente where dniCliente = @pDniCliente)
	begin
		set @retCatchError = 'Ya existe un cliente con el mismo DNI ' + @pDniCliente + '.'
		return
	end

	INSERT INTO [GD1C2012].[FEMIG].[cliente]
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

/*PRC 0007 - Procedure Modificar Cliente*/
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

/*PRC 0008 - Procedure Eliminar Cliente*/
CREATE PROCEDURE [FEMIG].[eliminarCliente] 
	@pDniCliente			NUMERIC(18)
AS
BEGIN
	update femig.cliente set anulado = '1' where dniCliente = @pDniCliente
END

/*PRC 0009 - Procedure Crear Turno*/
CREATE PROCEDURE [FEMIG].[crearTurno] 
	@pHoraInicio 		numeric(18),
	@pHoraFin 			numeric(18),
	@pDescripcion 		varchar(255),
	@pValorFicha 		numeric(18,2),
	@pValorBandera 		numeric(18,2),
	@pAnulado 			bit,
	@retCatchError		VARCHAR(MAX) out
AS
BEGIN

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

/*PRC 0010 - Procedure Editar Turno*/
CREATE PROCEDURE [FEMIG].[editarTurno] 
	@pTurnoID			numeric(20),
	@pHoraInicio 		numeric(18),
	@pHoraFin 			numeric(18),
	@pDescripcion 		varchar(255),
	@pValorFicha 		numeric(18,2),
	@pValorBandera 		numeric(18,2),
	@pAnulado 			bit,
	@retCatchError		VARCHAR(MAX) out
AS
BEGIN

	UPDATE [GD1C2012].[FEMIG].[turnos]
	   SET [horaInicio] = @pHoraInicio
		  ,[horaFin] = @pHoraFin
		  ,[descripcion] = @pDescripcion
		  ,[valorFicha] = @pValorFicha
		  ,[valorBandera] = @pValorBandera
	 WHERE turnoID = @pTurnoID
	
END

/*PRC 0011 - Procedure Eliminar Turno*/
CREATE PROCEDURE [FEMIG].[eliminarTurno] 
	@pTurnoID			NUMERIC(18)
AS
BEGIN
	update femig.turnos set anulado = '1' where turnoID = @pTurnoID
END

/*PRC 0012 - Procedure Crear Chofer-Auto-Turno*/
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

/*PRC 0013 - Procedure Crear Chofer*/
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

/*PRC 0014 - Procedure Editar Chofer*/
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
	 WHERE dniChofer = @pDniChofer
		
END

/*PRC 0015 - Procedure Eliminar Chofer*/
CREATE PROCEDURE [FEMIG].[eliminarChofer] 
	@pDniChofer			VARCHAR(10)
AS
BEGIN
	update femig.choferes set anulado = '1' where dniChofer = @pDniChofer
END

/*PRC 0016 - Procedure Crear Rol*/
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

/*PRC 0017 - Procedure Editar Reloj*/
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
	 WHERE nroSerieReloj = @pNroSerieReloj
	
END

/*PRC 0018 - Procedure Eliminar Reloj*/
CREATE PROCEDURE [FEMIG].[eliminarReloj] 
	@pNroSerieReloj			VARCHAR(10)
AS
BEGIN
	update femig.relojes set anulado = '1' where nroSerieReloj = @pNroSerieReloj
END

/*PRC 0019 - Procedure Crear Turno*/
CREATE PROCEDURE [FEMIG].[crearTurno] 
	@pTurnoId			NUMERIC(18,0),
	@pDescripcion		VARCHAR(10),
	@pHoraInicio		VARCHAR(255),
	@pHoraFin			VARCHAR(255),
	@pValorFicha		VARCHAR(26),
	@pValorBandera		VARCHAR(10),
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

/*PRC 0020 - Procedure Editar Turno*/
CREATE PROCEDURE [FEMIG].[editarTurno] 
	@pTurnoId			NUMERIC(18,0),
	@pDescripcion		VARCHAR(10),
	@pHoraInicio		VARCHAR(255),
	@pHoraFin			VARCHAR(255),
	@pValorFicha		VARCHAR(26),
	@pValorBandera		VARCHAR(10),
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
	SET descripcion = @pDescripcion
		,horaFin = @pHoraFin
		,horaInicio = @pHoraInicio
		,valorBandera = @pValorBandera
		,valorFicha = @pValorFicha
	WHERE turnoID = @pTurnoId
END

/*PRC 0021 - Procedure Eliminar Turno*/
CREATE PROCEDURE [FEMIG].[eliminarTurno] 
	@pTurnoId			VARCHAR(10)
AS
BEGIN
	update femig.turnos set anulado = '1' where turnoID = @pTurnoId
END

/*PRC 0022 - Procedure Editar Chofer-Auto-Turno*/
CREATE PROCEDURE FEMIG.editarChoferAutoTurno 
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
	 WHERE asignacionID= @pId_Asign
	
END

/*PRC 0023 - Procedure Eliminar Chofer-Auto-Turno*/
CREATE PROCEDURE [FEMIG].[eliminarChoferAutoTurno] 
	@pId_Asign			NUMERIC(18)
AS
BEGIN
	update femig.ChoferAutoTurno set anulado = '1' where asignacionID = @pId_Asign
END

/*PRC 0024 - Procedure Alta Viaje*/
CREATE PROCEDURE [FEMIG].[crearViaje] 
	@pTipoViaje varchar(10),
	@pDniChofer numeric(18) ,
	@pTurnoID numeric(18) ,
	@pCantFichas numeric(18) ,
	@pFecha datetime ,
	@pDniCliente numeric(18),
	@pRetCatchError		VARCHAR(MAX) out
AS
DECLARE @sFecha varchar(MAX) 
--SET @sFecha = SUBSTRING(cast(@pFecha as varchar),0,10) + ' %'
DECLARE @iAsignacionID numeric(18) 
BEGIN

	--SET @iAsignacionID = SELECT TOP(1) asignacionId FROM femig.ChoferAutoTurno where (turnoID=@pTurnoID AND dniChofer = @pDniChofer AND fecha = @sFecha )
	SELECT TOP(1) @iAsignacionID = asignacionId FROM femig.ChoferAutoTurno where (turnoID=@pTurnoID) AND (dniChofer = @pDniChofer) AND (datediff(day,fecha,@pFecha)=0)
	IF (isnull(@iAsignacionID,0) = 0)
	begin
		set @pRetCatchError = 'Los datos del Viaje son incorrectos'
		return 
	end
	
	/*IF (@pTipoViaje = 'calle')
	begin
		set @pDniCliente = null;
	end*/
		
	INSERT INTO [GD1C2012].[FEMIG].[Viajes]
           (tipoViaje,asignacionId,cantFichas,fecha,dniCliente)
    VALUES
           (@pTipoViaje
           ,@iAsignacionID
           ,@pCantFichas
           ,@pFecha
           ,@pDniCliente)
	
END

/*PRC 0025 - Procedure Crear Rendicion*/
CREATE PROCEDURE [FEMIG].[crearRendicion] 
	@pFecha datetime,
	@pDniChofer numeric(18),
	@pTurnoID varchar(20),
	@pImporteTotal numeric(18,5) out,
	@pRetCatchError		VARCHAR(MAX) out
AS

BEGIN

	--Controlo si hay 2 Rendiciones para el mismo chofer a la misma Fecha y el mismo turno
	iF exists	(SELECT	1 FROM femig.Rendiciones
				WHERE	 (DATEDIFF(day , fecha, @pFecha)=0) AND (turnoID = @pTurnoID)
						AND (@pDniChofer = dniChofer) )
	begin
	set @pRetCatchError = 'La rendicion que intenta ingresar ya fue ingresada.'
		return
	end
	/*SELECT @pImporteTotal = SUM(tur.valorBandera + (vi.cantFichas * tur.valorFicha)) FROM femig.viajes vi
		INNER JOIN GD1C2012.FEMIG.turnos tur on @pTurnoID = tur.turnoID
			INNER JOIN GD1C2012.FEMIG.ChoferAutoTurno ch on @pDniChofer = ch.dniChofer 
				WHERE datediff(day,@pFecha,vi.fecha)= 0*/
		
	INSERT INTO [GD1C2012].[FEMIG].[Rendiciones]
           (fecha,dniChofer,turnoID,importeTotal)
    VALUES
           (@pFecha
           ,@pDniChofer
           ,@pTurnoID
           ,@pImporteTotal)
END

/*PRC 0026 - Procedure Crear Factura*/
CREATE PROCEDURE [FEMIG].[crearFacturacion] 
	@pFechaInicio datetime,
	@pFechaFin datetime,
	@pDniCliente numeric(18),
	@pImporteTotal numeric(18,5) out,
	@pRetCatchError		VARCHAR(MAX) out
AS

BEGIN

	SET @pImporteTotal = 0
	DECLARE @canFichas numeric(18)
	
	--SELECT @canFichas = SUM(cantFichas) FROM FEMIG.viajes WHERE (dniCliente = @pDniCliente AND fecha >= @pFechaInicio AND fecha <= @pFechaFin AND codFactura = null)
	

		
	INSERT INTO [GD1C2012].[FEMIG].[Facturas]
           (fechaInicio,fechaFin,dniCliente,importeTotal)
    VALUES
           (@pFechaInicio
           ,@pFechaFin
           ,@pDniCliente
           ,@pImporteTotal)

END

/*PRC 0027 - Procedure Crear Usuario*/
CREATE PROCEDURE [FEMIG].[crearUsuario] 
	@pUsuarioID			VARCHAR(10),
	@pNombre			VARCHAR(255),
	@pApellido			VARCHAR(255),
	@pEmail				VARCHAR(26),
	@pPassword			VARCHAR(10),
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
           ,'0')
	
END

/*PRC 0028 - Procedure Editar Usuario*/
CREATE PROCEDURE [FEMIG].[editarUsuario] 
	@pUsuarioID			VARCHAR(10),
	@pNombre			VARCHAR(255),
	@pApellido			VARCHAR(255),
	@pEmail				VARCHAR(26),
	@pPassword			VARCHAR(10),
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

/*PRC 0029 - Procedure Eliminar Usuario*/
CREATE PROCEDURE [FEMIG].[eliminarUsuario] 
	@pUsuarioID			VARCHAR(10)
AS
BEGIN
	update femig.Usuario set anulado = '1' where usuarioID = @pUsuarioID
END

/*PRC 0030 - Procedure */
