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
	@pImporteTotal numeric(18,5),
	@pRetCatchError		VARCHAR(MAX) out
AS

BEGIN

	--Controlo si 2 Rendiciones para el mismo chofer a la misma Fecha
	iF exists	(SELECT	1 FROM femig.Rendiciones
				WHERE	 (fecha = @pFecha)
						AND (@pDniChofer = dniChofer))
	begin
	set @pRetCatchError = 'La rendicion que intenta ingresar ya fue ingresada.'
		return
	end
		
	INSERT INTO [GD1C2012].[FEMIG].[Rendiciones]
           (fecha,dniChofer,turnoID,importeTotal)
    VALUES
           (@pFecha
           ,@pDniChofer
           ,cast(@pTurnoID AS bigint)
           ,@pImporteTotal)
END