USE [GD1C2012]
GO
/****** Object:  StoredProcedure [FEMIG].[editarUsuario]    Script Date: 06/15/2012 02:14:48 ******/
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
CREATE PROCEDURE [FEMIG].[editarUsuario] 
	@pUsuarioID			VARCHAR(20),
	@pNombre			VARCHAR(50),
	@pApellido			VARCHAR(50),
	@pEmail				VARCHAR(100),
	@pPassword			VARCHAR(64),
	@pCantMaxIntentos	NUMERIC(18,0),
	@pAnulado			BIT,
	@pRetCatchError		VARCHAR(1000) out
AS
BEGIN
	--Controlo que no haya duplicados de Usuario ID
	if not exists (select 1 from FEMIG.Usuario where usuarioID = @pUsuarioID)
	begin
		set @pRetCatchError = 'No existe el usuario ID ' + @pUsuarioID + '.'
		return
	end

	--Controlo que no haya 2 Usuarios activos con el mismo reloj
	if exists (select 1 from FEMIG.Usuario where usuarioID <> @pUsuarioID and email = @pEmail and isnull(anulado,'0')='0')
	begin
		set @pRetCatchError = 'Ya existe un usuario con el email ' + cast(@pEmail as varchar) + '.'
		return
	end

	UPDATE [GD1C2012].[FEMIG].[Usuario]
	   SET [nombre] = @pNombre
		  ,[apellido] = @pApellido
		  ,[email] = @pEmail
		  ,[password] = @pPassword
		  ,[cantMaxIntentos] = @pCantMaxIntentos
		  ,[anulado] = @pAnulado
	 WHERE usuarioID = @pUsuarioID
	
END
