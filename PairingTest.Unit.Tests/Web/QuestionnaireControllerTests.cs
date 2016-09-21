using NUnit.Framework;
using PairingTest.Web.Controllers;
using PairingTest.Web.Models;

namespace PairingTest.Unit.Tests.Web
{
    [TestFixture]
    public class QuestionnaireControllerTests
    {
        [Test]
        public void ShouldGetQuestionTitle()
        {
            //Arrange
            var expectedTitle = "Geography Questions";
            var questionnaireController = new QuestionnaireController();

            //Act
            var result = (QuestionnaireViewModel)questionnaireController.Index().ViewData.Model;
            
            //Assert
            Assert.That(result.QuestionnaireTitle, Is.EqualTo(expectedTitle));
        }

        [Test]
        public void ShouldGetQuestions()
        {
            //Arrange
            var questionnaireController = new QuestionnaireController();

            //Act
            var result = (QuestionnaireViewModel)questionnaireController.Index().ViewData.Model;

            //Assert
            Assert.IsTrue(result.QuestionsText.Count > 0);
        }
    }
}