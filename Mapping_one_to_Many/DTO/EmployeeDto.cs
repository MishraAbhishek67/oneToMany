namespace Mapping_one_to_Many.DTO
{
    public class EmployeeDto
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public int? Phone { get; set; }
        public decimal Salary { get; set; }
        public string? Street_address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int? Zip_code { get; set; }
        public string? Country { get; set; }

    }
}
