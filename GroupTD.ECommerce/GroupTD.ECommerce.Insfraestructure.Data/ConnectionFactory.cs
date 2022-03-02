using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using GroupTD.ECommerce.Transversal.Common;

namespace GroupTD.ECommerce.Insfraestructure.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetConnection
        {
            get
            {
                var sqlConnection = new SqlConnection();
                
                sqlConnection.ConnectionString = _configuration.GetConnectionString("NorthwindConnection");
                sqlConnection.Open();
                return sqlConnection;

            }
        }
    }
}
