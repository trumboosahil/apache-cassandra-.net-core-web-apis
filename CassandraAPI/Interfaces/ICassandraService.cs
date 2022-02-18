using Cassandra;
using System.Threading.Tasks;

namespace CassandraAPI.Interfaces
{
    public interface ICassandraService
    {
        ISession Session { get; }
    }
}
