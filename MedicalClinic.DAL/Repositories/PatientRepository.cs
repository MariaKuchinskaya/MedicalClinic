using EfWebTutorial.Interfaces;
using MedicalClinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.DAL.Repositories
{
    public class PatientRepository : IRepository<Patient>
    {
        private readonly ApplicationContext _db;

        public PatientRepository(ApplicationContext db)
        {
            _db = db;
        }
        public async Task <Patient> CreateAsync(Patient item)
        {
            _db.Patients.Add(item);
            _db.SaveChanges();
            return item;    
        }

        public async Task DeleteAsync(int id)
        {
            var patient = await _db.Patients.FirstOrDefaultAsync(p => p.Id == id);
            if (patient != null)
            {
                _db.Patients.Remove(patient);
                await _db.SaveChangesAsync();    
            } 
        }

    

        public async Task<List<Patient>> GetAllItemsAsync()
        {
            return await _db.Patients.ToListAsync();
        }

    
        public async Task<Patient> GetItemAsync(int id)
        {
            return await _db.Patients.FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<Patient> EditAsync(Patient patient)
        {
            var dbPatient = await _db.Patients.FirstOrDefaultAsync(x => x.Id == patient.Id);
            if (dbPatient != null)
            {
                dbPatient.Name = patient.Name;
                dbPatient.Surname = patient.Surname;
                dbPatient.PhoneNumber = patient.PhoneNumber;    
                dbPatient.Email = patient.Email;
                _db.SaveChanges();
            }
            return dbPatient;
        }
    }
}
