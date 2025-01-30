
namespace ApiCrudoperation.Model
{
    public class AddEmployeeDTO
    {
        public required string name { get; set; }
        public required string Email { get; set; }
        public string? phone { get; set; }
        public decimal salary { get; set; }
        public string? street_address { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }

        public string zip_code {  get; set; }
        public string? country { get; set; }

    }
}
