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
CREATE PROCEDURE [FEMIG].[getRolesDeUsuario]
	@pUsuarioID	VARCHAR(20)
AS
BEGIN
	SELECT 'True' AS chk,R.ROLID AS rolID,R.DESCRIPCION 
	FROM FEMIG.ROLUSUARIO RU
	INNER JOIN FEMIG.ROL R ON (RU.ROLID = R.ROLID)
	WHERE RU.usuarioID = @pUsuarioID
	UNION
	SELECT 'False' AS chk,ROLID AS rolID,R.DESCRIPCION  FROM FEMIG.ROL R
	WHERE NOT EXISTS (SELECT 1 FROM FEMIG.ROLUSUARIO RU WHERE RU.UsuarioID = @pUsuarioID AND RU.ROLID = R.ROLID)
END
