
-- Crear tabla de membresias
	CREATE TABLE Membresia(
		IdMembresia		INT			NOT NULL	IDENTITY(1,1),
		IdCliente		INT			NOT NULL,
		FechaPago		DATETIME	NOT NULL,
		FechaInicio		DATETIME	NOT NULL,
		FechaFin		DATETIME	NOT NULL
	);
GO

-- Agregar llave primaria a tabla membresia
	ALTER TABLE Membresia 
	ADD CONSTRAINT PK_Membresia PRIMARY KEY(IdMembresia);
GO

-- Agregar llave foranea hacia clientes
	ALTER TABLE Membresia
	ADD CONSTRAINT FK_Membresia_Cliente FOREIGN KEY (IdCliente)
	REFERENCES Cliente (IdCliente)
GO

-- Agregar Constraint para Tipo
	ALTER TABLE Membresia
	ADD Tipo CHAR(1) NOT NULL 
	CONSTRAINT Ck_Membresia_01 DEFAULT ('Q')
	CONSTRAINT Ck_Membresia_02 CHECK (Tipo IN ('Q', 'M'))
GO


