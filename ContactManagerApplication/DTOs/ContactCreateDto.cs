using CsvHelper.Configuration.Attributes;

namespace ContactManagerApplication.DTOs
{
    public class ContactCreateDto
    {
        public string Name { get; set; }
        [Name("Date of birth")]
        public DateOnly? DateOfBirth { get; set; }
        public bool Married { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }
    }
}
