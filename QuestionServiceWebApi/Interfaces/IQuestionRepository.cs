using System.Collections.Generic;

namespace QuestionServiceWebApi.Interfaces
{
    public interface IQuestionRepository
    {
        Questionnaire GetQuestionnaire();

        int MarkAnswers(IList<string> answers);
    }
}