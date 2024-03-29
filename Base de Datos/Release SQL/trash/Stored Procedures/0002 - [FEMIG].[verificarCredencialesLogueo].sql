USE [GD1C2012]
GO
/****** Object:  StoredProcedure [FEMIG].[verificarCredencialesLogueo]    Script Date: 06/15/2012 00:33:22 ******/
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

CREATE PROCEDURE [FEMIG].[verificarCredencialesLogueo]
	@pUsuario	VARCHAR(20),
	@pClave		VARCHAR(100),
	@pResultado	BIT OUT

AS
DECLARE @clave VARCHAR(100)
BEGIN
	
	SELECT @clave = password from Usuario where usuarioID = @pUsuario AND ISNULL(anulado,'0')='0'

	set @pResultado = 0

	if @clave = @pClave
		Set @pResultado = 1
	else
		Set @pResultado = 0

	return @pResultado
		
END
