USE [GD1C2012]
GO
/****** Object:  StoredProcedure [FEMIG].[crearAuto]    Script Date: 06/15/2012 11:34:24 ******/
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
CREATE PROCEDURE [FEMIG].[crearAuto] 
	@pPatente			VARCHAR(10),
	@pMarca				VARCHAR(255),
	@pModelo			VARCHAR(255),
	@pLicencia			VARCHAR(26),
	@pRodado			VARCHAR(10),
	@pNroSerieReloj		VARCHAR(18),
	@pAnulado			BIT,
	@pRetCatchError		VARCHAR(1000) out
AS
BEGIN
	--Controlo que no haya duplicados de Patente
	if exists (select 1 from FEMIG.autos where patente = @pPatente)
	begin
		set @pRetCatchError = 'Ya existe un auto con la patente ' + cast(@pPatente as varchar) + '.'
		return
	end

	--Controlo que no haya 2 autos activos con el mismo reloj
	if exists (select 1 from FEMIG.autos where nroSerieReloj = @pNroSerieReloj and isnull(anulado,'0')='0')
	begin
		set @pRetCatchError = 'Ya existe un auto con el reloj ' + cast(@pNroSerieReloj as varchar) + '.'
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
