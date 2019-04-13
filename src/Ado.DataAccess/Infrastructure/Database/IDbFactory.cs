/// <summary>
/// Database factory decleration
/// </summary>

namespace Ado.DataAccess.Infrastructure.Database
{
    #region import namespaces

    using System;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    #endregion

    public interface IDbFactory: IDisposable
    {
        SqlConnection EstablishedConnection(bool multipleActiveResultSets = false);
        Task<SqlConnection> EstablishedConnectionAsync();
    }
}
