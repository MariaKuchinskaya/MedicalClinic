using MedicalClinic.BusinessLayer.Helpers.ReportGenerator.Interfaces;

namespace MedicalClinic.BusinessLayer.Helpers.ReportGenerator
{
    public class PdfHelper : ITranslator

    {
        public Task<Stream> GetReport<T>(List<T> objects)
        {
            throw new NotImplementedException();
        }
    }
}
