USE [GD1C2012]
GO
/****** Object:  StoredProcedure [FEMIG].[crearTurno]    Script Date: 06/10/2012 22:39:42 ******/
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
CREATE PROCEDURE [FEMIG].[crearTurno] 
	@pHoraInicio 		numeric(18),
	@pHoraFin 			numeric(18),
	@pDescripcion 		varchar(255),
	@pValorFicha 		numeric(18,2),
	@pValorBandera 		numeric(18,2),
	@pAnulado 			bit,
	@retCatchError		VARCHAR(MAX) out
AS
BEGIN

	INSERT INTO [GD1C2012].[FEMIG].[turnos]
           (horaInicio,horaFin,descripcion,valorFicha,valorBandera,anulado)
    VALUES
           (@pHoraInicio
           ,@pHoraFin
           ,@pDescripcion
           ,@pValorFicha
           ,@pValorBandera
           ,'0')
END