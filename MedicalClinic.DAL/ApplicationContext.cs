using MedicalClinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;

namespace MedicalClinic.DAL
{
    public class ApplicationContext : DbContext
    {
        private string _connectionString { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Analyze> Analyzes { get; set; }

        public DbSet<AnalyzeResult> AnalyzesResults { get; set; }

        public DbSet<Speciality> Specialities { get; set; }

        public DbSet<User> Users { get; set; }




        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            var sqlServerOptionsExtension =
                   options.FindExtension<SqlServerOptionsExtension>();

            if (sqlServerOptionsExtension != null)
            {
                _connectionString = sqlServerOptionsExtension.ConnectionString;
            }

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // использование Fluent API
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<Patient>().HasKey(u => u.Id);
            modelBuilder.Entity<Doctor>().HasKey(u => u.Id);
                                       
            modelBuilder.Entity<Appointment>().HasKey(u => u.Id);
            modelBuilder.Entity<Analyze>().HasKey(u => u.Id);
            modelBuilder.Entity<AnalyzeResult>().HasKey(u => u.Id);
            modelBuilder.Entity<Speciality>().HasKey(u => u.Id);

            modelBuilder.Entity<Doctor>()
                         .HasOne(u => u.Speciality)
                         .WithMany(c => c.Doctors)
                         .HasForeignKey(u => u.SpecialityId);

            modelBuilder.Entity<Doctor>()
                        .HasOne(u => u.User)
                        .WithMany(c => c.Doctors)
                        .HasForeignKey(u => u.UserId);


            modelBuilder.Entity<Patient>()
                        .HasOne(u => u.User)
                        .WithMany(c => c.Patients)
                        .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<Appointment>()
                        .HasOne(u => u.Patient)
                        .WithMany(u => u.Appointments)
                        .HasForeignKey(u => u.PatientId);


            modelBuilder.Entity<Appointment>()
                        .HasOne(u => u.Doctor)
                        .WithMany(u => u.Appointments)
                        .HasForeignKey(u => u.DoctorId);

        }
    }
}
