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
    public class AnalyzeResultRepository: IRepository<AnalyzeResult>
    {
        private readonly ApplicationContext _db;

        public AnalyzeResultRepository(ApplicationContext db)
        {
            _db = db;
        }
        public async Task<AnalyzeResult> CreateAsync(AnalyzeResult item)
        {
            _db.AnalyzesResults.Add(item);
            _db.SaveChanges();
            return item;
        }

        public async Task DeleteAsync(int id)
        {
            var analyzeResult = await _db.AnalyzesResults.FirstOrDefaultAsync(p => p.Id == id);
            if (analyzeResult != null)
            {
                _db.AnalyzesResults.Remove(analyzeResult);
                await _db.SaveChangesAsync();
            }
        }



        public async Task<List<AnalyzeResult>> GetAllItemsAsync()
        {
            return await _db.AnalyzesResults.ToListAsync();
        }


        public async Task<AnalyzeResult> GetItemAsync(int id)
        {
            return await _db.AnalyzesResults.FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<AnalyzeResult> EditAsync(AnalyzeResult analyzeResult)
        {
            var dbAnalyzeResult = await _db.AnalyzesResults.FirstOrDefaultAsync(x => x.Id == analyzeResult.Id);
            if (dbAnalyzeResult != null)
            {
                dbAnalyzeResult.Result = analyzeResult.Result;

                _db.SaveChanges();
            }
            return dbAnalyzeResult;
        }
    }
}
