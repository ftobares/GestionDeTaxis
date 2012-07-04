USE [GD1C2012]
GO
/****** Object:  StoredProcedure [FEMIG].[editarTurno]    Script Date: 06/11/2012 02:10:24 ******/
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
CREATE PROCEDURE [FEMIG].[editarTurno] 
	@pTurnoID			numeric(20),
	@pHoraInicio 		numeric(18),
	@pHoraFin 			numeric(18),
	@pDescripcion 		varchar(255),
	@pValorFicha 		numeric(18,2),
	@pValorBandera 		numeric(18,2),
	@pAnulado 			bit,
	@retCatchError		VARCHAR(MAX) out
AS
BEGIN

	UPDATE [GD1C2012].[FEMIG].[turnos]
	   SET [horaInicio] = @pHoraInicio
		  ,[horaFin] = @pHoraFin
		  ,[descripcion] = @pDescripcion
		  ,[valorFicha] = @pValorFicha
		  ,[valorBandera] = @pValorBandera
		  ,[anulado] = @pAnulado
	 WHERE turnoID = @pTurnoID
	
END