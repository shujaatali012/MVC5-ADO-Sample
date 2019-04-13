/// <summary>
/// Customer repository interface
/// </summary>

namespace Ado.DataAccess.Entities
{
    #region import namespaces

    using System;

    #endregion

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
    }
}
