namespace GimnasioService.Infrastructure.Queries
{
    public class ClientQuery
    {
        public static string AddClient()
        {
            return @"INSERT INTO Cliente(
	                    IdCliente, Base64HuellaDactilar, PrimerNombre, SegundoNombre, PrimerApellido, 
	                    SegundoApellido, ApellidoCasada, Estado, FechaAdicion, AdicionadoPor
                    ) 
                    VALUES(
                    	@CodCliente, @HuellaDactilar, @PrimerNombre, @SegundoNombre, @PrimerApellido, 
                    	@SegundoApellido, @ApellidoCasada, @Estado, @FechaAdicion, @AdicionadoPor
                    );";

        }
    }
}
