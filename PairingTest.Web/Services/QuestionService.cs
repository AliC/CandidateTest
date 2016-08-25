using System;
using System.Collections.Generic;
using PairingTest.Web.Models;

namespace PairingTest.Web.Services
{
    public class QuestionService : IQuestionService
    {
        public QuestionnaireViewModel Get()
        {
            string expectedTitle = "My expected questions";
            string expectedQuestion1Text = "Question 1 Text";
            string expectedQuestion2Text = "Question 2 Text";
            string expectedQuestion3Text = "Question 3 Text";
            string expectedQuestion4Text = "Question 4 Text";

            return new QuestionnaireViewModel
            {
                QuestionnaireTitle = expectedTitle,
                Questions = new List<QuestionnaireViewModel.QuestionViewModel>
                {
                    new QuestionnaireViewModel.QuestionViewModel { Question = expectedQuestion1Text },
                    new QuestionnaireViewModel.QuestionViewModel { Question = expectedQuestion2Text },
                    new QuestionnaireViewModel.QuestionViewModel { Question = expectedQuestion3Text },
                    new QuestionnaireViewModel.QuestionViewModel { Question = expectedQuestion4Text }                }
            };
        }
    }
}