using EfWebTutorial.Interfaces;
using MedicalClinic.DAL.Entities;
using MedicalClinic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.DAL.Repositories
{
    public class SpecialityRepository: IRepository<Speciality>
    {
        private readonly ApplicationContext _db;

        public SpecialityRepository(ApplicationContext db)
        {
            _db = db;
        }
        public async Task<Speciality> CreateAsync(Speciality item)
        {
            _db.Specialities.Add(item);
            _db.SaveChanges();
            return item;
        }

        public async Task DeleteAsync(int id)
        {
            var speciality = await _db.Specialities.FirstOrDefaultAsync(p => p.Id == id);
            if (speciality != null)
            {
                _db.Specialities.Remove(speciality);
                await _db.SaveChangesAsync();
            }
        }



        public async Task<List<Speciality>> GetAllItemsAsync()
        {
            return await _db.Specialities.ToListAsync();
        }


        public async Task<Speciality> GetItemAsync(int id)
        {
            return await _db.Specialities.FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<Speciality> EditAsync(Speciality speciality)
        {
            var dbSpeciality = await _db.Specialities.FirstOrDefaultAsync(x => x.Id == speciality.Id);
            if (dbSpeciality != null)
            {
                dbSpeciality.Name = speciality.Name;
               
               
                _db.SaveChanges();
            }
            return dbSpeciality;
        }
    }
}
