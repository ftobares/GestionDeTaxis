USE [GD1C2012]
GO
/****** Object:  StoredProcedure [FEMIG].[eliminarChoferAutoTurno]    Script Date: 06/11/2012 02:19:42 ******/
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
CREATE PROCEDURE [FEMIG].[eliminarChoferAutoTurno] 
	@pId_Asign			NUMERIC(18)
AS
BEGIN
	DELETE FROM femig.ChoferAutoTurno where asignacionID = @pId_Asign
END
