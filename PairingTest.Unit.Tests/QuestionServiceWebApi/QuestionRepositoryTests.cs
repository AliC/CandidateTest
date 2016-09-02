using System.Collections.Generic;
using NUnit.Framework;
using QuestionServiceWebApi;
using QuestionServiceWebApi.Interfaces;

namespace PairingTest.Unit.Tests.QuestionServiceWebApi
{
    [TestFixture]
    public class QuestionRepositoryTests
    {
        [Test]
        public void ShouldGetExpectedQuestionnaire()
        {
            var questionRepository = new QuestionRepository();

            var questionnaire = questionRepository.GetQuestionnaire();

            Assert.That(questionnaire.QuestionnaireTitle, Is.EqualTo("Geography Questions"));
            Assert.That(questionnaire.QuestionsText[0], Is.EqualTo("What is the capital of Cuba?"));
            Assert.That(questionnaire.QuestionsText[1], Is.EqualTo("What is the capital of France?"));
            Assert.That(questionnaire.QuestionsText[2], Is.EqualTo("What is the capital of Poland?"));
            Assert.That(questionnaire.QuestionsText[3], Is.EqualTo("What is the capital of Germany?"));
        }

        [Test]
        public void Should_Return_Zero_Percent()
        {
            IList<string> answers = new List<string>
            {
                { "Cuba" },
                { "France" },
                { "Poland" },
                { "Germany" }
            };

            int expectedResult = 0;

            IQuestionRepository questionRepository = new QuestionRepository();
            int actualResult = questionRepository.MarkAnswers(answers);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Should_Return_TwentyFive_Percent()
        {
            IList<string> answers = new List<string>
            {
                { "Havana" },
                { "France" },
                { "Poland" },
                { "Germany" }
            };

            int expectedResult = 25;

            IQuestionRepository questionRepository = new QuestionRepository();
            int actualResult = questionRepository.MarkAnswers(answers);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Should_Return_Fifty_Percent()
        {
            IList<string> answers = new List<string>
            {
                { "Cuba" },
                { "France" },
                { "Warsaw" },
                { "Berlin" }
            };

            int expectedResult = 50;

            IQuestionRepository questionRepository = new QuestionRepository();
            int actualResult = questionRepository.MarkAnswers(answers);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Should_Return_SeventyFive_Percent()
        {
            IList<string> answers = new List<string>
            {
                { "Cuba" },
                { "Paris" },
                { "Warsaw" },
                { "Berlin" }
            };

            int expectedResult = 75;

            IQuestionRepository questionRepository = new QuestionRepository();
            int actualResult = questionRepository.MarkAnswers(answers);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Should_Return_OneHundred_Percent()
        {
            IList<string> answers = new List<string>
            {
                { "Havana" },
                { "Paris" },
                { "Warsaw" },
                { "Berlin" }
            };

            int expectedResult = 100;

            IQuestionRepository questionRepository = new QuestionRepository();
            int actualResult = questionRepository.MarkAnswers(answers);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

    }
}