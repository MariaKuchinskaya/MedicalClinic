

using EfWebTutorial.Interfaces;
using EfWebTutorial.Models;
using MedicalClinic.Models;
using Microsoft.EntityFrameworkCore;

namespace EfWebTutorial.Repositories
{
    public class PatientRepository : IBaseRepository<Patient>
    {
        private readonly ApplicationContext _db;

        public PatientRepository(ApplicationContext db)
        {
            _db = db;
        }
        public async Task CreateAsync(Patient item)
        {
            _db.Patients.Add(item);
            _db.SaveChanges();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (id != null)
            {
                var patient = await _db.Patients.FirstOrDefaultAsync(p => p.Id == id);
                if (patient != null)
                {
                    _db.Patients.Remove(patient);
                    await _db.SaveChangesAsync();
                    return true;
                }
            }

            return false;
        }

    

        public async Task<List<Patient>> GetAllItemsAsync()
        {
            var res = await _db.Patients.ToListAsync();
                

            return res;
        }

    
        public async Task<Patient> GetOneItemAsync(int id)
        {
            var res = await _db.Patients.FirstOrDefaultAsync(x => x.Id == id);
            return res;
        }


        public async Task EditAsync(Patient patient)
        {
            var dbPatient = await _db.Patients.FirstOrDefaultAsync(x => x.Id == patient.Id);
            if (dbPatient != null)
            {
                dbPatient.Name = patient.Name;
                dbPatient.Surname = patient.Surname;
                dbPatient.PhoneNumber = patient.PhoneNumber;    
                dbPatient.Email = patient.Email;
            }

            _db.SaveChanges();
        }


        public Task<List<Patient>> GetAllItemsSortedAsync()
        {
            throw new NotImplementedException();
        }
    }
}
