using Cassandra;
using CassandraAPI.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace CassandraAPI.Services
{
    public class CassandraService : ICassandraService
    {
        private readonly IConfiguration configuration;
        private ISession session;

        public CassandraService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public ISession Session
        {
            get
            {
                //If the session is null then create a new one
                if (session == null)
                {
                    string path = configuration.GetValue<string>("path1", "C:\\Git\\cassandra\\secure-connect-school.zip");
                    string username = configuration.GetValue<string>("username1", "fWptJlyoYZWdMOZMRZnZZFTp");
                    string password = configuration.GetValue<string>("password", "ijbHotG.2zYDy842KR8yuKD_nA39JquwJh0xYn3a6uCYN.0hGep8vH0MBk5KjGNJc2JH3t7c8d4A9veMe8OqSajo1sOuj3QAWS8FQwJrLYeBec8b,qMTgAbiov.XpDXj");
                    session =
                    Cluster.Builder()
                         .WithCloudSecureConnectionBundle(path)
                         //or if on linux .WithCloudSecureConnectionBundle(@"/PATH/TO/>>secure-connect-school.zip")
                         .WithCredentials(username, password)
                         .Build()
                         .Connect("atmospheric");
                }
                return session;
            }
        }

       
    }
}
