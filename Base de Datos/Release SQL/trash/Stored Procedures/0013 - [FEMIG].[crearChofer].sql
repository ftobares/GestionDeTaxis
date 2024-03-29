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
CREATE PROCEDURE [FEMIG].[crearChofer] 
	@pDniChofer			NUMERIC(18,0),
	@pNombre			VARCHAR(255),
	@pApellido			VARCHAR(255),
	@pDireccion			VARCHAR(255),
	@pTelefono			NUMERIC(18,0),
	@pEmail				VARCHAR(50),
	@pFechaNacimiento	DATETIME,
	@pAnulado			BIT,
	@pRetCatchError		VARCHAR(1000) out
AS
BEGIN
	--Controlo que no haya duplicados de Patente
	if exists (select 1 from FEMIG.choferes where dniChofer = @pDniChofer)
	begin
		set @pRetCatchError = 'Ya existe un chofer con el Dni: ' + cast(@pDniChofer as varchar) + '.'
		return
	end

	--Controlo que no haya 2 autos activos con el mismo reloj
	if exists (select 1 from FEMIG.choferes where email = @pEmail)
	begin
		set @pRetCatchError = 'Ya existe un chofer con el email ' + @pEmail + '.'
		return
	end

	INSERT INTO [GD1C2012].[FEMIG].[choferes]
           ([dniChofer],[nombre],[apellido],[direccion],[telefono],[email],[fechaNacimiento],[anulado])
     VALUES
           (@pDniChofer
           ,@pNombre
           ,@pApellido
           ,@pDireccion
           ,@pTelefono
           ,@pEmail
           ,@pFechaNacimiento
           ,'0')
	
END
