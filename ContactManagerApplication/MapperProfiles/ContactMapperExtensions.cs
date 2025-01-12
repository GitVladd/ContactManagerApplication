using ContactManagerApplication.DTOs;
using ContactManagerApplication.Models;

namespace ContactManagerApplication.MapperProfiles
{
    public static class ContactMapperExtensions
    {
        public static Contact ToContact(this ContactCreateDto dto)
        {
            return new Contact
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                DateOfBirth = dto.DateOfBirth,
                Married = dto.Married,
                Phone = dto.Phone,
                Salary = dto.Salary
            };
        }

        public static ContactGetDto ToContactGetDto(this Contact contact)
        {
            return new ContactGetDto
            {
                Id = contact.Id,
                Name = contact.Name,
                DateOfBirth = contact.DateOfBirth,
                Married = contact.Married,
                Phone = contact.Phone,
                Salary = contact.Salary
            };
        }

        public static Contact ToContact(this ContactGetDto dto)
        {
            return new Contact
            {
                Id = dto.Id,
                Name = dto.Name,
                DateOfBirth = dto.DateOfBirth,
                Married = dto.Married,
                Phone = dto.Phone,
                Salary = dto.Salary
            };
        }
    }
}
