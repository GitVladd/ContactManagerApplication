using ContactManagerApplication.DTOs;
using CsvHelper;
using CsvHelper.TypeConversion;
using System.Globalization;

namespace ContactManagerApplication.Processor
{
    public class CsvFileProcessor : IFileProcessor
    {
        public void ValidateFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("The uploaded file is null or empty.");
            }

            if (!file.FileName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("The uploaded file must be a CSV file.");
            }
            if (file.ContentType != "text/csv")
            {
                throw new ArgumentException("The uploaded file is not a valid CSV file.");
            }
        }

        public IEnumerable<ContactCreateDto> ReadFile(IFormFile file)
        {
            ValidateFile(file);

            try
            {
                using (var stream = file.OpenReadStream())
                using (var reader = new StreamReader(stream))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<ContactCreateDto>();
                    return records.ToList();
                }
            }
            catch (HeaderValidationException ex)
            {
                throw new ApplicationException($"CSV file header is invalid: {ex.Message}", ex);
            }
            catch (TypeConverterException ex)
            {
                throw new ApplicationException($"CSV file contains invalid data format: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error reading CSV file", ex);
            }
        }

    }
}
