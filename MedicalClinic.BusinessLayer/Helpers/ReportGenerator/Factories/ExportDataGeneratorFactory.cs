using MedicalClinic.BusinessLayer.Helpers.ReportGenerator.Interfaces;

namespace MedicalClinic.BusinessLayer.Helpers.ReportGenerator.Factories
{
    public abstract class ExportDataGeneratorFactory
    {
        public abstract ITranslator CreateGenerator();
    }
}
