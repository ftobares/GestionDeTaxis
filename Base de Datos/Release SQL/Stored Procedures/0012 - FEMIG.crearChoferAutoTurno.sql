USE [GD1C2012]
GO
/****** Object:  StoredProcedure [FEMIG].[crearChoferAutoTurno]    Script Date: 06/10/2012 22:39:42 ******/
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
CREATE PROCEDURE [FEMIG].[crearChoferAutoTurno] 
	@pFecha 			datetime,
	@pDniChofer		 	numeric(18),
	@pTurnoID 			numeric(20),
	@pPatente 			varchar(10),
	@retCatchError		VARCHAR(MAX) out
AS
BEGIN

	--Controlo que para una fecha, no haya dos turnos iguales
	if exists (select 1 from FEMIG.ChoferAutoTurno where datediff(day,fecha,@pFecha)=0 AND turnoID = @pTurnoID)
	begin
		set @retCatchError = 'Ya fue asignado el turno ' + cast(@pTurnoID as varchar) + ' para la fecha ' + cast(@pFecha as varchar) + '.'
		return
	end

	--Controlo que para un mismo auto en la misma fecha y turno, no haya dos choferes (No es necesario este control, se filtra en el if de arriba)
	/*if exists (select 1 from FEMIG.ChoferAutoTurno where fecha = @pFecha AND turnoID = @pTurnoID AND dniChofer = @pDniChofer)
	begin
		set @retCatchError = 'Ya fue asignado el chofer ' + cast(@pDniChofer as varchar) + ' para la fecha ' + cast(@pFecha as varchar) + ', el turno ' + cast(@pTurnoID as varchar) + 'y el auto ' + @pPatente + '.'
		return
	end*/
	
	INSERT INTO [GD1C2012].[FEMIG].[ChoferAutoTurno]
           (fecha,dniChofer,turnoID,patente)
    VALUES
           (@pFecha
           ,@pDniChofer
           ,@pTurnoID
           ,@pPatente)
END