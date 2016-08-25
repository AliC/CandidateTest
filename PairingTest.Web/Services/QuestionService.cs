using System.Collections.Generic;
using System.Threading.Tasks;

using Newtonsoft.Json;

using PairingTest.Web.Models;

namespace PairingTest.Web.Services
{
    public class QuestionService : IQuestionService
    {
        private IDataProvider _provider;

        public QuestionService(IDataProvider provider)
        {
            _provider = provider;
        }

        public async Task<QuestionnaireViewModel> Get()
        {
            string json = await _provider.Get();

            Questionnaire model = JsonConvert.DeserializeObject<Questionnaire>(json);

            return Map(model);
        }

        private QuestionnaireViewModel Map(Questionnaire model)
        {
            IList<QuestionnaireViewModel.QuestionViewModel> questions = new List<QuestionnaireViewModel.QuestionViewModel>();

            for (int i = 0; i < model.QuestionsText.Count; i++)
            {
                questions.Add(new QuestionnaireViewModel.QuestionViewModel
                {
                    Question = model.QuestionsText[i]
                });
            }

            return new QuestionnaireViewModel
            {
                QuestionnaireTitle = model.QuestionnaireTitle,
                Questions = questions
            };
        }
    }
}