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
ALTER PROCEDURE [FEMIG].[editarTurno] 
	@pTurnoId			NUMERIC(18,0),
	@pDescripcion		VARCHAR(255),
	@pHoraInicio		NUMERIC(18,0),
	@pHoraFin			NUMERIC(18,0),
	@pValorFicha		NUMERIC(18,2),
	@pValorBandera		NUMERIC(18,2),
	@pAnulado			BIT,
	@pRetCatchError		VARCHAR(1000) out
AS
BEGIN

	--Controlo si 2 turnos activos solapan horarios
	iF exists	(SELECT	1 FROM femig.turnos
				WHERE	ISNULL(anulado,'0')='0'
						AND ((@pHoraInicio >= horaInicio AND @pHoraInicio <= horaFin)
						OR (@pHoraFin >= horaInicio AND @pHoraFin <= horaFin)))
	begin
		set @pRetCatchError = 'El turno que intenta editar se solapa con otros horarios.'
		return
	END
	
	UPDATE [GD1C2012].[FEMIG].[turnos]
	SET descripcion = @pDescripcion
		,horaFin = @pHoraFin
		,horaInicio = @pHoraInicio
		,valorBandera = @pValorBandera
		,valorFicha = @pValorFicha
	WHERE turnoID = @pTurnoId
end
