namespace Mapping_one_to_Many.RTO
{
    public class EmployeeRto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int? Phone { get; set; }
        public decimal Salary { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int? ZipCode { get; set; }
        public string? Country { get; set; }
    }
}
