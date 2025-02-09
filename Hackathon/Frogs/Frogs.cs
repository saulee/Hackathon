using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace Hackathon
{
    public class Tests
    {
        private IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
           
            driver = new ChromeDriver();
        }

        [Test]
        public void Test1()
        {
            
            driver.Navigate().GoToUrl("https://www.lutanho.net/play/frogs.html");

       
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            
            driver.Quit();
        }
    }
}
