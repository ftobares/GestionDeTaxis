USE [GD1C2012]
GO
/****** Object:  StoredProcedure [FEMIG].[ObtenerFuncionalidades]    Script Date: 06/10/2012 14:53:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [FEMIG].[ObtenerFuncionalidades]
	@pUsuarioID	 varchar(20)	
AS
BEGIN
	Select P.pantallaID, P.descripcion
    from FEMIG.Usuario U
    inner join FEMIG.RolUsuario RU on (U.usuarioID = RU.usuarioID)
    inner join FEMIG.Rol R on (RU.rolID = R.rolID)
    inner join FEMIG.RolPantalla RP on (R.rolID = RP.rolID)
    inner join FEMIG.Pantalla P on (RP.pantallaID = P.pantallaID)
    where	isnull(U.anulado,'0')='0'
            and isnull(R.anulado,'0')='0'
            and U.usuarioID = @pUsuarioID
            and isnull(RP.acceso,'0')='1'
END
