using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

using Moq;
using NUnit.Framework;

using PairingTest.Web.Controllers;
using PairingTest.Web.Models;
using PairingTest.Web.Services;

namespace PairingTest.Unit.Tests.Web
{
    [TestFixture]
    public class QuestionnaireControllerTests
    {
        [Test]
        public async Task ShouldGetQuestions()
        {
            //Arrange

            string expectedTitle = "My expected questions";
            string expectedQuestion1Text = "Question 1 Text";
            string expectedQuestion2Text = "Question 2 Text";
            string expectedQuestion3Text = "Question 3 Text";
            string expectedQuestion4Text = "Question 4 Text";

            QuestionnaireViewModel expectedQuestions = new QuestionnaireViewModel
            {
                QuestionnaireTitle = expectedTitle,
                Questions = new List<QuestionnaireViewModel.QuestionViewModel>
                {
                    new QuestionnaireViewModel.QuestionViewModel { Question = expectedQuestion1Text },
                    new QuestionnaireViewModel.QuestionViewModel { Question = expectedQuestion2Text },
                    new QuestionnaireViewModel.QuestionViewModel { Question = expectedQuestion3Text },
                    new QuestionnaireViewModel.QuestionViewModel { Question = expectedQuestion4Text }
                }
            };

            IQuestionService questionService = Mock.Of<IQuestionService>();
            Mock.Get(questionService).Setup(s => s.Get()).Returns(Task.FromResult(expectedQuestions));

            QuestionnaireController questionnaireController = new QuestionnaireController(questionService);


            //Act

            ActionResult actionResult = await questionnaireController.Index();


            //Assert
            
            Assert.IsInstanceOf<ViewResult>(actionResult);
            Assert.IsNotNull((actionResult as ViewResult).ViewData.Model);
            Assert.IsInstanceOf<QuestionnaireViewModel>((actionResult as ViewResult).ViewData.Model);

            QuestionnaireViewModel model = (actionResult as ViewResult).ViewData.Model as QuestionnaireViewModel;
            Assert.That(model.QuestionnaireTitle, Is.EqualTo(expectedTitle));
            Assert.That(model.Questions.Count, Is.EqualTo(expectedQuestions.Questions.Count));

            Assert.That(model.Questions[0].Question, Is.EqualTo(expectedQuestion1Text));
            Assert.That(model.Questions[1].Question, Is.EqualTo(expectedQuestion2Text));
            Assert.That(model.Questions[2].Question, Is.EqualTo(expectedQuestion3Text));
            Assert.That(model.Questions[3].Question, Is.EqualTo(expectedQuestion4Text));
            
        }
    }
}