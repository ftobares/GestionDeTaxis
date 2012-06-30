CREATE TRIGGER femig.modifRelecionAuto
ON femig.autos
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

	SELECT TOP(1) @anulado = anulado, @patente = patente FROM INSERTED
	if(@anulado = 1)
	begin
		UPDATE femig.ChoferAutoTurno SET anulado = @anulado WHERE patente = @patente
	end
	else
	begin
		UPDATE cat SET anulado = @anulado FROM femig.choferAutoTurno WHERE patente = @patente AND 
			NOT EXISTS (select 1 from femig.choferes c where c.dniChofer=cat.dniChofer AND anulado = 1) AND
				NOT EXISTS (select 1 from femig.turnos t where t.turnoID=cat.turnoID AND anulado = 1)
	end

END