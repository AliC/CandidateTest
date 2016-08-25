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
    }
}
