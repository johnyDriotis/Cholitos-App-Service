using System.Data;

namespace CholitosGymService.Core.Interfaces
{
    public interface IConnectionManagerRepository
    {
        string ConnectToDatabaseWithMessage();
        IDbConnection OpenAndReturnConnectionOfDatabase();
        void CloseConnectionToDatabase();
    }
}
