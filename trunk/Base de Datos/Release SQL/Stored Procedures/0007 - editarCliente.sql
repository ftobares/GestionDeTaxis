USE [GD1C2012]
GO
/****** Object:  StoredProcedure [FEMIG].[editarCliente]    Script Date: 06/11/2012 02:10:24 ******/
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
CREATE PROCEDURE [FEMIG].[editarCliente] 
	@pDniCliente		numeric(18),
	@pNombre			VARCHAR(255),
	@pApellido			VARCHAR(255),
	@pTelefono			VARCHAR(18),
	@pDireccion			VARCHAR(255),
	@pEmail				VARCHAR(255),
	@pFechaNacimiento 	DATETIME,
	@pAnulado			BIT,
	@rRetCatchError		VARCHAR(MAX) out
AS
BEGIN
	--Controlo que no haya duplicados de Patente
	if not exists (select 1 from FEMIG.clientes where dniCliente = @pDniCliente)
	begin
		set @rRetCatchError = 'No existe un cliente con el mismo DNI ' + @pDniCliente + '.'
		return
	end

	UPDATE [GD1C2012].[FEMIG].[clientes]
	   SET [dniCliente] = @pDniCliente
		  ,[nombre] = @pNombre
		  ,[apellido] = @pApellido
		  ,[telefono] = @pTelefono
		  ,[direccion] = @pDireccion
		  ,[email] = @pEmail
		  ,[fechaNacimiento] = @pFechaNacimiento
	 WHERE dniCliente = @pDniCliente
	
END