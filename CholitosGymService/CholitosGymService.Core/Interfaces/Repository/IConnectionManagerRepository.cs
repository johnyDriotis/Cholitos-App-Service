using System.Data;

namespace CholitosGymService.Core.Interfaces.Repository
{
    public interface IConnectionManagerRepository
    {
        string ConnectToDatabaseWithMessage();
        IDbConnection OpenAndReturnConnectionOfDatabase();
        void CloseConnectionToDatabase();
    }
}
