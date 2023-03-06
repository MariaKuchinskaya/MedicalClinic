using MedicalClinic.BusinessLayer.Helpers.ReportGenerator.Interfaces;

namespace MedicalClinic.BusinessLayer.Helpers.ReportGenerator.Factories
{
    public class CsvGeneratorFactory: ExportDataGeneratorFactory
    {
        public override ITranslator CreateGenerator()
        {
            return new CsvHelper();
        }
    }
}
