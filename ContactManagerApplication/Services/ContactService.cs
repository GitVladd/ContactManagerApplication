using ContactManagerApplication.DTOs;
using ContactManagerApplication.Exceptions;
using ContactManagerApplication.MapperProfiles;
using ContactManagerApplication.Models;
using ContactManagerApplication.Repository.Concrete;

namespace ContactManagerApplication.Services
{
    public class ContactService(IContactRepository _contactRepository) : IContactService
    {
        public async Task<IEnumerable<ContactGetDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return (await _contactRepository.GetAllAsync(cancellationToken)).Select(c => c.ToContactGetDto());
        }
        public async Task<ContactGetDto> GetByIdAsync(Guid id)
        {
            return (await _contactRepository.GetByIdAsync(id))?.ToContactGetDto();
        }
        public async Task<ContactGetDto> AddAsync(ContactCreateDto dto)
        {
            Contact newEntity = dto.ToContact();

            _contactRepository.Add(newEntity);
            await _contactRepository.SaveChangesAsync();

            return newEntity.ToContactGetDto();
        }
        public async Task<IEnumerable<ContactGetDto>> AddRangeAsync(IEnumerable<ContactCreateDto> dtos)
        {
            IEnumerable<Contact> newEntities = dtos.Select(e => e.ToContact());

            _contactRepository.AddRange(newEntities);
            await _contactRepository.SaveChangesAsync();

            return newEntities.Select(e => e.ToContactGetDto());
        }
        public async Task<ContactGetDto> UpdateAsync(Guid id, ContactUpdateDto dto)
        {
            var entity = await _contactRepository.GetByIdAsync(id);
            if(entity == null)
                throw new EntityNotFoundException($"Contact with ID '{id}' was not found.");

            entity.Name = dto.Name;
            entity.DateOfBirth = dto.DateOfBirth;
            entity.Married = dto.Married;
            entity.Phone = dto.Phone;
            entity.Salary = dto.Salary;

            _contactRepository.Update(entity);
            await _contactRepository.SaveChangesAsync();

            return entity.ToContactGetDto();
        }
        public async Task DeleteByIdAsync(Guid id)
        {
            var entity = await _contactRepository.GetByIdAsync(id);
            if (entity == null)
                throw new EntityNotFoundException($"Contact with ID '{id}' was not found.");

            _contactRepository.Delete(entity);
            await _contactRepository.SaveChangesAsync();
            
        }
    }
}
