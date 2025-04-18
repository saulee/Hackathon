using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hackathon.Frogs.Operations;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Hackathon.HackathonChallenges.Tests
{
    public class Math
    {
        IWebDriver driver;
        private MathTasks mathTasks;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            mathTasks = new MathTasks();
        }
        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }
        [Test]
        public void MathPageTest()
        {
            mathTasks.GoToMathPage(driver);
            //mathTasks.SliderTo1000(driver);
            mathTasks.Checkbox(driver);
            mathTasks.SolveMathQuestion(driver);
            mathTasks.CalculateAllAnswers(driver);
        }

    }
}
