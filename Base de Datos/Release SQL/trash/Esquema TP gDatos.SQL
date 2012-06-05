CREATE TABLE Pantalla ( 
	pantallaID varchar(255) NOT NULL,
	descripcion varchar(255) NOT NULL
)
;

CREATE TABLE Rol ( 
	rolID varchar(20) NOT NULL,
	descripcion varchar(50) NOT NULL,
	anulado varchar(1)
)
;

CREATE TABLE RolPantalla ( 
	rolID varchar(20) NOT NULL,
	pantallaID varchar(255) NOT NULL,
	acceso varchar(1)
)
;

CREATE TABLE RolUsuario ( 
	usuarioID varchar(20) NOT NULL,
	rolID varchar(20) NOT NULL
)
;

CREATE TABLE Usuario ( 
	usuarioID varchar(20) NOT NULL,
	nombre varchar(50) NOT NULL,
	apellido varchar(50) NOT NULL,
	email varchar(100),
	password varchar(50) NOT NULL,
	cantIntentosFallo numeric(18),
	cantMaxIntentos numeric(18),
	anulado varchar(1)
)
;


ALTER TABLE Pantalla ADD CONSTRAINT PK_Pantalla 
	PRIMARY KEY CLUSTERED (pantallaID)
;

ALTER TABLE Rol ADD CONSTRAINT PK_Roles 
	PRIMARY KEY CLUSTERED (rolID)
;

ALTER TABLE RolPantalla ADD CONSTRAINT PK_RolesPantallas 
	PRIMARY KEY CLUSTERED (rolID, pantallaID)
;

ALTER TABLE RolUsuario ADD CONSTRAINT PK_RolesUsuarios 
	PRIMARY KEY CLUSTERED (usuarioID, rolID)
;

ALTER TABLE Usuario ADD CONSTRAINT PK_Usuarios 
	PRIMARY KEY CLUSTERED (usuarioID)
;



ALTER TABLE RolPantalla ADD CONSTRAINT FK_RolPantalla_Pantalla 
	FOREIGN KEY (pantallaID) REFERENCES Pantalla (pantallaID)
;

ALTER TABLE RolPantalla ADD CONSTRAINT FK_RolPantalla_Rol 
	FOREIGN KEY (rolID) REFERENCES Rol (rolID)
;

ALTER TABLE RolUsuario ADD CONSTRAINT FK_RolUsuario_Rol 
	FOREIGN KEY (rolID) REFERENCES Rol (rolID)
;

ALTER TABLE RolUsuario ADD CONSTRAINT FK_RolUsuario_Usuario 
	FOREIGN KEY (usuarioID) REFERENCES Usuario (usuarioID)
;

CREATE TABLE Auto ( 
	patente varchar(10) NOT NULL,
	marca varchar(255) NOT NULL,
	modelo varchar(255) NOT NULL,
	licencia varchar(26) NOT NULL,
	rodado varchar(10) NOT NULL,
	nroSerieReloj varchar(18) NOT NULL,
	anulado varchar(1)
)
;

CREATE TABLE Chofer ( 
	dniChofer numeric(18) NOT NULL,
	nombre varchar(255) NOT NULL,
	apellido varchar(255) NOT NULL,
	direccion varchar(255) NOT NULL,
	telefono numeric(18) NOT NULL,
	email varchar(50),
	fechaNacimiento datetime NOT NULL,
	anulado varchar(1)
)
;

CREATE TABLE ChoferAutoTurno ( 
	fecha datetime NOT NULL,
	patente varchar(10) NOT NULL,
	dniChofer numeric(18) NOT NULL,
	turnoID varchar(20) NOT NULL
)
;

CREATE TABLE Cliente ( 
	dniCliente numeric(18) NOT NULL,
	nombre varchar(255) NOT NULL,
	apellido varchar(255) NOT NULL,
	telefono numeric(18) NOT NULL,
	direccion varchar(255) NOT NULL,
	email varchar(255),
	fechaNacimiento datetime NOT NULL,
	anulado varchar(1)
)
;

CREATE TABLE Reloj ( 
	nroSerieReloj varchar(18) NOT NULL,
	marca varchar(255) NOT NULL,
	modelo varchar(255) NOT NULL,
	fechaVersion datetime NOT NULL,
	anulado varchar(1)
)
;

CREATE TABLE Turno ( 
	turnoID varchar(20) NOT NULL,
	horaInicio numeric(18) NOT NULL,
	horaFin numeric(18) NOT NULL,
	descripcion varchar(255) NOT NULL,
	valorFicha numeric(18,2) NOT NULL,
	valorBandera numeric(18,2) NOT NULL,
	anulado varchar(1)
)
;

CREATE TABLE Viaje ( 
	viajeID numeric(18) NOT NULL,
	tipoViaje varchar(10) NOT NULL,
	patente varchar(10) NOT NULL,
	dniChofer numeric(18) NOT NULL,
	turnoID varchar(20) NOT NULL,
	cantFichas numeric(18) NOT NULL,
	fecha datetime NOT NULL,
	dniCliente numeric(18)
)
;


ALTER TABLE Auto ADD CONSTRAINT PK_Auto 
	PRIMARY KEY CLUSTERED (patente)
;

ALTER TABLE Chofer ADD CONSTRAINT PK_Chofer 
	PRIMARY KEY CLUSTERED (dniChofer)
;

ALTER TABLE ChoferAutoTurno ADD CONSTRAINT PK_ChoferAutoTurno 
	PRIMARY KEY CLUSTERED (patente, dniChofer, turnoID)
;

ALTER TABLE Cliente ADD CONSTRAINT PK_Cliente 
	PRIMARY KEY CLUSTERED (dniCliente)
;

ALTER TABLE Reloj ADD CONSTRAINT PK_Reloj 
	PRIMARY KEY CLUSTERED (nroSerieReloj)
;

ALTER TABLE Turno ADD CONSTRAINT PK_Turno 
	PRIMARY KEY CLUSTERED (turnoID)
;

ALTER TABLE Viaje ADD CONSTRAINT PK_Viaje 
	PRIMARY KEY CLUSTERED (viajeID)
;


ALTER TABLE Auto
	ADD CONSTRAINT UQ_Auto_licencia UNIQUE (licencia)
;

ALTER TABLE Auto
	ADD CONSTRAINT UQ_Auto_nroSerieReloj UNIQUE (nroSerieReloj)
;

ALTER TABLE Chofer
	ADD CONSTRAINT UQ_Chofer_email UNIQUE (email)
;

ALTER TABLE Cliente
	ADD CONSTRAINT UQ_Cliente_email UNIQUE (email)
;

ALTER TABLE Cliente
	ADD CONSTRAINT UQ_Cliente_telefono UNIQUE (telefono)
;


ALTER TABLE Auto ADD CONSTRAINT FK_Auto_Reloj 
	FOREIGN KEY (nroSerieReloj) REFERENCES Reloj (nroSerieReloj)
;

ALTER TABLE ChoferAutoTurno ADD CONSTRAINT FK_ChoferAutoTurno_Auto 
	FOREIGN KEY (patente) REFERENCES Auto (patente)
;

ALTER TABLE ChoferAutoTurno ADD CONSTRAINT FK_ChoferAutoTurno_Chofer 
	FOREIGN KEY (dniChofer) REFERENCES Chofer (dniChofer)
;

ALTER TABLE ChoferAutoTurno ADD CONSTRAINT FK_ChoferAutoTurno_Turno 
	FOREIGN KEY (turnoID) REFERENCES Turno (turnoID)
;

ALTER TABLE Viaje ADD CONSTRAINT FK_Viaje_ChoferAutoTurno 
	FOREIGN KEY (patente, dniChofer, turnoID) REFERENCES ChoferAutoTurno (patente, dniChofer, turnoID)
;

ALTER TABLE Viaje ADD CONSTRAINT FK_Viaje_Cliente 
	FOREIGN KEY (dniCliente) REFERENCES Cliente (dniCliente)
;
