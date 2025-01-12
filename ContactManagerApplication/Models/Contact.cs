using System.ComponentModel.DataAnnotations;

namespace ContactManagerApplication.Models
{
    public class Contact : IEntity<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public bool Married { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }
    }
}
