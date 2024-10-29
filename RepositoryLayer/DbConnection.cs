using System.Data;
using System.Data.SqlClient;

namespace RepositoryLayer
{
    public sealed class DbConnection
    {
        private static readonly Lazy<DbConnection> _instance = 
            new Lazy<DbConnection>(() => new DbConnection());

        private readonly string _connectionString;
        private SqlConnection _connection;
        private static readonly object _lock = new object();

        private DbConnection() => _connectionString = "Server=.;Database=StudentManagement;Trusted_Connection=True;";

        public static DbConnection Instance => _instance.Value;

        public async Task<SqlConnection> GetConnectionAsync()
        {
            lock (_lock)
            {
                if (_connection == null)
                {
                    _connection = new SqlConnection(_connectionString);
                }

                if (_connection.State == ConnectionState.Closed ||
                    _connection.State == ConnectionState.Broken)
                {
                    _connection.Open();
                }
                return _connection;
            }
        }

        public async Task<SqlCommand> GetCommandAsync(string commandText, CommandType commandType)
        {
            var connection = await GetConnectionAsync();
            var command = new SqlCommand(commandText, connection)
            {
                CommandType = commandType
            };
            return command;
        }

        public async Task<DataTable> ExecuteAsync(SqlCommand command)
        {
            using (var reader = await command.ExecuteReaderAsync())
            {
                var dataTable = new DataTable();
                dataTable.Load(reader);
                return dataTable;
            }
        }
        public async Task<DataSet> ExecuteAsyncDataSet(SqlCommand command)
        {
            var dataSet = new DataSet();

            using (var reader = await command.ExecuteReaderAsync())
            {
                do
                {
                    var dataTable = new DataTable();
                    dataTable.Load(reader);
                    dataSet.Tables.Add(dataTable);
                } while (await reader.NextResultAsync());
            }

            return dataSet;
        }
       
        public void CloseConnection()
        {
            if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
        }
    }
}
