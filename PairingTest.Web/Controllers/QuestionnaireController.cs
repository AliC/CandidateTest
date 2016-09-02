using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<ActionResult> Index()
        {
            QuestionnaireViewModel model = await _questionService.Get();

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(QuestionnaireViewModel questionnaire)
        {
            ContentResult result = new ContentResult();

            if (ModelState.IsValid)
            {
                result.Content = string.Join("<br />",
                    questionnaire.QuestionnaireTitle,
                    string.Join(",", questionnaire.Questions.Select(q => q.Answer)),
                    "Thank you. Your answers have been submitted.");

                return result;
            }

            return View(questionnaire);
        }
    }
}
