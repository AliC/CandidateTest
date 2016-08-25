using System.Web.Mvc;

using PairingTest.Web.Models;
using PairingTest.Web.Services;

namespace PairingTest.Web.Controllers
{
    public class QuestionnaireController : Controller
    {
        private IQuestionService _questionService;

        public QuestionnaireController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        /* ASYNC ACTION METHOD... IF REQUIRED... */
        //        public async Task<ViewResult> Index()
        //        {
        //        }

        //TODO ADC 20160824: probably should be async as suggested by above comment as we'll be retrieving data from an API
        public ActionResult Index()
        {
            QuestionnaireViewModel model = _questionService.Get();

            return View(model);
        }
    }
}
