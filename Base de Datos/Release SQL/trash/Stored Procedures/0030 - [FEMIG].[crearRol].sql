USE [GD1C2012]
GO
/****** Object:  StoredProcedure [FEMIG].[crearRol]    Script Date: 06/15/2012 02:28:22 ******/
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
CREATE PROCEDURE [FEMIG].[crearRol] 
	@pRolID				VARCHAR(20),
	@pDescripcion		VARCHAR(50),
	@pAnulado			BIT,
	@pRetCatchError		VARCHAR(1000) out
AS
BEGIN
	if exists (select 1 from FEMIG.Rol where rolID = @pRolID)
	begin
		set @pRetCatchError = 'Ya existe el rol ' + @pRolID + '.'
		return
	end

	INSERT INTO [GD1C2012].[FEMIG].[Rol]
           (rolID, descripcion, anulado)
    VALUES
           (@pRolID
           ,@pDescripcion
           ,@pAnulado)
	
END
