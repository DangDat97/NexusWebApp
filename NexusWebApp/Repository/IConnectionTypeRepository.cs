using NexusWebApp.Models;

namespace NexusWebApp.Repository
{
    public interface IConnectionTypeRepository
    {
        ConnectionType Add(ConnectionType connectionType);
        ConnectionType Update(ConnectionType connectionType);
        ConnectionType Delete(int id);

        ConnectionType Get(int id);
        IEnumerable<ConnectionType> GetAll();
    }
}
