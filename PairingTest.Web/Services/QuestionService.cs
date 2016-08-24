using System;
using PairingTest.Web.Models;

namespace PairingTest.Web.Services
{
    public class QuestionService : IQuestionService
    {
        public QuestionnaireViewModel Get()
        {
            return new QuestionnaireViewModel();
        }
    }
}