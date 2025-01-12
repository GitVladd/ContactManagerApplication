using ContactManagerApplication.Models;

namespace ContactManagerApplication.Processor
{
    public interface IFileProcessor
    {
        IEnumerable<Contact> ReadFile(Stream fileStream);
    }
}
