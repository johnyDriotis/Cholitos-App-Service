
-- Eliminar default constraint para Estado
GO
	ALTER TABLE Membresia
	DROP CONSTRAINT Ck_Membresia_Estado_01;
GO
	
-- Eliminar check constraint para valores A, I para Estado
GO
	ALTER TABLE Membresia
	DROP CONSTRAINT Ck_Membresia_Estado_02;
GO

-- Eliminar check constraint para Tipo M, Q
GO
	ALTER TABLE Membresia
	DROP CONSTRAINT Ck_Membresia_Tipo_01;
GO

-- Eliminar llave foranea hacia Cliente.
GO
	ALTER TABLE Membresia 
	DROP CONSTRAINT FK_Membresia_Cliente;
GO

-- Eliminar UNIQUE Constraint al codigo de membresia
GO
	ALTER TABLE Membresia
	DROP CONSTRAINT Ck_Membresia_IdMembresia_01;
GO

-- Eliminar llave primaria a tabla Membresia.
GO
	ALTER TABLE Membresia 
	DROP CONSTRAINT PK_Membresia;
GO

-- Eliminar tabla membresia.
GO
	DROP TABLE Membresia;
GO




