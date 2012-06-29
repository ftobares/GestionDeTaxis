CREATE TRIGGER femig.modifRelecionChofer
ON femig.choferes
AFTER UPDATE

AS 

if update(anulado)
BEGIN

	-- SET NOCOUNT ON impide que se generen mensajes de texto con cada instrucción 

	SET NOCOUNT ON;

	if(inserted.anulado = 1)
	begin
		UPDATE femig.ChoferAutoTurno SET anulado = inserted.anulado WHERE dniChofer = inserted.dniChofer 
	end
	else
	begin
		UPDATE femig.ChoferAutoTurno cat SET anulado = inserted.anulado WHERE dniChofer = inserted.dniChofer AND 
			NOT EXISTS (select 1 from femig.autos a where a.patente=cat.patente AND anulado = 1) AND
				NOT EXISTS (select 1 from femig.turnos t where t.turnoID=cat.turnoID AND anulado = 1)
	end

END