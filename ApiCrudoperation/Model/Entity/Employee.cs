using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace ApiCrudoperation.Model.Entity
{
    public class Employee
    {
        [Key]
        public Guid id { get; set; }
        public required string name { get; set; }
        public required string Email { get; set; }
        public string? phone { get; set; }
        public decimal salary { get; set; }
        public int AddressId { get; set; } // Foreign key for the navigation property.
        public Address Address { get; set; } // Navigation property.



    }
}
