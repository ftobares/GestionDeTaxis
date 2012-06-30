CREATE TRIGGER femig.modifRelecionChofer
ON femig.choferes
AFTER UPDATE

AS 

DECLARE @anulado BIT
DECLARE @patente VARCHAR(10)
DECLARE @dniChofer NUMERIC(18,0)
DECLARE @turnoID NUMERIC(18,0)

if update(anulado)
BEGIN

	-- SET NOCOUNT ON impide que se generen mensajes de texto con cada instrucción 

	SET NOCOUNT ON;

	if(@anulado = 1)
	begin
		UPDATE femig.ChoferAutoTurno SET anulado = @anulado WHERE dniChofer = @dniChofer 
	end
	else
	begin
		UPDATE cat SET anulado = @anulado FROM femig.choferAutoTurno cat WHERE dniChofer = @dniChofer AND 
			NOT EXISTS (select 1 from femig.autos a where a.patente=cat.patente AND anulado = 1) AND
				NOT EXISTS (select 1 from femig.turnos t where t.turnoID=cat.turnoID AND anulado = 1)
	end

END