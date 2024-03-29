USE [GD1C2012]
GO
/****** Object:  StoredProcedure [FEMIG].[editarChofer]    Script Date: 06/12/2012 02:23:37 ******/
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
CREATE PROCEDURE [FEMIG].[editarChofer] 
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
	if not exists (select 1 from FEMIG.choferes where dniChofer = @pDniChofer)
	begin
		set @pRetCatchError = 'No existe un chofer con Dni ' + cast(@pDniChofer as varchar) + '.'
		return
	end

	--Controlo que no haya 2 autos activos con el mismo reloj
	if exists (select 1 from FEMIG.choferes where dniChofer <> @pDniChofer and email = @pEmail)
	begin
		set @pRetCatchError = 'Ya existe un chofer con el email ' + cast(@pEmail as varchar) + '.'
		return
	end

	UPDATE [GD1C2012].[FEMIG].[choferes]
	   SET [nombre] = @pNombre
		  ,[apellido] = @pApellido
		  ,[direccion] = @pDireccion
		  ,[telefono] = @pTelefono
		  ,[email] = @pEmail
		  ,[fechaNacimiento] = @pFechaNacimiento
		  ,[anulado] = @pAnulado
	 WHERE dniChofer = @pDniChofer
		
END
