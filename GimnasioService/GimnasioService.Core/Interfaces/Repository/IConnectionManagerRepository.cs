using System.Data;

namespace GimnasioService.Core.Interfaces.Repository
{
    public interface IConnectionManagerRepository
    {
        string ConnectToDatabaseWithMessage();
        IDbConnection OpenAndReturnConnectionOfDatabase();
        void CloseConnectionToDatabase();
    }
}
