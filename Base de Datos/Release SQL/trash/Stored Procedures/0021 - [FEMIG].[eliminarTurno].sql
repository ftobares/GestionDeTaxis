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
ALTER PROCEDURE [FEMIG].[eliminarTurno] 
	@pTurnoId			NUMERIC(18,0)
AS
BEGIN
	update femig.turnos set anulado = '1' where turnoID = @pTurnoId
END
