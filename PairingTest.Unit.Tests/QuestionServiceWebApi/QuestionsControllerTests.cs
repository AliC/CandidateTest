using NUnit.Framework;
using PairingTest.Unit.Tests.QuestionServiceWebApi.Stubs;
using QuestionServiceWebApi;
using QuestionServiceWebApi.Controllers;

namespace PairingTest.Unit.Tests.QuestionServiceWebApi
{
    [TestFixture]
    public class QuestionsControllerTests
    {
        [Test]
        public void ShouldGetQuestions()
        {
            //Arrange
            string expectedTitle = "My expected questions";
            Questionnaire expectedQuestions = new Questionnaire() { QuestionnaireTitle = expectedTitle };
            FakeQuestionRepository fakeQuestionRepository = new FakeQuestionRepository() { ExpectedQuestions = expectedQuestions };
            QuestionsController questionsController = new QuestionsController(fakeQuestionRepository);

            //Act
            Questionnaire questions = questionsController.Get();

            //Assert
            Assert.That(questions.QuestionnaireTitle, Is.EqualTo(expectedTitle));
        }
    }
}