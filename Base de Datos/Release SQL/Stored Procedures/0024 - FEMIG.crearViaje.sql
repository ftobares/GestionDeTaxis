USE [GD1C2012]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
SET @sFecha = CAST(CONVERT(CHAR(10), @pFecha, 101) AS varchar) + ' %'
DECLARE @iAsignacionID numeric(18) 
BEGIN

	--Controlo si 2 Viajes para el mismo cliente a la misma fecha y hora
	iF exists	(SELECT	1 FROM femig.Viajes
				WHERE	 (fecha = @pFecha)
						AND (@pDniCliente = dniCliente))
	begin
		set @pRetCatchError = 'El Viaje que intenta ingresar ya fue ingresado.'
		return
	end
	
	--SET @iAsignacionID = SELECT TOP(1) asignacionId FROM femig.ChoferAutoTurno where (turnoID=@pTurnoID AND dniChofer = @pDniChofer AND fecha = @sFecha )
	SELECT TOP(1) @iAsignacionID = asignacionId FROM femig.ChoferAutoTurno where (turnoID=@pTurnoID AND dniChofer = @pDniChofer AND fecha = @sFecha )
	IF (@iAsignacionID != null)
	begin
		set @pRetCatchError = 'El Chofer no esta registrado para ese turno y fecha '
		return
	end
	
	IF (@pTipoViaje = 'registrado')
	begin
		set @pDniCliente = null;
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