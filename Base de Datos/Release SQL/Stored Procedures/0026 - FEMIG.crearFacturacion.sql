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