USE [GD1C2012]
GO
/****** Object:  StoredProcedure FEMIG.editarChoferAutoTurno    Script Date: 06/11/2012 02:10:24 ******/
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
CREATE PROCEDURE FEMIG.editarChoferAutoTurno 
	@pId_Asign 			numeric(18),
	@pFecha 			datetime,
	@pDniChofer		 	numeric(18),
	@pTurnoID 			numeric(20),
	@pPatente 			varchar(10),
	@retCatchError		VARCHAR(MAX) out
AS
BEGIN

	UPDATE [GD1C2012].[FEMIG].[ChoferAutoTurno]
	   SET [fecha] = @pFecha
		  ,[dniChofer] = @pDniChofer
		  ,[turnoID] = @pTurnoID
		  ,[patente] = @pPatente
	 WHERE ID_Asign= @pId_Asign
	
END