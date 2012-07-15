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