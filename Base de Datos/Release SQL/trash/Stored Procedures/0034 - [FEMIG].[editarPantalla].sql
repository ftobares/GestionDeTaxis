USE [GD1C2012]
GO
/****** Object:  StoredProcedure [FEMIG].[editarPantalla]    Script Date: 06/15/2012 03:28:49 ******/
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
CREATE PROCEDURE [FEMIG].[editarPantalla] 
	@pPantallaID		VARCHAR(255),
	@pDescripcion		VARCHAR(255),
	@pRetCatchError		VARCHAR(1000) out
AS
BEGIN
	--Controlo que no haya duplicados de Patente
	if not exists (select 1 from FEMIG.Pantalla where pantallaID = @pPantallaID)
	begin
		set @pRetCatchError = 'No existe la Pantalla ' + cast(@pPantallaID as varchar) + '.'
		return
	END
		
	UPDATE [GD1C2012].[FEMIG].[Pantalla]
	   SET [descripcion] = @pDescripcion
	 WHERE pantallaID = @pPantallaID
		
END
