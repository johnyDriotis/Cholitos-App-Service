using CholitosGymService.Core.Interfaces;
using System.Data;

namespace CholitosAppFront.Infrastructure.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly IConnectionManagerRepository _connectionManagerRepository;
        //private readonly IMapper _mapper;
        private readonly IProperties _properties;

        private readonly IDbConnection _dbConnection;

        public ClientRepository(IConnectionManagerRepository connectionManagerRepository /*IMapper mapper*/
            , IProperties properties)
        {
            _connectionManagerRepository = connectionManagerRepository ?? throw new ArgumentNullException(nameof(connectionManagerRepository));
            //_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _properties = properties ?? throw new ArgumentNullException(nameof(properties));

            _dbConnection = _connectionManagerRepository.OpenAndReturnConnectionOfDatabase();
        }

        //public async Task<GenericResponse<List<ClientDto>>> GetAllClients()
        //{
        //    try
        //    {
        //        int init = zkfp2.Init();

        //        Console.WriteLine("Device initialized");

        //        string query = ClientQuery.GetAllClients();
        //        var clientsDb = await _dbConnection.QueryAsync<ClientDomain>(query);
        //        var dataMappedClients = _mapper.Map<List<ClientDomain>, List<ClientDto>>(clientsDb.ToList());

        //        return new GenericResponse<List<ClientDto>>()
        //        {
        //            GeneroError = false,
        //            Item = dataMappedClients
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        Trace.WriteLine("ClientRepository - GetAllClients - Ocurrio un error al obtener los clientes: " + ex.Message);

        //        return new GenericResponse<List<ClientDto>>()
        //        {
        //            GeneroError = true,
        //            ErrorGenerado = ex.Message
        //        };
        //    }

        //}

        //public async Task<GenericResponse<ClientDto>> AddClient(ClientRequest clientRequest)
        //{
        //    try
        //    {
        //        string codeGym = ClientUtils.GenerateGymCode(5);

        //        string query = ClientQuery.AddClient();
        //        int res = await _dbConnection.ExecuteAsync(query, new
        //        {
        //            CodigoGimnasio = codeGym,
        //            PrimerNombre = clientRequest.PrimerNombre,
        //            SegundoNombre = clientRequest.SegundoNombre,
        //            PrimerApellido = clientRequest.PrimerApellido,
        //            SegundoApellido = clientRequest.SegundoApellido,
        //            ApellidoCasada = clientRequest.ApellidoCasada,
        //            Estado = clientRequest.Estado
        //        });

        //        return new GenericResponse<ClientDto>()
        //        {
        //            GeneroError = false,
        //            Item = new ClientDto()
        //            {
        //                CodigoGimnasio = codeGym,
        //                PrimerNombre = clientRequest.PrimerNombre,
        //                SegundoNombre = clientRequest.SegundoNombre,
        //                PrimerApellido = clientRequest.PrimerApellido,
        //                SegundoApellido = clientRequest.SegundoApellido,
        //                ApellidoCasada = clientRequest.ApellidoCasada,
        //                Estado = clientRequest.Estado
        //            }
        //        };

        //    }
        //    catch (Exception ex)
        //    {
        //        Trace.WriteLine("ClientRepository - AddClient - Ocurrio un error al guardar el cliente: " + ex.Message);

        //        return new GenericResponse<ClientDto>()
        //        {
        //            GeneroError = true,
        //            ErrorGenerado = ex.Message
        //        };
        //    }

        //}

        //public async Task<GenericResponse<ClientDto>> ModifyClient(ClientRequest clientRequest)
        //{
        //    try
        //    {
        //        string query = ClientQuery.ModifyClient();
        //        int res = await _dbConnection.ExecuteAsync(query, new
        //        {
        //            PrimerNombre = clientRequest.PrimerNombre,
        //            SegundoNombre = clientRequest.SegundoNombre,
        //            PrimerApellido = clientRequest.PrimerApellido,
        //            SegundoApellido = clientRequest.SegundoApellido,
        //            ApellidoCasada = clientRequest.ApellidoCasada,
        //            IdCliente = clientRequest.IdCliente,
        //            Estado = clientRequest.Estado
        //        });

        //        return new GenericResponse<ClientDto>()
        //        {
        //            GeneroError = false,
        //            Item = new ClientDto()
        //            {
        //                CodigoCliente = clientRequest.IdCliente.ToString(),
        //                PrimerNombre = clientRequest.PrimerNombre,
        //                SegundoNombre = clientRequest.SegundoNombre,
        //                PrimerApellido = clientRequest.PrimerApellido,
        //                SegundoApellido = clientRequest.SegundoApellido,
        //                ApellidoCasada = clientRequest.ApellidoCasada //,
        //                //Estado = clientRequest.Estado == false ? "Inactivo" : "Activo"
        //            }
        //        };

        //    }
        //    catch (Exception ex)
        //    {
        //        Trace.WriteLine("ClientRepository - ModifyClient - Ocurrio un error al modificar el cliente: " + ex.Message);

        //        return new GenericResponse<ClientDto>()
        //        {
        //            GeneroError = true,
        //            ErrorGenerado = ex.Message
        //        };
        //    }

        //}

        //public async Task<GenericResponse<ClientDto>> DeleteClient(ClientRequest clientRequest)
        //{
        //    try
        //    {
        //        string query = ClientQuery.DeleteClient();
        //        int res = await _dbConnection.ExecuteAsync(query, new
        //        {
        //            IdCliente = clientRequest.IdCliente
        //        });

        //        return new GenericResponse<ClientDto>()
        //        {
        //            GeneroError = false,
        //            Item = new ClientDto()
        //            {
        //                CodigoCliente = clientRequest.IdCliente.ToString(),
        //                PrimerNombre = clientRequest.PrimerNombre,
        //                SegundoNombre = clientRequest.SegundoNombre,
        //                PrimerApellido = clientRequest.PrimerApellido,
        //                SegundoApellido = clientRequest.SegundoApellido,
        //                ApellidoCasada = clientRequest.ApellidoCasada
        //            }
        //        };

        //    }
        //    catch (Exception ex)
        //    {
        //        Trace.WriteLine("ClientRepository - DeleteClient - Ocurrio un error al eliminar el cliente: " + ex.Message);

        //        return new GenericResponse<ClientDto>()
        //        {
        //            GeneroError = true,
        //            ErrorGenerado = ex.Message
        //        };
        //    }

        //}

        //public async Task<GenericResponse<ClientDto>> ChangeStateClient(ClientRequest clientRequest)
        //{
        //    try
        //    {
        //        string query = ClientQuery.ChangeStateClient();
        //        int res = await _dbConnection.ExecuteAsync(query, new
        //        {
        //            Estado = clientRequest.Estado,
        //            IdCliente = clientRequest.IdCliente
        //        });

        //        return new GenericResponse<ClientDto>()
        //        {
        //            GeneroError = false,
        //            Item = new ClientDto()
        //            {
        //                CodigoCliente = clientRequest.IdCliente.ToString(),
        //                PrimerNombre = clientRequest.PrimerNombre,
        //                SegundoNombre = clientRequest.SegundoNombre,
        //                PrimerApellido = clientRequest.PrimerApellido,
        //                SegundoApellido = clientRequest.SegundoApellido,
        //                ApellidoCasada = clientRequest.ApellidoCasada
        //            }
        //        };

        //    }
        //    catch (Exception ex)
        //    {
        //        Trace.WriteLine("ClientRepository - ChangeStateClient - Ocurrio un error al cambiar el estado del cliente: " + ex.Message);

        //        return new GenericResponse<ClientDto>()
        //        {
        //            GeneroError = true,
        //            ErrorGenerado = ex.Message
        //        };
        //    }

        //}

        //public async Task<GenericResponse<ClientDto>> GetClientById(int idCliente)
        //{
        //    try
        //    {
        //        string query = ClientQuery.GetClientById();
        //        var clientDb = await _dbConnection.QueryFirstAsync<ClientDomain>(query, new { IdCliente = idCliente });
        //        var dataMappedClient = _mapper.Map<ClientDomain, ClientDto>(clientDb);

        //        return new GenericResponse<ClientDto>()
        //        {
        //            GeneroError = false,
        //            Item = dataMappedClient
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        Trace.WriteLine("ClientRepository - GetClientById - Ocurrio un error al obtener el cliente: " + ex.Message);

        //        return new GenericResponse<ClientDto>()
        //        {
        //            GeneroError = true,
        //            ErrorGenerado = ex.Message
        //        };
        //    }

    }
}
