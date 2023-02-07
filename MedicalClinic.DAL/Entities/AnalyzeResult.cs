using MedicalClinic.Models;

namespace MedicalClinic.DAL.Entities
{
    public class AnalyzeResult
    {
        public int Id { get; set; } 
        public string Result { get; set; }  
        public int? AnalyzeId { get; set; } 
        public virtual Analyze Analyze { get; set; }    
        public int? PatientId { get; set; }
        public virtual Patient Patient { get;}
        public DateTime TimeStamp { get; set; } 

    }
}
