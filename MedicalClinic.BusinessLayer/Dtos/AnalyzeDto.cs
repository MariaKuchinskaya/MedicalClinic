namespace MedicalClinic.Domain.Entities
{
    public class AnalyzeDto
    {
        public AnalyzeDto(Analyze analyze) 
        { 
          this.Id = analyze.Id;
          this.Name = analyze.Name;   

        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
