/*+++++++++++++++++++++++++++++++++++++++
* Grupo: FEMIG							*			
*                                       *
* Integrantes:                          *
*	Emiliano Marcelo Ibarrola           *
*	Marcos Andres Ibarrola              *
*	Ignacio Angel Tata                  *
*	Fernando N. Tobares Garcia          *
*+++++++++++++++++++++++++++++++++++++++*/

create PROCEDURE verificarCredencialesLogueo
	@pUsuario	VARCHAR(20),
	@pClave		VARCHAR(100),
	@pResultado	BIT OUT

AS
DECLARE @clave VARCHAR(100)
BEGIN
	
	SELECT @clave = password from Usuario where usuarioID = @pUsuario

	set @pResultado = 0

	if @clave = @pClave
		Set @pResultado = 1
	else
		Set @pResultado = 0

	return @pResultado
		
END
GO
