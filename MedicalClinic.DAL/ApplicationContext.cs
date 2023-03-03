using MedicalClinic.Common.Enums;
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

            modelBuilder.Entity<User>().HasData(
                    new User
                    {
                        Id = 1,
                        Email = "mary11@gmail.com",
                        PasswordHash = "443c4ae87a0c358f1b2ee93692938444",
                        UserType = UserType.Patient
                    },

                   new User
                   {
                       Id = 2,
                       Email = "kate@gmail.com",
                       PasswordHash = "115067039670abb4571a74e8e8585e5d",
                       UserType = UserType.Patient
                   },

                  new User
                  {
                      Id = 3,
                      Email = "lena@gmail.com",
                      PasswordHash = "20398ce448540c947edc4c30399e2ced",
                      UserType = UserType.Doctor
                  }


                );

            modelBuilder.Entity<Patient>().HasData(
                new Patient
                {
                    Id = 1,
                    Name = "Kate",
                    Surname = "Pavlova",
                    Email = "kate@gmail.com",
                    PhoneNumber = "666",
                    UserId = 2

                },

                new Patient()
                {
                    Id = 2,
                    Name = "Mary",
                    Surname = "Pavlova",
                    Email = "mary11@gmail.com",
                    PhoneNumber = "555",
                    UserId = 1
                }


            );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = 1,
                    Name = "Lena",
                    Surname = "Petrova",
                    Email = "lena@gmail.com",
                    PhoneNumber = "999",
                    UserId = 3,
                    SpecialityId = 1

                }



            );

            modelBuilder.Entity<Speciality>().HasData(
                new Speciality
                {
                    Id = 1,
                    Name = "Cordiology"

                }



            );
            modelBuilder.Entity<Analyze>().HasData(
                new Analyze
                {
                    Id = 1,
                    Name = "Blood"

                }



            );

            modelBuilder.Entity<AnalyzeResult>().HasData(
                new AnalyzeResult
                {
                    Id = 1,
                    Result = "Bad",
                    AnalyzeId = 1,
                    PatientId = 2,
                    TimeStamp = DateTime.Now

                }
            );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 1,
                    DoctorId = 1,
                    PatientId = 2,
                    Results = "Bad",
                    TimeStamp = DateTime.Now

                }
            );






        }

    }
}
