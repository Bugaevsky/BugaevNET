using System.Data.SqlClient;

namespace DAL
{
    public class Utilities
    {
        private readonly string _connection;
        public Utilities(string datasource, string database)
        {
            _connection = new SqlConnectionStringBuilder
            {
                DataSource = datasource,
                IntegratedSecurity = true,
                InitialCatalog = database
            }.ConnectionString;
        }

        public SqlConnection GetDbConnection()
        {
            return new SqlConnection(_connection);
        }
    }
}
