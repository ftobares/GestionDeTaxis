--Cargar Funcionalidades
INSERT INTO PANTALLA VALUES ('abmCliente','ABM Clientes')
INSERT INTO PANTALLA VALUES ('abmRol','ABM Roles')
INSERT INTO PANTALLA VALUES ('abmUsuario','ABM Usuarios')
INSERT INTO PANTALLA VALUES ('abmAuto','ABM Autos')
INSERT INTO PANTALLA VALUES ('abmReloj','ABM Relojes')
INSERT INTO PANTALLA VALUES ('abmChofer','ABM Choferes')
INSERT INTO PANTALLA VALUES ('abmTurno','ABM Turnos')
INSERT INTO PANTALLA VALUES ('abmChoferAuto','Relaci�n Chofer-Auto')
INSERT INTO PANTALLA VALUES ('abmViaje','Cargar Viajes')
INSERT INTO PANTALLA VALUES ('abmRendicion','Rendici�n de Cuenta')
INSERT INTO PANTALLA VALUES ('abmFacturacion','Facturaci�n')
INSERT INTO PANTALLA VALUES ('abmListado','Listados Estad�sticos')

insert into Rol values ('Administrador','Administrador de Sistema','0')

insert into RolPantalla
select 'Administrador',pantallaID,'1' from Pantalla

insert into rolusuario values ('Admin','Administrador')