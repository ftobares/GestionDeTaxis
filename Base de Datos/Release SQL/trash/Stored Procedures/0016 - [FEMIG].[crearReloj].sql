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
