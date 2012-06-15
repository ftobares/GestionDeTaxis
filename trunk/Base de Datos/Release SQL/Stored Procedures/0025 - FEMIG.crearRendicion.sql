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
CREATE PROCEDURE [FEMIG].[crearRendicion] 
	@pFecha datetime,
	@pDniChofer numeric(18),
	@pTurnoID varchar(20),
	@pImporteTotal numeric(18,5) out,
	@pRetCatchError		VARCHAR(MAX) out
AS

BEGIN

	--Controlo si hay 2 Rendiciones para el mismo chofer a la misma Fecha y el mismo turno
	iF exists	(SELECT	1 FROM femig.Rendiciones
				WHERE	 (DATEDIFF(day , fecha, @pFecha)=0) AND (turnoID = @pTurnoID)
						AND (@pDniChofer = dniChofer) )
	begin
	set @pRetCatchError = 'La rendicion que intenta ingresar ya fue ingresada.'
		return
	end
	/*SELECT @pImporteTotal = SUM(tur.valorBandera + (vi.cantFichas * tur.valorFicha)) FROM femig.viajes vi
		INNER JOIN GD1C2012.FEMIG.turnos tur on @pTurnoID = tur.turnoID
			INNER JOIN GD1C2012.FEMIG.ChoferAutoTurno ch on @pDniChofer = ch.dniChofer 
				WHERE datediff(day,@pFecha,vi.fecha)= 0*/
		
	INSERT INTO [GD1C2012].[FEMIG].[Rendiciones]
           (fecha,dniChofer,turnoID,importeTotal)
    VALUES
           (@pFecha
           ,@pDniChofer
           ,@pTurnoID
           ,@pImporteTotal)
END