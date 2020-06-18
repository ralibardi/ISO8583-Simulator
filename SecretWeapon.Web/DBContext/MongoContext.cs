using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SecretWeapon.Tools.Context;

namespace SecretWeapon.Web.DBContext
{
    public class MongoContext : IMongoContext
    {
        private IMongoDatabase Database { get; set; }
        public IClientSessionHandle Session { get; set; }
        public MongoClient MongoClient { get; set; }
        private readonly List<Func<Task>> _commands;
        private readonly IConfiguration _configuration;

        public MongoContext(IConfiguration configuration)
        {
            _configuration = configuration;


            // Every command will be stored and it'll be processed at SaveChanges
            _commands = new List<Func<Task>>();
        }

        public async Task<int> SaveChanges()
        {
            ConfigureMongo();

            using (Session = await MongoClient.StartSessionAsync())
            {
                Session.StartTransaction();

                var commandTasks = _commands.Select(c => c());

                await Task.WhenAll(commandTasks);

                await Session.CommitTransactionAsync();
            }

            return _commands.Count;
        }

        private void ConfigureMongo()
        {
            if (MongoClient != null)
                return;

            // Configure mongo (You can inject the config, just to simplify)
            MongoClient = new MongoClient(GetConnectionString());

            Database = MongoClient.GetDatabase(_configuration["MongoSettings:DatabaseName"]);

        }

        private string GetConnectionString()
        {
            var connectionStringBuilder = new StringBuilder();

            connectionStringBuilder.Append(_configuration["MongoSettings:DatabaseType"]);
            connectionStringBuilder.Append("://");
            connectionStringBuilder.Append(_configuration["MongoSettings:User"]);
            connectionStringBuilder.Append(":");
            connectionStringBuilder.Append(_configuration["MongoSettings:UserPassword"]);
            connectionStringBuilder.Append("@");
            connectionStringBuilder.Append(_configuration["MongoSettings:Host"]);
            connectionStringBuilder.Append(":");
            connectionStringBuilder.Append(_configuration["MongoSettings:Port"]);
            connectionStringBuilder.Append("/?");
            connectionStringBuilder.Append(_configuration["MongoSettings:SSL"]);
            connectionStringBuilder.Append("=");
            connectionStringBuilder.Append(_configuration["MongoSettings:HasSSL"]);
            connectionStringBuilder.Append("&");
            connectionStringBuilder.Append(_configuration["MongoSettings:SSLCert"]);
            connectionStringBuilder.Append("=");
            connectionStringBuilder.Append(_configuration["MongoSettings:Certificate"]);
            connectionStringBuilder.Append("&");
            connectionStringBuilder.Append(_configuration["MongoSettings:ReplicaSet"]);
            connectionStringBuilder.Append("=");
            connectionStringBuilder.Append(_configuration["MongoSettings:Replicas"]);
            connectionStringBuilder.Append("&");
            connectionStringBuilder.Append(_configuration["MongoSettings:ReadPreference"]);
            connectionStringBuilder.Append("=");
            connectionStringBuilder.Append(_configuration["MongoSettings:Preference"]);
            connectionStringBuilder.Append("&");
            connectionStringBuilder.Append(_configuration["MongoSettings:RetryWrites"]);
            connectionStringBuilder.Append("=");
            connectionStringBuilder.Append(_configuration["MongoSettings:Retries"]);

            return connectionStringBuilder.ToString();
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            ConfigureMongo();
            return Database.GetCollection<T>(name);
        }

        public void Dispose()
        {
            Session?.Dispose();
            GC.SuppressFinalize(this);
        }

        public void AddCommand(Func<Task> func)
        {
            _commands.Add(func);
        }
    }
}