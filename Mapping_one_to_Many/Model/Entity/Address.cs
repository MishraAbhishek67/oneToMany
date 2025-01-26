using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Mapping_one_to_Many.Model.Entity
{
    public class Address
    {
        public int Id { get; set; }
        public string? Street_address { get; set; }
        public string? City { get; set; } 
        public string? State { get; set; }
        public int? Zip_code { get; set; }
        public string? Country { get; set; }


        public int EmployeeId { get; set; }

        [JsonIgnore]
        public Employee? Employee { get; set; }


    }
}
