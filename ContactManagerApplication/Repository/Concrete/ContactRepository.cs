using ContactManagerApplication.Data;
using ContactManagerApplication.Models;

namespace ContactManagerApplication.Repository.Concrete
{
    public sealed class ContactRepository : BaseRepository<Contact, Guid>, IContactRepository
    {
        public ContactRepository(ContactDbContext dbContext) : base(dbContext)
        {
        }
    }
}
