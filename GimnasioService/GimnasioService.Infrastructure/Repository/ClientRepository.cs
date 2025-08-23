using CholitosAppFront.Core.Utils;
using GimnasioService.Core.Interfaces.Repository;
using GimnasioService.Core.Request;
using GimnasioService.Core.Response;
using GimnasioService.Infrastructure.Queries;
using Dapper;
using System.Data;
using System.Diagnostics;

namespace CholitosAppFront.Infrastructure.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly IConnectionManagerRepository _connectionManagerRepository;
        private readonly IDbConnection _dbConnection;

        public ClientRepository(IConnectionManagerRepository connectionManagerRepository, IDbConnection dbConnection)
        {
            _connectionManagerRepository = connectionManagerRepository ?? throw new ArgumentNullException(nameof(connectionManagerRepository));
            _dbConnection = _connectionManagerRepository.OpenAndReturnConnectionOfDatabase();
        }

        public async Task<GenericResponseBd<string>> AddClient(ClientRequest clientRequest)
        {
            string clientCode = FunctionsUtils.GenerateGymCode(5);
            try
            {
                string query = ClientQuery.AddClient();
                int res = await _dbConnection.ExecuteAsync(query, new
                {
                    @CodCliente = clientCode,
                    @HuellaDactilar = clientRequest.HuellaDactilar,
                    @PrimerNombre = clientRequest.PrimerNombre,
                    @SegundoNombre = clientRequest.SegundoNombre,
                    @PrimerApellido = clientRequest.PrimerApellido,
                    @SegundoApellido = clientRequest.SegundoApellido,
                    @ApellidoCasada = clientRequest.ApellidoCasada,
                    @Estado = clientRequest.Estado
                });
            }
            catch (Exception ex)
            {
                Trace.WriteLine("ClientRepository - AddClient - Ocurrio un error al guardar el cliente: " + ex.Message);

                return new GenericResponseBd<string>
                {
                    ErrorMessage = "ClientRepository - AddClient - Ocurrio un error al guardar el cliente: " + ex.Message,
                    IsError = true
                };
            }

            return new GenericResponseBd<string>
            {
                SuccessMessage = "Cliente agregado satisfactoriamente",
                ErrorMessage = "",
                IsError = false,
                Item = clientCode
            };
        }

    }
}
