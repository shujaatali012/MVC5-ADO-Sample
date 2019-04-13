/// <summary>
/// Database factory implementation
/// </summary>

namespace Ado.DataAccess.Infrastructure.Database
{
    #region import namespaces

    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    #endregion

    public class DbFactory : IDbFactory, IDisposable
    {
        #region private members

        private readonly string _connectionString;
        private SqlConnection _connection { get; set; }

        #endregion

        #region constructor(s)

        public DbFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        #endregion

        #region IDbFactory implementation

        public SqlConnection EstablishedConnection(bool multipleActiveResultSets = false)
        {
            try
            {
                if (string.IsNullOrEmpty(value: this._connectionString))
                {
                    throw new ArgumentNullException(paramName: nameof(this._connectionString), message: "Connection expects constructor injection for connectionString param.");
                }

                _connection = new SqlConnection(connectionString: _connectionString);

                if (_connection.State == ConnectionState.Closed) _connection.Open();

                return _connection;
            }
            catch (TimeoutException ex)
            {
                Console.WriteLine("Could not open database connection", ex);
                throw new TimeoutException(message: "Timeout Exception", innerException: ex);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Could not open database connection", ex);
                throw new Exception(message: "Sql Exception", innerException: ex);
            }
        }

        public async Task<SqlConnection> EstablishedConnectionAsync()
        {
            try
            {
                if (string.IsNullOrEmpty(value: _connectionString))
                {
                    throw new ArgumentNullException(paramName: nameof(_connectionString), message: "Connection expects constructor injection for connectionString param.");
                }

                _connection = new SqlConnection(connectionString: _connectionString);

                await _connection.OpenAsync().ConfigureAwait(false);

                return _connection;
            }
            catch (TimeoutException ex)
            {
                Console.WriteLine("Could not open database connection async", ex);
                throw new TimeoutException(message: "Timeout Exception", innerException: ex);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Could not open database connection async", ex);
                throw new Exception(message: "Sql Exception", innerException: ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not open database connection async", ex);
                throw new Exception(message: "Sql Exception", innerException: ex);
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(obj: this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

            try
            {
                if (_connection == null)
                {
                    return;
                }

                if (!_connection.State.HasFlag(flag: ConnectionState.Open))
                {
                    return;
                }

                _connection.Close();
                _connection?.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not Dispose database connection", ex);
                throw;
            }
        }

        #endregion
    }
}
