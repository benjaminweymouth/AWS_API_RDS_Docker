using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinancialLibary.Models;
using WebAPIClient.Services;
using AutoMapper;
using WebAPIClient.DTOs;

namespace WebAPIClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyInfoTablesController : ControllerBase
    {
        
        private ISurveyInfoTableRepository _SurveyInfoTableRepository;
        private readonly IMapper _mapper;

        public SurveyInfoTablesController(ISurveyInfoTableRepository _surveyInfoTableRepository, IMapper mapper)
        {
            _SurveyInfoTableRepository = _surveyInfoTableRepository;
            _mapper = mapper;
        }

        // GET: api/SurveyInfoTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SurveyInfoTable>>> GetAllSurveyInfo()
        {
            var surveydata = await _SurveyInfoTableRepository.GetAllFinanceSurveyInfo();
            var results = _mapper.Map<IEnumerable<SurveyInfoTableDto>>(surveydata);

            return Ok(results);
        }

        // GET: api/SurveyInfoTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SurveyInfoTable>> GetSurveyInfoTable(String SurveyId)
        {
            var surveyInfoTable = await _SurveyInfoTableRepository.GetFinanceSurveyById(SurveyId);

            if (surveyInfoTable == null)
            {
                return NotFound();
            }

            return surveyInfoTable;
        }

        // PUT: api/SurveyInfoTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSurveyIntoTable(String SurveyId, SurveyInfoTable survey)
        {
            if (SurveyId != survey.SurveyId)
            {
                return BadRequest();
            }

            

            try
            {
                _SurveyInfoTableRepository.EditFinanceSurvey(survey);
                await _SurveyInfoTableRepository.Save();
            }
            catch (Exception)
            {
                if (!SurveyInfoTableExists(SurveyId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SurveyInfoTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SurveyInfoTable>> PostSurveyInfoTable(SurveyInfoTable survey)
        {
            try
            {
                _SurveyInfoTableRepository.AddFinanceSurvey(survey);

                await _SurveyInfoTableRepository.Save();
            }
            catch (Exception)
            {
                if (SurveyInfoTableExists(survey.SurveyId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSurveyInfoTable", new { id = survey.SurveyId }, survey);
        }

        // DELETE: api/SurveyInfoTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurveyInfoTable(String SurveyId)
        {
            var surveyInfoTable = await _SurveyInfoTableRepository.GetFinanceSurveyById(SurveyId);
            if (surveyInfoTable == null)
            {
                return NotFound();
            }

            _SurveyInfoTableRepository.DeleteFinanceSurvey(surveyInfoTable);
            await _SurveyInfoTableRepository.Save();

            return NoContent();
        }

        private bool SurveyInfoTableExists(String SurveyId)
        {
            return _SurveyInfoTableRepository.FinanceSurveyExists(SurveyId);
        }
    }
}
