using System.Collections.Generic;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json;
using NUnit.Framework;

using PairingTest.Web.Models;
using PairingTest.Web.Providers;
using PairingTest.Web.Services;

namespace PairingTest.Unit.Tests.Web
{
    [TestFixture]
    public class QuestionServiceTests
    {
        [Test]
        public async Task ShouldGetQuestions()
        {
            string expectedTitle = "My expected questions";
            string expectedQuestion1Text = "Question 1 Text";
            string expectedQuestion2Text = "Question 2 Text";
            string expectedQuestion3Text = "Question 3 Text";
            string expectedQuestion4Text = "Question 4 Text";

            Questionnaire questionnaireViewModel = new Questionnaire
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

            string serializedModel = JsonConvert.SerializeObject(questionnaireViewModel);

            IDataProvider provider = Mock.Of<IDataProvider>();
            Mock.Get(provider).Setup(p => p.Get()).Returns(Task.FromResult(serializedModel));

            IQuestionService service = new QuestionService(provider);
            QuestionnaireViewModel actualModel = await service.Get();

            Assert.IsNotNull(actualModel);
        }
    }
}
