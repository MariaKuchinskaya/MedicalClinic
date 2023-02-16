using MedicalClinic.BusinessLayer.Dtos;
using MedicalClinic.BusinessLayer.Entities;

namespace MedicalClinic.Domain.Entities
{
    public class AnalyzeResultDto
    {
        public AnalyzeResultDto(AnalyzeResult analyzeResult) 
        { 
          this.Result = analyzeResult.Result;  
          this.Id = analyzeResult.Id;
          this.Analyze = new AnalyzeDto(analyzeResult.Analyze);
          this.TimeStamp = analyzeResult.TimeStamp;   
        }   

        public int Id { get; set; }
        public string Result { get; set; }
        public AnalyzeDto Analyze { get; set; }
        public PatientDto Patient { get; }
        public DateTime TimeStamp { get; set; }

    }
}
