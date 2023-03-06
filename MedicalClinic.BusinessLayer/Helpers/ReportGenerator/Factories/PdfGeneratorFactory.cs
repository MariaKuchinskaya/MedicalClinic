using MedicalClinic.BusinessLayer.Helpers.ReportGenerator.Interfaces;

namespace MedicalClinic.BusinessLayer.Helpers.ReportGenerator.Factories
{
    public class PdfGeneratorFactory: ExportDataGeneratorFactory
    {
        public override ITranslator CreateGenerator()
        {
            return new PdfHelper();
        }
    }
}
