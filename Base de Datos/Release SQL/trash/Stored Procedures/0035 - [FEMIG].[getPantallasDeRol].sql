USE [GD1C2012]
GO
/****** Object:  StoredProcedure [FEMIG].[getPantallasDeRol]    Script Date: 06/15/2012 05:01:52 ******/
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
CREATE PROCEDURE [FEMIG].[getPantallasDeRol]
	@pRolID	VARCHAR(20)
AS
BEGIN
	SELECT 'True' AS chk,P.PANTALLAID AS pantallaID,P.DESCRIPCION 
	FROM FEMIG.ROLPANTALLA RP
	INNER JOIN FEMIG.PANTALLA P ON (RP.PANTALLAID = P.PANTALLAID)
	WHERE ROLID = @pRolID
	UNION
	SELECT 'False' AS chk,PANTALLAID AS pantallaID,P.DESCRIPCION  FROM FEMIG.PANTALLA P
	WHERE NOT EXISTS (SELECT 1 FROM FEMIG.ROLPANTALLA RP WHERE RP.ROLID = @pRolID AND RP.PANTALLAID = P.PANTALLAID)
END
