using ContactManagerApplication.DTOs;

namespace ContactManagerApplication.Processor
{
    public interface IFileProcessor
    {
        void ValidateFile(IFormFile file);
        IEnumerable<ContactCreateDto> ReadFile(IFormFile file);
    }
}
