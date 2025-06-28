
-- Eliminar check constraint Default
	ALTER TABLE Cliente
	DROP CONSTRAINT Ck_Estado_02
GO

-- Eliminar check constraint de valores
	ALTER TABLE Cliente
	DROP CONSTRAINT Ck_Estado_01
GO

-- Eliminar columna de tabla
	ALTER TABLE Cliente
	DROP COLUMN Estado
GO


