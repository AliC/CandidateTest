using System.Collections.Generic;
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
        public void ShouldGetQuestions()
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
                QuestionsText = new List<string>
                {
                    expectedQuestion1Text,
                    expectedQuestion2Text,
                    expectedQuestion3Text,
                    expectedQuestion4Text
                }
            };

            IQuestionService questionService = Mock.Of<IQuestionService>();
            Mock.Get(questionService).Setup(s => s.Get()).Returns(expectedQuestions);

            QuestionnaireController questionnaireController = new QuestionnaireController(questionService);


            //Act

            ActionResult actionResult = questionnaireController.Index();


            //Assert
            
            Assert.IsInstanceOf<ViewResult>(actionResult);
            Assert.IsNotNull((actionResult as ViewResult).ViewData.Model);
            Assert.IsInstanceOf<QuestionnaireViewModel>((actionResult as ViewResult).ViewData.Model);

            QuestionnaireViewModel model = (actionResult as ViewResult).ViewData.Model as QuestionnaireViewModel;
            Assert.That(model.QuestionnaireTitle, Is.EqualTo(expectedTitle));
            Assert.That(model.QuestionsText.Count, Is.EqualTo(expectedQuestions.QuestionsText.Count));

            Assert.That(model.QuestionsText[0], Is.EqualTo(expectedQuestion1Text));
            Assert.That(model.QuestionsText[1], Is.EqualTo(expectedQuestion2Text));
            Assert.That(model.QuestionsText[2], Is.EqualTo(expectedQuestion3Text));
            Assert.That(model.QuestionsText[3], Is.EqualTo(expectedQuestion4Text));
            
        }
    }
}