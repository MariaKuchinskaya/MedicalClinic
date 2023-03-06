using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using MedicalClinic.BusinessLayer.Helpers.ReportGenerator.Interfaces;

namespace MedicalClinic.BusinessLayer.Helpers.ReportGenerator;

public class CsvHelper : ITranslator
{
    private Stream GenerateStreamFromString(string s)
    {
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        writer.Write(s);
        writer.Flush();
        stream.Position = 0;
        return stream;
    }

    private string GetCsvString<T>(List<T> objects)
    {
        using (var writer = new StringWriter())
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                HeaderValidated = null,
                MissingFieldFound = null,
                IgnoreBlankLines = true
            };

            using (var csv = new CsvWriter(writer, config))
            {
                csv.WriteRecords(objects);
            }

            return writer.ToString();
        }
    }

    public async Task<Stream> GetReport<T>(List<T> objects)
    {

        var csvString = GetCsvString(objects);

        var stream = GenerateStreamFromString(csvString);

        return stream;

    }
}
