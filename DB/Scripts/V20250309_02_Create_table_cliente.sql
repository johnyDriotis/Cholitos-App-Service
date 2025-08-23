
-- Crear tabla de clientes.
GO
	CREATE TABLE Cliente(
		IdCliente				VARCHAR(10)		NOT NULL,
		Base64HuellaDactilar	VARCHAR(MAX)	NOT NULL,
		PrimerNombre			VARCHAR(30)		NOT NULL,
		SegundoNombre			VARCHAR(30)		NULL,
		PrimerApellido			VARCHAR(30)		NOT NULL,
		SegundoApellido			VARCHAR(30)		NULL,
		ApellidoCasada			VARCHAR(30)		NULL
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
ALTER TABLE Cliente
ADD CONSTRAINT Ck_IdCliente_01 UNIQUE(IdCliente)

/*
	Crear columna Estado,
	Crear default constraint.
	Crear check constraint para valores A, I
*/
ALTER TABLE Cliente
ADD Estado CHAR(1) NOT NULL 
CONSTRAINT Ck_Estado_01 DEFAULT ('A')
CONSTRAINT Ck_Estado_02 CHECK (Estado IN ('A', 'I'))

