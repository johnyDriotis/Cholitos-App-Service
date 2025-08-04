namespace CholitosGymService.Infrastructure.Queries
{
    public class ClientQuery
    {
        public static string AddClient()
        {
            return @"INSERT INTO Cliente(
	                    IdCliente, Base64HuellaDactilar, PrimerNombre, SegundoNombre, PrimerApellido, 
	                    SegundoApellido, ApellidoCasada, Estado
                    ) 
                    VALUES(
                    	@CodCliente, @HuellaDactilar, @PrimerNombre, @SegundoNombre, @PrimerApellido, 
                    	@SegundoApellido, @ApellidoCasada, @Estado
                    );";

        }
    }
}
