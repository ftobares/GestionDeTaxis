USE [GD1C2012]
GO
/****** Object:  StoredProcedure [FEMIG].[editarRol]    Script Date: 06/15/2012 02:20:17 ******/
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
CREATE PROCEDURE [FEMIG].[editarRol] 
	@pRolID				VARCHAR(20),
	@pDescripcion		VARCHAR(50),
	@pAnulado			BIT,
	@pRetCatchError		VARCHAR(1000) out
AS
BEGIN
	--Controlo que no haya duplicados de Patente
	if not exists (select 1 from FEMIG.Rol where rolID = @pRolID)
	begin
		set @pRetCatchError = 'No existe el Rol ' + @pRolID + '.'
		return
	end

	UPDATE [GD1C2012].[FEMIG].[Rol]
	   SET [descripcion] = @pDescripcion
		  ,[anulado] = @pAnulado
	 WHERE rolID = @pRolID
	
END
