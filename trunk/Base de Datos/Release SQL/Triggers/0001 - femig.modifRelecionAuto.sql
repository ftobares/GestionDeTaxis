CREATE TRIGGER femig.modifRelecionAuto
ON femig.autos
AFTER UPDATE

AS 

if update(anulado)
BEGIN

	-- SET NOCOUNT ON impide que se generen mensajes de texto con cada instrucción 

	SET NOCOUNT ON;

	if(inserted.anulado = 1)
	begin
		UPDATE femig.ChoferAutoTurno SET anulado = inserted.anulado WHERE patente = inserted.patente 
	end
	else
	begin
		UPDATE femig.ChoferAutoTurno cat SET anulado = inserted.anulado WHERE patente = inserted.patente AND 
			NOT EXISTS (select 1 from femig.choferes c where c.dniChofer=cat.dniChofer AND anulado = 1) AND
				NOT EXISTS (select 1 from femig.turnos t where t.turnoID=cat.turnoID AND anulado = 1)
	end

END