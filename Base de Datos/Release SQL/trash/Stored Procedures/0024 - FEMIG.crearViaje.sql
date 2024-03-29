set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/*+++++++++++++++++++++++++++++++++++++++
* Grupo: FEMIG							*			
*                                       *
* Integrantes:                          *
*	Emiliano Marcelo Ibarrola           *
*	Marcos Andres Ibarrola              *
*	Ignacio Angel Tata                  *
*	Fernando N. Tobares Garcia          *
*+++++++++++++++++++++++++++++++++++++++*/
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

