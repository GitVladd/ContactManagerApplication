using ContactManagerApplication.DTOs;

namespace ContactManagerApplication.Services
{
    public class ContactService : IContactService
    {
        public Task<ContactGetDto> Add(ContactCreateDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ContactGetDto>> AddRange(IEnumerable<ContactCreateDto> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ContactGetDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ContactGetDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ContactGetDto> UpdateAsync(Guid id, ContactUpdateDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
