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
    public class UserRepository: IRepository<User>
    {
        private readonly ApplicationContext _db;

        public UserRepository(ApplicationContext db)
        {
            _db = db;
        }
        public async Task<User> CreateAsync(User item)
        {
            _db.Users.Add(item);
            _db.SaveChanges();
            return item;
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _db.Users.FirstOrDefaultAsync(p => p.Id == id);
            if (user != null)
            {
                _db.Users.Remove(user);
                await _db.SaveChangesAsync();
            }
        }



        public async Task<List<User>> GetAllItemsAsync()
        {
            return await _db.Users.ToListAsync();
        }


        public async Task<User> GetItemAsync(int id)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<User> EditAsync(User user)
        {
            var dbUser = await _db.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
            if (dbUser != null)
            {
                dbUser.Email = user.Email;
                dbUser.PasswordHash = user.PasswordHash;
                
                _db.SaveChanges();
            }
            return dbUser;
        }

    }
}
