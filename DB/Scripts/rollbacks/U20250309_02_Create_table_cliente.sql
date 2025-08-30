
/*
	Eliminar default constraint para Estado
*/
GO
	ALTER TABLE Cliente
	DROP CONSTRAINT Ck_Cliente_Estado_01;
GO

/*
	Eliminar check constraint para valores A, I para Estado
*/
GO
	ALTER TABLE Cliente
	DROP CONSTRAINT Ck_Cliente_Estado_02;
GO

/*
	Eliminar UNIQUE Constraint al codigo del cliente
*/
GO
	ALTER TABLE Cliente
	DROP CONSTRAINT Ck_Cliente_IdCliente_01;
GO

-- Eliminar llave primaria a tabla Cliente.
GO
	ALTER TABLE Cliente 
	DROP CONSTRAINT PK_Cliente;
GO

-- Eliminar tabla cliente.
GO
	DROP TABLE Cliente;
GO

