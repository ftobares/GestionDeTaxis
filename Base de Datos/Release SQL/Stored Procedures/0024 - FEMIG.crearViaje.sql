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
	
	if exists (select 1 from FEMIG.clientes where dniCliente = @pDniCliente and anulado = 1)
	begin
		set @pRetCatchError = 'El cliente ' + @pDniCliente + ' se encuentra inhabilitado.'
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

