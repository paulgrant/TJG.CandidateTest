using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PairingTest.Web.Logic;
using PairingTest.Web.Models;
using QuestionServiceWebApi;

namespace PairingTest.Unit.Tests.Logic.Stubs
{
    public class FakeQuestionService : IQuestionService
    {
        public QuestionnaireViewModel ExpectedQuestions { get; set; }
        public QuestionnaireViewModel GetQuestionnaire()
        {
            return ExpectedQuestions;
        }

        public QuestionnaireViewModel GetQuestionnaireItem(int id)
        {
            return ExpectedQuestions;
        }

    }
}
