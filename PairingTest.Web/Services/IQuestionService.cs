using System.Collections.Generic;
using System.Threading.Tasks;
using PairingTest.Web.Models;

namespace PairingTest.Web.Services
{
    public interface IQuestionService
    {
        Task<QuestionnaireViewModel> Get();

        Task<int> MarkAnswers(IEnumerable<string> answers);
    }
}