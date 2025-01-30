namespace ApiCrudoperation.Model
{
    public class UpdateEmployeeDTO
    {
        public  string name { get; set; }
        public string Email { get; set; }
        public string? phone { get; set; }
        public decimal salary { get; set; }



        public string? street_address { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }

        public string zip_code { get; set; }
        public string? country { get; set; }
        //public Guid Id { get; set; }
    }
}
