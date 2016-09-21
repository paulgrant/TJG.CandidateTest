using System.Web.Mvc;
using PairingTest.Web.Logic;
using PairingTest.Web.Models;

namespace PairingTest.Web.Controllers
{
    public class QuestionnaireController : Controller
    {
          /* ASYNC ACTION METHOD... IF REQUIRED... */
//        public async Task<ViewResult> Index()
//        {
//        }
        private readonly Logic.QuestionService _questionService;

        public QuestionnaireController()
        {
            _questionService = new Logic.QuestionService();
        }

        public QuestionnaireController(Logic.IQuestionService questionService)
        {
            _questionService = new QuestionService();
        }

        public ViewResult Index()
        {
            QuestionnaireViewModel questionnaireVM = _questionService.GetQuestionnaire();

            //PG error checking here - capture in a try catch or have a public property against questionService

            return View(questionnaireVM);
        }
    }
}
