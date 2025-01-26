using System.ComponentModel.DataAnnotations;

namespace Mapping_one_to_Many.Model.Entity
{
    public class Employee
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public int? Phone { get; set; }
        public decimal Salary { get; set; }

        public bool IsDeleted { get; set; } // For soft delete
        public DateTime? DeletedAt { get; set; }


        //public int AddressId { get; set; } // Foreign key for the navigation property.
        public List<Address>? Addresses { get; set; }

    }
}
