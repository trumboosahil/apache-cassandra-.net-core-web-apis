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
                    string path = configuration.GetValue<string>("path1", "");
                    string username = configuration.GetValue<string>("username1", "");
                    string password = configuration.GetValue<string>("password", "");
                    session =
                    Cluster.Builder()
                         .WithCloudSecureConnectionBundle(path)                         
                         .WithCredentials(username, password)
                         .Build()
                         .Connect("atmospheric");
                }
                return session;
            }
        }

       
    }
}
