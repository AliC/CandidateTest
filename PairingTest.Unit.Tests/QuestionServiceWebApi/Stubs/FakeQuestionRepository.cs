using System.Collections.Generic;
using QuestionServiceWebApi;
using QuestionServiceWebApi.Interfaces;

namespace PairingTest.Unit.Tests.QuestionServiceWebApi.Stubs
{
    public class FakeQuestionRepository : IQuestionRepository
    {
        public Questionnaire ExpectedQuestions { get; set; }
        public Questionnaire GetQuestionnaire()
        {
            return ExpectedQuestions;
        }

        public int MarkAnswers(IList<string> answers)
        {
            throw new System.NotImplementedException();
        }
    }
}