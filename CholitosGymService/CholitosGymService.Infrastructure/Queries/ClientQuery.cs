namespace CholitosGymService.Infrastructure.Queries
{
    public class ClientQuery
    {
        public static string GetAllClients() {
            return @"SELECT 
						IdCliente	[Codigo_Cliente],
						CodigoGimnasio	[Codigo_Gimnasio],
						PrimerNombre	[Primer_Nombre],
						SegundoNombre	[Segundo_Nombre],
						PrimerApellido	[Primer_Apellido],
						SegundoApellido	[Segundo_Apellido],
						ApellidoCasada	[Apellido_Casada],
						Estado			[Estado]
					FROM 
						Cliente";
        }

		public static string AddClient() {
			return @"INSERT INTO Cliente(
						CodigoGimnasio, PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, 
						ApellidoCasada, Estado)
					VALUES(
						@CodigoGimnasio, @PrimerNombre, @SegundoNombre, @PrimerApellido, @SegundoApellido,
						@ApellidoCasada, @Estado
					)";
		}

        public static string ModifyClient()
        {
			return @"UPDATE 
						Cliente
					SET
						PrimerNombre = @PrimerNombre,
						SegundoNombre = @SegundoNombre,
						PrimerApellido = @PrimerApellido,
						SegundoApellido = @SegundoApellido,
						ApellidoCasada = @ApellidoCasada,
						Estado = @Estado
					WHERE
						IdCliente = @IdCliente";
        }

        public static string DeleteClient()
        {
            return @"DELETE FROM 
						Cliente 
					WHERE 
						IdCliente = @IdCliente";
        }

        public static string ChangeStateClient()
        {
            return @"UPDATE 
						Cliente
					SET
						Estado = @Estado
					WHERE
						IdCliente = @IdCliente";
        }

        public static string GetClientById()
        {
			return @"SELECT 
						IdCliente	[Codigo_Cliente],
						CodigoGimnasio	[Codigo_Gimnasio],
						PrimerNombre	[Primer_Nombre],
						SegundoNombre	[Segundo_Nombre],
						PrimerApellido	[Primer_Apellido],
						SegundoApellido	[Segundo_Apellido],
						ApellidoCasada	[Apellido_Casada],
						Estado			[Estado]
					FROM 
						Cliente
					WHERE 
						IdCliente = @IdCliente";
        }
    }
}
