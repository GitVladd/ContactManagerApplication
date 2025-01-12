using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ContactManagerApplication.DTOs
{
    public class ContactUpdateDto
    {
        //я закомментировал проверку данных, т.к. в задании не указан формат разрешенных данных, и то, какие из них обязательные


        //[Required(ErrorMessage = "Name is required.")]
        //[StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string? Name { get; set; }

        //[Required(ErrorMessage = "Date of Birth is required.")]
        //[DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        [Name("Date of birth")]
        public DateOnly? DateOfBirth { get; set; }

        //[Required(ErrorMessage = "Marital status is required.")]
        public bool Married { get; set; }

        //[Required(ErrorMessage = "Phone number is required.")]
        //[Phone(ErrorMessage = "Invalid phone number format.")]
        //[StringLength(15, ErrorMessage = "Phone number cannot exceed 15 characters.")]
        public string? Phone { get; set; }

        //[Required(ErrorMessage = "Salary is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Salary must be greater than zero.")]
        public decimal Salary { get; set; }
    }
}
