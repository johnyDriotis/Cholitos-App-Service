
-- Crear tabla de membresias.
GO
	CREATE TABLE Membresia(
		IdMembresia				VARCHAR(10)		NOT NULL,
		IdCliente				VARCHAR(10)		NOT NULL,
		FechaPago				DATETIME		NOT NULL,
		FechaInicio				DATETIME		NOT NULL,
		FechaFin				DATETIME		NOT NULL,
		Tipo					CHAR(1)			NOT NULL,
		Estado					CHAR(1)			NOT NULL,

		FechaAdicion			DATETIME		NOT NULL,
		AdicionadoPor			VARCHAR(15)		NOT NULL,
		FechaModificacion		DATETIME		NULL,
		ModificadoPor			VARCHAR(15)		NULL
	);
GO

-- Agregar llave primaria a tabla Membresia.
GO
	ALTER TABLE Membresia 
	ADD CONSTRAINT PK_Membresia PRIMARY KEY(IdMembresia);
GO

/*
	Agregar UNIQUE Constraint al codigo de membresia
*/
GO
	ALTER TABLE Membresia
	ADD CONSTRAINT Ck_Membresia_IdMembresia_01 UNIQUE(IdMembresia);
GO

-- Agregar llave foranea hacia Cliente.
GO
	ALTER TABLE Membresia 
	ADD CONSTRAINT FK_Membresia_Cliente 
	FOREIGN KEY(IdCliente) REFERENCES Cliente;
GO

/*
	Crear check constraint para tipo M, Q
*/
GO
	ALTER TABLE Membresia
	ADD CONSTRAINT Ck_Membresia_Tipo_01 CHECK (Tipo IN ('M', 'Q'));
GO
	
/*
	Crear default constraint para Estado
*/
GO
	ALTER TABLE Membresia
	ADD CONSTRAINT Ck_Membresia_Estado_01 CHECK(Estado = 'A');
GO
	
/*
	Crear check constraint para valores A, I para Estado
*/
GO
	ALTER TABLE Membresia
	ADD CONSTRAINT Ck_Membresia_Estado_02 CHECK (Estado IN ('A', 'I'));
GO


