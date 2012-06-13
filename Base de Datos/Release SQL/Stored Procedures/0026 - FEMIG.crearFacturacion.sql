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
	@pImporteTotal numeric(18,5),
	@pRetCatchError		VARCHAR(MAX) out
AS

BEGIN

	/*Controlo si 2 Rendiciones para el mismo chofer a la misma Fecha
	iF exists	(SELECT	1 FROM femig.Facturas
				WHERE)
	begin
	set @pRetCatchError = 'La rendicion que intenta ingresar ya fue ingresada.'
		return
	end*/
		
	INSERT INTO [GD1C2012].[FEMIG].[Facturas]
           (fechaInicio,fechaFin,dniCliente,importeTotal)
    VALUES
           (@pFechaInicio
           ,@pFechaFin
           ,@pDniCliente
           ,@pImporteTotal)
END