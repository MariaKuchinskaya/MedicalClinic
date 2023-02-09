using EfWebTutorial.Interfaces;
using MedicalClinic.DAL;
using MedicalClinic.DAL.Entities;
using MedicalClinic.Models;
using Microsoft.EntityFrameworkCore;
using System.Web.Mvc;

namespace EfWebTutorial.Repositories
{
    public class DoctorRepository : IRepository<Doctor>
    {

        private readonly ApplicationContext _db;

        public DoctorRepository(ApplicationContext db)
        {
            _db = db;
        }
        public async Task<Doctor> CreateAsync(Doctor item)
        {
            _db.Doctors.Add(item);
            _db.SaveChanges();
            return item;
        }

        public async Task DeleteAsync(int id)
        {
            var doctor = await _db.Doctors.FirstOrDefaultAsync(p => p.Id == id);
            if (doctor != null)
            {
                _db.Doctors.Remove(doctor);
                await _db.SaveChangesAsync();
            }
        }



        public async Task<List<Doctor>> GetAllItemsAsync()
        {
            return await _db.Doctors.ToListAsync();
        }


        public async Task<Doctor> GetItemAsync(int id)
        {
            return await _db.Doctors.FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<Doctor> EditAsync(Doctor doctor)
        {
            var dbDoctor = await _db.Doctors.FirstOrDefaultAsync(x => x.Id == doctor.Id);
            if (dbDoctor != null)
            {
                dbDoctor.Name = doctor.Name;
                dbDoctor.Surname = doctor.Surname;
                dbDoctor.PhoneNumber = doctor.PhoneNumber;
                dbDoctor.Email = doctor.Email;
                _db.SaveChanges();
            }
            return dbDoctor;
        }

    }
}
