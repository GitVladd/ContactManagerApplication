﻿using ContactManagerApplication.DTOs;

namespace ContactManagerApplication.Services
{
    public interface IContactService
    {
        Task<IEnumerable<ContactGetDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<ContactGetDto> GetByIdAsync(Guid id);
        Task<IEnumerable<ContactGetDto>> AddRangeAsync(IEnumerable<ContactCreateDto> entities);
        Task<ContactGetDto> AddAsync(ContactCreateDto entity);
        Task<ContactGetDto> UpdateAsync(Guid id, ContactUpdateDto entity);
        Task DeleteByIdAsync(Guid id);
    }
}
