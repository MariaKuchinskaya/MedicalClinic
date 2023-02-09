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
    internal class AnalyzeRepository: IRepository<Analyze>
    {
        private readonly ApplicationContext _db;

        public AnalyzeRepository(ApplicationContext db)
        {
            _db = db;
        }
        public async Task<Analyze> CreateAsync(Analyze item)
        {
            _db.Analyzes.Add(item);
            _db.SaveChanges();
            return item;
        }

        public async Task DeleteAsync(int id)
        {
            var analyze = await _db.Analyzes.FirstOrDefaultAsync(p => p.Id == id);
            if (analyze != null)
            {
                _db.Analyzes.Remove(analyze);
                await _db.SaveChangesAsync();
            }
        }



        public async Task<List<Analyze>> GetAllItemsAsync()
        {
            return await _db.Analyzes.ToListAsync();
        }


        public async Task<Analyze> GetItemAsync(int id)
        {
            return await _db.Analyzes.FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<Analyze> EditAsync(Analyze analyze)
        {
            var dbAnalyze = await _db.Analyzes.FirstOrDefaultAsync(x => x.Id == analyze.Id);
            if (dbAnalyze != null)
            {
                dbAnalyze.Name = analyze.Name;
               
                _db.SaveChanges();
            }
            return dbAnalyze;
        }
    }
}
