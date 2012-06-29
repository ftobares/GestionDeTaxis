CREATE TRIGGER femig.modifRelecionTurno
ON femig.turnos
AFTER UPDATE

AS 

if update(anulado)
BEGIN

	-- SET NOCOUNT ON impide que se generen mensajes de texto con cada instrucción 

	SET NOCOUNT ON;

	if(inserted.anulado = 1)
	begin
		UPDATE femig.ChoferAutoTurno SET anulado = inserted.anulado WHERE turnoID = inserted.turnoID 
	end
	else
	begin
		UPDATE femig.ChoferAutoTurno cat SET anulado = inserted.anulado WHERE turnoID = inserted.turnoID AND 
			NOT EXISTS (select 1 from femig.autos a where a.patente=cat.patente AND anulado = 1) AND
				NOT EXISTS (select 1 from femig.choferes c where c.dniChofer=cat.dniChofer AND anulado = 1)
	end

END