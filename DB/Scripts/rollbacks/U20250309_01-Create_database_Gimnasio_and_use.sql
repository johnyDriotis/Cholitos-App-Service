
-- Poner en uso la base de datos master para borrar la base de datos gimnasio
GO
	USE master;
GO

-- Borrar base de datos aunque se encuentre en uso en ese momento.
GO
	ALTER DATABASE Gimnasio SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE Gimnasio;
GO