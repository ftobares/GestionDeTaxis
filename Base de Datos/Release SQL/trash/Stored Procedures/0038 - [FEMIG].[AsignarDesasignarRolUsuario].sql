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
CREATE PROCEDURE [FEMIG].[AsignarDesasignarRolUsuario]
	@pUsuarioID		VARCHAR(20),
	@pRolID			VARCHAR(255)
AS
BEGIN
	
	IF NOT EXISTS (SELECT 1 FROM FEMIG.ROLUSUARIO WHERE USUARIOID = @pUsuarioID AND ROLID = @pRolID)
		INSERT INTO FEMIG.ROLUSUARIO VALUES (@pUsuarioID, @pRolID)
	ELSE
		DELETE FROM FEMIG.ROLUSUARIO WHERE USUARIOID = @pUsuarioID AND ROLID = @pRolID
	
END
