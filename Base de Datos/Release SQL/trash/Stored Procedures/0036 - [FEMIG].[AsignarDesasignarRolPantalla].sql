USE [GD1C2012]
GO
/****** Object:  StoredProcedure [FEMIG].[AsignarDesasignarRolPantalla]    Script Date: 06/15/2012 05:32:42 ******/
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
CREATE PROCEDURE [FEMIG].[AsignarDesasignarRolPantalla]
	@pRolID			VARCHAR(20),
	@pPantallaID	VARCHAR(255)
AS
BEGIN
	
	IF NOT EXISTS (SELECT 1 FROM FEMIG.ROLPANTALLA WHERE ROLID = @pRolID AND PANTALLAID = @pPantallaID)
		INSERT INTO FEMIG.ROLPANTALLA VALUES (@pRolID, @pPantallaID, '1')
	ELSE
		DELETE FROM FEMIG.ROLPANTALLA WHERE ROLID = @pRolID AND PANTALLAID = @pPantallaID
	
END
