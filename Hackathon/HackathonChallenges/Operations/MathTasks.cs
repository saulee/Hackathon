using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Hackathon.Frogs.Operations
{
    internal class MathTasks
    {
        public void GoToMathPage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(Helpers.Selectors.mathLink);
            Assert.That(driver.Title, Is.EqualTo("10 Seconds Maths"));
        }


    }
}
