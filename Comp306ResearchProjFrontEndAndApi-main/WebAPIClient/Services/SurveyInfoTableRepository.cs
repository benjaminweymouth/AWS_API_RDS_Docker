using FinancialLibary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIClient.Services
{
    public class SurveyInfoTableRepository : ISurveyInfoTableRepository
    {
        private comp306FinancialDBContext _context;
        public SurveyInfoTableRepository(comp306FinancialDBContext context)
        {
            _context = context;
        }
        public bool FinanceSurveyExists(string SurveyId)
        {
            return _context.SurveyInfoList.Any<SurveyInfoTable>(c => c.SurveyId == SurveyId);
        }

        public async Task<IEnumerable<SurveyInfoTable>> GetAllFinanceSurveyInfo()
        {
             var result = _context.SurveyInfoList.OrderBy(c => c.SurveyId);
            
            return await result.ToListAsync();
        }

        public async Task<SurveyInfoTable> GetFinanceSurveyById(String SurveyId)
        {
            IQueryable<SurveyInfoTable> result;

            result = _context.SurveyInfoList.Where(p => p.SurveyId == SurveyId);

            return await result.FirstOrDefaultAsync();
        }

        public void AddFinanceSurvey(SurveyInfoTable survey)
        {

            _context.SurveyInfoList.Add(survey);

        }

        public void EditFinanceSurvey(SurveyInfoTable survey)
        {

            _context.SurveyInfoList.Update(survey);

        }

        public void DeleteFinanceSurvey(SurveyInfoTable survey)
        {

            _context.SurveyInfoList.Remove(survey);
        }

        public async Task<bool> Save()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }



    }
}
