using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Hackathon.Frogs.Selectors
{
    public class Selectors
    {
        private IWebDriver driver;

        public Selectors(IWebDriver webDriver)
        {
            driver = webDriver;

            var emptySpace = driver.FindElement(By.XPath("//img[@src='https://www.lutanho.net/play/frog0.gif']"));
            var brownFrog = driver.FindElement(By.XPath("//img[@src='https://www.lutanho.net/play/frog1.gif']"));
            var greenFrog = driver.FindElement(By.XPath("//img[@src='https://www.lutanho.net/play/frog2.gif']"));
            var frogElements = driver.FindElements(By.TagName("img"));
            var newGameBtn = driver.FindElement(By.XPath("//input[@value='NEW GAME']"));
        }
    }
}
