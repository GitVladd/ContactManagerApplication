using ContactManagerApplication.Models;
using CsvHelper;
using CsvHelper.TypeConversion;
using System.Globalization;

namespace ContactManagerApplication.Processor
{
    public class CsvFileProcessor : IFileProcessor
    {
        public IEnumerable<Contact> ReadFile(Stream fileStream)
        {
            try
            {
                using (var reader = new StreamReader(fileStream))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<Contact>();
                    return records.ToList();
                }
            }
            catch (HeaderValidationException ex)
            {
                throw new ApplicationException("CSV file header is invalid.", ex);
            }
            catch (TypeConverterException ex)
            {
                throw new ApplicationException("CSV file contains invalid data format.", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error reading CSV file", ex);
            }
        }

    }
}
