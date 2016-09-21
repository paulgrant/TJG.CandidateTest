using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Configuration;

namespace PairingTest.Web.Logic
{
    //TODO Extract out into Logic project 
    public class QuestionService : IQuestionService
    {
        private const string QuestionnaireServiceUri = "QuestionnaireServiceUri";

        public bool hasErrors;
               
        public Models.QuestionnaireViewModel GetQuestionnaire()
        {
            Models.QuestionnaireViewModel questionnaireVM = GetQuestionnaireItemsFromServce();
            return questionnaireVM;
        }

        public Models.QuestionnaireViewModel GetQuestionnaireItem(int id)
        {
            Models.QuestionnaireViewModel questionnaireVM = GetQuestionnaireItemsFromServce(id);
            return questionnaireVM;
        }

        private static Models.QuestionnaireViewModel GetQuestionnaireItemsFromServce()
        {
            return GetQuestionnaireItemsFromServce(0);
        }

        private static Models.QuestionnaireViewModel GetQuestionnaireItemsFromServce(int itemNo)
        {
            Models.QuestionnaireViewModel questionnaireVM = new Models.QuestionnaireViewModel();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string serviceUrl = ConfigurationManager.AppSettings[QuestionnaireServiceUri];
                if(itemNo >0)
                {
                    serviceUrl += "/" + itemNo.ToString();
                }

                HttpResponseMessage response = client.GetAsync(serviceUrl).Result;
                if (response.IsSuccessStatusCode)
                {
                    questionnaireVM = response.Content.ReadAsAsync<Models.QuestionnaireViewModel>().Result;
                }
                else
                {
                    throw new ApplicationException("Error retrieving questionnaire");
                }
            }

            return questionnaireVM;
        }

        

    }
}
