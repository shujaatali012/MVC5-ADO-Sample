/// <summary>
/// Customer repository interface
/// </summary>

namespace Ado.DataAccess.Repositories.Interfaces
{
    #region import namespaces

    using System.Collections.Generic;
    using Entities;

    #endregion

    public interface ICustomerRepository
    {
        string Add(Customer customer);
        string Update(Customer customer);
        string Delete(int id);
        List<Customer> GetAll();
        Customer GetById(int Id);
    }
}
