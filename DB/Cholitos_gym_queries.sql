
GO
	USE Gimnasio;
GO

-- ********** Consultas para clientes

SELECT * FROM dbo.Cliente;

DELETE FROM dbo.Cliente;

SELECT 
	IdCliente	[Codigo_Cliente],
	CodigoGimnasio	[Codigo_Gimnasio],
	PrimerNombre	[Primer_Nombre],
	SegundoNombre	[Segundo_Nombre],
	PrimerApellido	[Primer_Apellido],
	SegundoApellido	[Segundo_Apellido],
	ApellidoCasada	[Apellido_Casada]
FROM 
	Cliente;
--WHERE 
--	CodigoGimnasio LIKE '%%'
--	OR PRIMER_NOMBRE LIKE '%%'

-- ********** Consultas para Membresias

SELECT TOP 10 * FROM dbo.Membresia;	
	