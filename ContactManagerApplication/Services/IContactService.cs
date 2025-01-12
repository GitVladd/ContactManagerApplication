using ContactManagerApplication.DTOs;
using ContactManagerApplication.Models;

namespace ContactManagerApplication.Services
{
    public interface IContactService
    {
        Task<IEnumerable<ContactGetDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<ContactGetDto> GetByIdAsync(Guid id);
        Task<IEnumerable<ContactGetDto>> AddRange(IEnumerable<ContactCreateDto> entities);
        Task<ContactGetDto> Add(ContactCreateDto entity);
        Task<ContactGetDto> UpdateAsync(Guid id, ContactUpdateDto entity);
        Task DeleteByIdAsync(Guid id);
    }
}
