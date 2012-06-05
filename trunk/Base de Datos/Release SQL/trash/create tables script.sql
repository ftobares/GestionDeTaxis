/*+++++++++++++++++++++++++++++++++++++++
* Grupo: FEMIG							*			
*                                       *
* Integrantes:                          *
*	Emiliano Marcelo Ibarrola           *
*	Marcos Andres Ibarrola              *
*	Ignacio Angel Tata                  *
*	Fernando N. Tobares Garcia          *
*+++++++++++++++++++++++++++++++++++++++*/

/*++++++++++++++++++++++++++++++++++++++*/
/*Creacion del shema					*/
/*++++++++++++++++++++++++++++++++++++++*/
USE [GD1C2012]
GO
CREATE SCHEMA [FEMIG] AUTHORIZATION [gd]
GO

/*++++++++++++++++++++++++++++++++++++++*/
/*Creacion de tablas en la base de datos*/
/*++++++++++++++++++++++++++++++++++++++*/
CREATE TABLE GD1C2012.FEMIG.turnos
(
cod_turno NUMERIC(2,0) NOT NULL IDENTITY(1,1),
descripcion VARCHAR(12) NOT NULL,
hora_inicio NUMERIC(2,0) NOT NULL,
hora_fin NUMERIC(2,0) NOT NULL,
valor_ficha NUMERIC(4,2) NOT NULL,
valor_bandera NUMERIC(4,2) NOT NULL,
constraint pk_cod_turno primary key (cod_turno)
);

CREATE TABLE GD1C2012.FEMIG.clientes
(
cod_cliente NUMERIC(7,0) NOT NULL IDENTITY(1,1),
nombre VARCHAR(25) NOT NULL,
apellido VARCHAR(25) NOT NULL,
fecha_nacimiento SMALLDATETIME NULL,
telefono NUMERIC(18,0) NOT NULL,
direccion VARCHAR(60) NOT NULL,
mail VARCHAR(25) NULL,
dni NUMERIC(9,0) NOT NULL,
constraint pk_cod_cliente primary key (cod_cliente)
);

CREATE UNIQUE INDEX IDX_cliente_dni ON GD1C2012.FEMIG.clientes (dni);

CREATE TABLE GD1C2012.FEMIG.facturacion
(
cod_factura NUMERIC(9,0) NOT NULL IDENTITY(1,1),
cod_cliente NUMERIC(7,0) NOT NULL,
fecha_inicio SMALLDATETIME NOT NULL,
fecha_fin SMALLDATETIME NOT NULL,
constraint pk_cod_factura primary key (cod_factura),
constraint fk_cod_cliente2 foreign key (cod_cliente) references GD1C2012.FEMIG.clientes(cod_cliente)
);

CREATE INDEX IDX_cliente_factura ON GD1C2012.FEMIG.facturacion (cod_factura,cod_cliente);

CREATE TABLE GD1C2012.FEMIG.relojes
(
modelo VARCHAR(12) NOT NULL,
marca VARCHAR(20) NOT NULL,
reloj_fecha_ver SMALLDATETIME NOT NULL,
constraint pk_modelo primary key (modelo)
);

CREATE TABLE GD1C2012.FEMIG.autos
(
patente VARCHAR(9) NOT NULL,
marca VARCHAR(15) NULL,
modelo VARCHAR(12) NULL,
licencia NUMERIC(9,0) NOT NULL,
rodado VARCHAR(15) NOT NULL UNIQUE,
modelo_reloj VARCHAR(12) NOT NULL
constraint pk_patente primary key (patente),
constraint fk_modelo_reloj foreign key (modelo_reloj) references GD1C2012.FEMIG.relojes(modelo)
);

CREATE INDEX IDX_auto_modelo ON GD1C2012.FEMIG.autos (modelo);
CREATE INDEX IDX_auto_rodado ON GD1C2012.FEMIG.autos (rodado);
CREATE UNIQUE INDEX IDX_licencia_auto ON GD1C2012.FEMIG.autos (licencia);

CREATE TABLE GD1C2012.FEMIG.choferes
(
dni NUMERIC(9,0) NOT NULL,
nombre VARCHAR(25) NOT NULL,
apellido VARCHAR(25) NOT NULL,
licencia NUMERIC(9,0) NOT NULL,
fecha_nacimiento SMALLDATETIME NULL,
telefono NUMERIC(18,0) NOT NULL,
direccion VARCHAR(60) NOT NULL,
mail VARCHAR(25) NULL,
constraint pk_dni primary key (dni),
constraint fk_licencia_auto foreign key (licencia) references GD1C2012.FEMIG.autos(licencia)
);

CREATE UNIQUE INDEX IDX_licencia_auto ON GD1C2012.FEMIG.choferes (licencia);

CREATE TABLE GD1C2012.FEMIG.viajes
(
cod_viaje NUMERIC(10,0) NOT NULL IDENTITY(1,1),
auto_patente VARCHAR(9) NOT NULL,
tipo_viaje VARCHAR(12) NOT NULL,
cliente NUMERIC(7,0) NOT NULL DEFAULT 0,
fecha SMALLDATETIME NOT NULL,
id_turno NUMERIC(2,0) NOT NULL,
cantidad_fichas NUMERIC(3,0) NOT NULL,
constraint pk_cod_viaje primary key (cod_viaje),
constraint fk_auto_patente foreign key (auto_patente) references GD1C2012.FEMIG.autos(patente),
constraint fk_cliente foreign key (cliente) references GD1C2012.FEMIG.clientes(cod_cliente),
constraint fk_id_turno foreign key (id_turno) references GD1C2012.FEMIG.turnos(cod_turno),
);

CREATE INDEX IDX_viaje ON GD1C2012.FEMIG.viajes (auto_patente, cliente);

CREATE TABLE GD1C2012.FEMIG.rendicion
(
cod_operacion NUMERIC(9,0) NOT NULL IDENTITY(1,1),
fecha SMALLDATETIME NOT NULL,
auto_patente VARCHAR(9) NOT NULL,
importe NUMERIC(6,2) NOT NULL,
cantidad_viajes NUMERIC(2,0) NOT NULL
constraint pk_cod_operacion primary key (cod_operacion),
constraint fk_auto_patente2 foreign key (auto_patente) references GD1C2012.FEMIG.autos(patente)
);

CREATE INDEX IDX_rendicion ON GD1C2012.FEMIG.rendicion (auto_patente);

/*++++++++++++++++++++++++++++++++++++++*/
/*		Transferencia de Datos			*/
/*++++++++++++++++++++++++++++++++++++++*/

INSERT INTO table1 (campo1,campo2,...,campoN) SELECT campo1, campo2, ... , campoN FROM TABLE2;

INSERT INTO FEMIG.turnos (descripcion,hora_inicio,hora_fin,valor_ficha,valor_bandera)
SELECT (turno_descripcion,turno_hora_inicio,turno_hora_fin,turno_valor_ficha,turno_valor_bandera) FROM gd_esquema.maestra;

INSERT INTO FEMIG.clientes (nombre,apellido,fecha_nacimiento,telefono,direccion,mail,dni)
SELECT (cliente_nombre,cliente_apellido,cliente_fecha_nac,cliente_telefono,cliente_direccion,cliente_mail,cliente_dni) FROM  gd_esquema.maestra;

INSERT INTO FEMIG.facturacion (cod_cliente,fecha_inicio,fecha_fin)
SELECT (cc.cod_cliente,gd.factura_fecha_inicio,gd.factura_fecha_fin) FROM FEMIG.clientes cc, gd_esquema.maestra gd
WHERE gd.factura_fecha_inicio IS NOT NULL
AND gd.factura_fecha_fin IS NOT NULL
AND cc.dni = gd.cliente_dni;

INSERT INTO FEMIG.relojes (modelo,marca,reloj_fecha_ver)
SELECT DISTINCT(reloj_modelo,reloj_marca,reloj_fecha_ver) FROM gd_esquema.maestra;

INSERT INTO FEMIG.autos (patente,marca,modelo,licencia,rodado,modelo_reloj)
SELECT (auto_patente,auto_marca,auto_modelo,auto_licencia,auto_rodado,reloj_modelo) FROM gd_esquema.maestra;

INSERT INTO FEMIG.choferes (dni,nombre,apellido,licencia,fecha_nacimiento,telefono,direccion,mail)
SELECT (chofer_dni,chofer_nombre,chofer_apellido,auto_licencia,chofer_fecha_nac,chofer_telefono,chofer_direccion,chofer_mail) FROM gd_esquema.maestra;

INSERT INTO FEMIG.viajes (auto_patente,tipo_viaje,cliente,fecha,id_turno,cantidad_fichas)
SELECT (gd.auto_patente,?/*Calle o Cliente*/?,cc.cod_cliente,gd.viaje_fecha,tr.cod_turno,gd.viaje_cant_fichas) FROM gd_esquema.maestra gd, FEMIG.clientes cc, FEMIG.turnos tr
WHERE 

INSERT INTO FEMIG.rendicion (fecha,auto_patente,importe,cantidad_viajes)
SELECT (rendicion_fecha,gd.auto_patente,SUM(cantidad de fichas),COUNT(cantidad de viajes)) FROM gd_esquema.maestra gd ...


/*++++++++++++++++++++++++++++++++++++++*/
/*		Store Procedures				*/
/*++++++++++++++++++++++++++++++++++++++*/





