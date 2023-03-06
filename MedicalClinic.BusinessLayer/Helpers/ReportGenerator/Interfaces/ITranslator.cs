namespace MedicalClinic.BusinessLayer.Helpers.ReportGenerator.Interfaces
{
    public interface ITranslator
    {
        Task<Stream> GetReport<T>(List<T> objects);


    }
}
