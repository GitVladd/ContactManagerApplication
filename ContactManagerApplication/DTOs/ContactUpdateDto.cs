namespace ContactManagerApplication.DTOs
{
    public class ContactUpdateDto
    {
        public string Name { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public bool Married { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }
    }
}
