
-- Crear tabla de clientes.
GO
	CREATE TABLE Cliente(
		IdCliente				VARCHAR(10)		NOT NULL,
		Base64HuellaDactilar	VARCHAR(MAX)	NOT NULL,
		PrimerNombre			VARCHAR(30)		NOT NULL,
		SegundoNombre			VARCHAR(30)		NULL,
		PrimerApellido			VARCHAR(30)		NOT NULL,
		SegundoApellido			VARCHAR(30)		NULL,
		ApellidoCasada			VARCHAR(30)		NULL,
		Estado					CHAR(1)			NOT NULL,

		FechaAdicion			DATETIME		NOT NULL,
		AdicionadoPor			VARCHAR(15)		NOT NULL,
		FechaModificacion		DATETIME		NULL,
		ModificadoPor			VARCHAR(15)		NULL
	);
GO

-- Agregar llave primaria a tabla Cliente.
GO
	ALTER TABLE Cliente 
	ADD CONSTRAINT PK_Cliente PRIMARY KEY(IdCliente);
GO

/*
	Agregar UNIQUE Constraint al codigo del cliente
*/
GO
	ALTER TABLE Cliente
	ADD CONSTRAINT Ck_Cliente_IdCliente_01 UNIQUE(IdCliente);
GO

/*
	Crear default constraint para Estado
*/
GO
	ALTER TABLE Cliente
	ADD CONSTRAINT Ck_Cliente_Estado_01 CHECK(Estado = 'A');
GO


/*
	Crear check constraint para valores A, I para Estado
*/
GO
	ALTER TABLE Cliente
	ADD CONSTRAINT Ck_Cliente_Estado_02 CHECK (Estado IN ('A', 'I'));
GO


