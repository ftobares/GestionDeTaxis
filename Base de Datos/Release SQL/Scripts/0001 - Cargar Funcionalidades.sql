--Cargar Funcionalidades
INSERT INTO FEMIG.PANTALLA VALUES ('abmCliente','ABM Clientes')
INSERT INTO FEMIG.PANTALLA VALUES ('abmRol','ABM Roles')
INSERT INTO FEMIG.PANTALLA VALUES ('abmUsuario','ABM Usuarios')
INSERT INTO FEMIG.PANTALLA VALUES ('abmAuto','ABM Autos')
INSERT INTO FEMIG.PANTALLA VALUES ('abmReloj','ABM Relojes')
INSERT INTO FEMIG.PANTALLA VALUES ('abmChofer','ABM Choferes')
INSERT INTO FEMIG.PANTALLA VALUES ('abmTurno','ABM Turnos')
INSERT INTO FEMIG.PANTALLA VALUES ('abmChoferAuto','Relación Chofer-Auto')
INSERT INTO FEMIG.PANTALLA VALUES ('abmViaje','Cargar Viajes')
INSERT INTO FEMIG.PANTALLA VALUES ('abmRendicion','Rendición de Cuenta')
INSERT INTO FEMIG.PANTALLA VALUES ('abmFacturacion','Facturación')
INSERT INTO FEMIG.PANTALLA VALUES ('abmListado','Listados Estadísticos')

insert into FEMIG.Rol values ('Administrador','Administrador de Sistema','0')

insert into FEMIG.ROLPANTALLA
select 'Administrador',PANTALLAID,'1' from FEMIG.PANTALLA

INSERT INTO FEMIG.USUARIO VALUES ('Admin','Administrador','Administrador',null,'E6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7',0,10,'0')

insert into FEMIG.rolusuario values ('Admin','Administrador')