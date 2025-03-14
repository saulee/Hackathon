using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using static System.Net.Mime.MediaTypeNames;
using Hackathon.Frogs.Helpers;
using OpenQA.Selenium.DevTools.V130.Debugger;
using Hackathon.Frogs.Operations;


namespace Hackathon.Frogs.Tests
{
    public class FrogTest
    {
        IWebDriver driver;
        private FrogTasks frogsTasks;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            frogsTasks = new FrogTasks();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }
        [Test]
        public void FrogsWinningGame()
        {
            frogsTasks.GoToPage(driver);
            frogsTasks.GetFrogCounts(driver);
            frogsTasks.FrogCombinationFound(driver);
            frogsTasks.GetFrogElementsToList(driver);
            frogsTasks.MoveFrogs(driver);
        }
    }
}
