CREATE TRIGGER femig.modifRelecionTurno
ON femig.turnos
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
	
	SELECT TOP(1) @anulado = anulado, @turnoID = turnoID FROM INSERTED
	if(@anulado = 1)
	begin
		UPDATE femig.ChoferAutoTurno SET anulado = @anulado WHERE turnoID = @turnoID 
	end
	else
	begin
		UPDATE cat SET anulado = @anulado FROM femig.choferAutoTurno cat WHERE turnoID = @turnoID AND 
			NOT EXISTS (select 1 from femig.autos a where a.patente=cat.patente AND anulado = 1) AND
				NOT EXISTS (select 1 from femig.choferes c where c.dniChofer=cat.dniChofer AND anulado = 1)
	end

END