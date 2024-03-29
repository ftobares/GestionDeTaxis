USE [GD1C2012]
GO
/****** Object:  StoredProcedure [FEMIG].[eliminarUsuario]    Script Date: 06/15/2012 02:15:12 ******/
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
CREATE PROCEDURE [FEMIG].[eliminarUsuario] 
	@pUsuarioID			VARCHAR(20)
AS
BEGIN
	update femig.Usuario set anulado = '1' where usuarioID = @pUsuarioID
END
