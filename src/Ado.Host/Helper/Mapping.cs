/// <summary>
/// Mapping helper class implementation
/// </summary>

namespace Ado.Host.Helper
{
    #region import namespaces

    using Ado.DataAccess.Entities;
    using Ado.Host.Models;

    #endregion

    public static class Mapping
    {

        public static Customer ModelToEntity(CustomerModel source)
        {
            Customer destination = new Customer();
            destination.Id = source.Id;
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.BirthDate = source.BirthDate;
            destination.Mobile = source.Mobile;
            destination.Email = source.Email;

            return destination;
        }

        public static CustomerModel EntityToModel(Customer source)
        {
            CustomerModel destination = new CustomerModel();
            destination.Id = source.Id;
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.BirthDate = source.BirthDate;
            destination.Mobile = source.Mobile;
            destination.Email = source.Email;

            return destination;
        }
    }
}