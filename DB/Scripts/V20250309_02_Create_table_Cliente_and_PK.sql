
-- Poner en uso la base de datos Gimnasio.

GO
	USE Gimnasio

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