
-- Eliminar FK llamada FK_Membresia_Cliente
	ALTER TABLE Membresia
	DROP CONSTRAINT FK_Membresia_Cliente;
GO

-- Eliminar PK llamada PK_Membresia de la tabla Membresia
	ALTER TABLE Membresia
	DROP CONSTRAINT PK_Membresia;
GO

-- Eliminar Constraint default de Tipo de tabla Membresia
	ALTER TABLE Membresia
	DROP CONSTRAINT Ck_Membresia_01;
GO

-- Eliminar Constraint de valores Tipo de tabla Membresia
	ALTER TABLE Membresia
	DROP CONSTRAINT Ck_Membresia_02;
GO

-- Eliminar tabla Membresia
	DROP TABLE Membresia;
GO