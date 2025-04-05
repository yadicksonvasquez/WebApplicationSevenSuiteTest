

CREATE DATABASE seven_suite_test_db
GO

use seven_suite_test_db
GO

CREATE TABLE SEVECLIE (
	id INT IDENTITY (1, 1) PRIMARY KEY,
	cedula VARCHAR (15) NOT NULL,
	nombre VARCHAR (25) NOT NULL,
	genero CHAR (1) NOT NULL,
	fecha_nac DATE NOT NULL,
	email VARCHAR (255) NOT NULL,
	estado_civil CHAR (1),
	CONSTRAINT chk_genero CHECK (genero in ('M', 'F')),
	CONSTRAINT chk_estado_civil CHECK (estado_civil in ('V', 'S', 'C'))
)
GO

CREATE TABLE ESTADO_CIVIL (
	id INT IDENTITY (1, 1) PRIMARY KEY,
	codigo CHAR (1),
	nombre VARCHAR (15),
	CONSTRAINT chk_valor CHECK (codigo in ('V', 'S', 'C'))
)

GO
CREATE TABLE USUARIO (
  id INT IDENTITY (1, 1) PRIMARY KEY,
  nombre VARCHAR(30) NOT NULL,
  clave VARCHAR(250) NOT NULL,
  habilitado TINYINT NOT NULL,
)

GO

INSERT INTO [ESTADO_CIVIL]
           (codigo,nombre)
     VALUES
           ('S', 'Soltero');
		  
		  
INSERT INTO [ESTADO_CIVIL]
            (codigo,nombre)
     VALUES
           ('C', 'Casado');

INSERT INTO [ESTADO_CIVIL]
            (codigo,nombre)
     VALUES
           ('V', 'Viudo');
		  
GO

