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
	@pDniCliente numeric(18,0),
	@pImporteTotal numeric(18,2) out,
	@pCodFactura numeric(18) out,
	@pRetCatchError		VARCHAR(MAX) out
AS
DECLARE @iAsignacionID numeric(18,0)
BEGIN

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
			WHERE viajeID = (SELECT viajeID FROM #ImportesCliente);
	DROP TABLE #ImportesCliente

END