using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialLibary.Models;

namespace WebAPIClient.Services
{
    public interface ISurveyInfoTableRepository
    {
        bool FinanceSurveyExists(String SurveyId);
        Task<IEnumerable<SurveyInfoTable>> GetAllFinanceSurveyInfo();
        Task<SurveyInfoTable> GetFinanceSurveyById(String SurveyId);
        
        void AddFinanceSurvey(SurveyInfoTable survey);

        void EditFinanceSurvey(SurveyInfoTable survey);
        void DeleteFinanceSurvey(SurveyInfoTable survey);
        Task<bool> Save();
    }
}
