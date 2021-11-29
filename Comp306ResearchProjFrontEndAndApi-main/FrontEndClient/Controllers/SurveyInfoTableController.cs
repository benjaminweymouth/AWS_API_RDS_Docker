using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using APItry1FRONTEND.Models;

namespace APItry1FRONTEND.Controllers
{
    public class SurveyInfoTableController : Controller
    {
        HttpClient client;
        string baseUrl;
        string apiKey;

        public SurveyInfoTableController()
        {
            client = new HttpClient();
            baseUrl = "http://webapiclientelasticbean-dev.us-east-1.elasticbeanstalk.com/api/SurveyInfoTables/";
            // apiKey = "";
        }

        [HttpGet]
        public async Task<IActionResult> ListOfSurveys()
        {
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // client.DefaultRequestHeaders.Add("apikey", apiKey);
            IEnumerable<SurveyInfoTable> SurveyInfoTableList = new List<SurveyInfoTable>();

            HttpResponseMessage response = await client.GetAsync(baseUrl);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                SurveyInfoTableList = JsonConvert.DeserializeObject<IEnumerable<SurveyInfoTable>>(json);
            }

            return View(SurveyInfoTableList);
        }

        [HttpPost]
        public async Task<IActionResult> AddSurveyInfo(SurveyInfoTable surveyInfo)
        {
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var json = JsonConvert.SerializeObject(surveyInfo);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(baseUrl, content);
            response.EnsureSuccessStatusCode();

            //client.DefaultRequestHeaders.Add("apikey", apiKey);

            return RedirectToAction("ListOfSurveys");
        }

        public async Task<SurveyInfoTable> GetSurveyById(string surveyId)
        {
            var newUrl = baseUrl + $"{surveyId}?surveyId={surveyId}";
            client.BaseAddress = new Uri(newUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // client.DefaultRequestHeaders.Add("apikey", apiKey);
            SurveyInfoTable survey = null;

            HttpResponseMessage response = await client.GetAsync(newUrl);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                // convert json to joboffers object
                survey = JsonConvert.DeserializeObject<SurveyInfoTable>(json);
            }
            return survey;
        }

        [HttpGet]
        public async Task<IActionResult> EditSurvey(string surveyId)
        {
            var survey = await GetSurveyById(surveyId);
            return View("EditSurvey", survey);
        }

        [HttpGet]
        public async Task<IActionResult> ViewSurveyDetails(string surveyId)
        {
            var survey = await GetSurveyById(surveyId);
            return View("SurveyDetail", survey);
        }

        [HttpGet]
        public async Task<IActionResult> AddSurvey()
        {
            return View("AddSurvey");
        }

        [HttpPost]
        public async Task<IActionResult> EditSurvey(SurveyInfoTable survey)
        {

            var newUrl = $"{survey.surveyId}?surveyId={survey.surveyId}";

            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            survey.surveyInfoList = new string[0];
            var json = JsonConvert.SerializeObject(survey);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync(newUrl, content);
            response.EnsureSuccessStatusCode();

            //client.DefaultRequestHeaders.Add("apikey", apiKey);

            return RedirectToAction("ListOfSurveys");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteSurvey(string surveyId)
        {
            var newUrl = baseUrl + $"{surveyId}?surveyId={surveyId}";
            client.BaseAddress = new Uri(newUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // client.DefaultRequestHeaders.Add("apikey", apiKey);

            HttpResponseMessage response = await client.DeleteAsync(newUrl);
            response.EnsureSuccessStatusCode();

            return RedirectToAction("ListOfSurveys");
        }

        [HttpPost]
        public async Task<IActionResult> AddSurvey(SurveyInfoTable survey)
        {

            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            survey.surveyInfoList = new string[0];
            var json = JsonConvert.SerializeObject(survey);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(baseUrl, content);
            response.EnsureSuccessStatusCode();

            //client.DefaultRequestHeaders.Add("apikey", apiKey);

            return RedirectToAction("ListOfSurveys");
        }
    }
}
