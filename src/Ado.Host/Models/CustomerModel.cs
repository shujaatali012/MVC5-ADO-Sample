/// <summary>
/// Customer model
/// </summary>

namespace Ado.Host.Models
{
    #region import namespaces

    using System;
    using System.ComponentModel.DataAnnotations;
    
    #endregion
    
    public class CustomerModel
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Enter Name")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Enter Address")]
        public string Address { get; set; }
        
        [Required(ErrorMessage = "Enter Mobile")]
        public string Mobile { get; set; }
        
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Enter BirthDate")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        
        [Required(ErrorMessage = "Enter Email")]
        public string Email { get; set; }
    }
}