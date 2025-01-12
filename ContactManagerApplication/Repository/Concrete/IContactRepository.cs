using ContactManagerApplication.Models;

namespace ContactManagerApplication.Repository.Concrete
{
    public interface IContactRepository : IBaseRepository<Contact, Guid>
    {
    }
}
