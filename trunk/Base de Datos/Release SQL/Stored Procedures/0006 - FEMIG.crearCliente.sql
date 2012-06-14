USE [GD1C2012]
GO
/****** Object:  StoredProcedure [FEMIG].[crearCliente]    Script Date: 06/10/2012 22:39:42 ******/
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
CREATE PROCEDURE [FEMIG].[cliente] 
	@pDniCliente		NUMERIC(18),
	@pNombre			VARCHAR(255),
	@pApellido			VARCHAR(255),
	@pTelefono			numeric(18),
	@pDireccion			VARCHAR(255),
	@pEmail				VARCHAR(255),
	@pFechaNacimiento 	DATETIME,
	@pAnulado			BIT,
	@retCatchError		VARCHAR(MAX) out
AS
BEGIN
	--Controlo que no haya duplicados de Patente
	if exists (select 1 from FEMIG.cliente where dniCliente = @pDniCliente)
	begin
		set @retCatchError = 'Ya existe un cliente con el mismo DNI ' + @pDniCliente + '.'
		return
	end

	INSERT INTO [GD1C2012].[FEMIG].[cliente]
           (dniCliente,nombre,apellido,telefono,direccion,email,fechaNacimiento,anulado)
    VALUES
           (@pDniCliente
           ,@pNombre
           ,@pApellido
           ,@pTelefono
           ,@pDireccion
           ,@pEmail
		   ,@pFechaNacimiento
           ,'0')
	
END
