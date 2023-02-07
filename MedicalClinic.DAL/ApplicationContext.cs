using MedicalClinic.DAL.Entities;
using MedicalClinic.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.DAL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Analyze> Analyzes { get; set; }

        public DbSet<AnalyzeResult> AnalyzesResults { get; set; }

        public DbSet<Speciality> Specialities { get; set; }

        public DbSet<User> Users { get; set; }




        public ApplicationContext(DbContextOptions<ApplicationContext> dbContextOptions) : base(dbContextOptions)
        {

        }
    }
}
