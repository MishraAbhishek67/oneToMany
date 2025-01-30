

using System.ComponentModel.DataAnnotations;

namespace ApiCrudoperation.Model.Entity
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public  string  street_address { get; set; }
        public  string city { get; set; }
        public  string state { get; set; }
        public string zip_code { get; set; }
        public  string country { get; set; }
        //public ICollection<Employee> employees { get; set; }
    }
}
