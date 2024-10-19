using CholitosGym.WebApi.Domain;

namespace CholitosGym.WebApi.Repository
{
    public static class ClientRepository
    {
        public static List<Client> Clients { get; set; } = new List<Client>
            {
                new Client{
                    Id = 1,
                    PrimerNombre = "Johny",
                    SegundoNombre = "Alexander",
                    PrimerApellido = "Driotis",
                    SegundoApellido = "Cruz",
                    Genero = "Masculino",
                    Edad = 28
                },
                new Client{
                    Id = 2,
                    PrimerNombre = "David",
                    SegundoNombre = "Otoniel",
                    PrimerApellido = "Driotis",
                    SegundoApellido = "Cruz",
                    Genero = "Masculino",
                    Edad = 21
                },
                new Client{
                    Id = 3,
                    PrimerNombre = "Mirna",
                    SegundoNombre = "Magaly",
                    PrimerApellido = "Cruz",
                    ApellidoCasada = "de Driotis",
                    Genero = "Femenino",
                    Edad = 46
                }
            };
    }
}
