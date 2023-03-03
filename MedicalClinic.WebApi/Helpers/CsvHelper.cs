using MedicalClinic.BusinessLayer.Dtos.Csv;
using System.Text;

namespace MedicalClinic.WebApi.Helpers
{
    public static class CsvHelper
    {
        public static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public static string GenerateCsvFromObjectList<T>(List<T> data)
        {
            StringBuilder sb = new StringBuilder();
            Type objType = typeof(T);

            foreach (var item in data)
            {
                var properties = objType.GetProperties();
                for (int i = 0; i < properties.Length; i++)
                {
                    if (i == properties.Length - 1)
                    {
                        var propertyValue = properties[i].GetValue(item, null);

                        sb.Append($"{propertyValue}\r\n");
                    }

                    else
                    {
                        var propertyValue = properties[i].GetValue(item, null);

                        sb.Append($"{propertyValue},");
                    }
                }
            }
            return sb.ToString();
        }
    }

}