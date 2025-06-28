
-- Poner en uso la base de datos Gimnasio.
GO
	USE Gimnasio
GO

-- Crear tabla de clientes.
GO
	CREATE TABLE Cliente(
		IdCliente			INT				NOT NULL,
		CodigoGimnasio		VARCHAR(10)		NOT NULL,	
		PrimerNombre		VARCHAR(30)		NOT NULL,
		SegundoNombre		VARCHAR(30)		NULL,
		PrimerApellido		VARCHAR(30)		NOT NULL,
		SegundoApellido		VARCHAR(30)		NULL,
		ApellidoCasada		VARCHAR(30)		NULL
	);
GO

-- Agregar llave primaria a tabla Cliente.
GO
	ALTER TABLE Cliente 
	ADD CONSTRAINT PK_Cliente PRIMARY KEY(IdCliente);
GO