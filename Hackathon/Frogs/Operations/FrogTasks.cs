using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hackathon.Frogs.Helpers;
using OpenQA.Selenium;

namespace Hackathon.Frogs.Operations
{
    class FrogTasks
    {
        public void GoToPage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(Selectors.frogLink);
            Assert.That(driver.Title, Is.EqualTo("Frogs"));
        }

        public (int brownFrogs, int greenFrogs, int emptySpaces) GetFrogCounts(IWebDriver driver)
        {
            var frogElements = driver.FindElements(Selectors.frogElements);

            int brownFrogs = frogElements.Count(f => f.GetAttribute("src").Contains("frog1.gif"));
            int greenFrogs = frogElements.Count(f => f.GetAttribute("src").Contains("frog2.gif"));
            int emptySpaces = frogElements.Count(f => f.GetAttribute("src").Contains("frog0.gif"));

            return (brownFrogs, greenFrogs, emptySpaces);
        }

        public bool FrogCombinationFound(IWebDriver driver)
        {
            bool combinationFound = false;

            while (!combinationFound)
            {
                var (brownFrogs, greenFrogs, emptySpaces) = GetFrogCounts(driver);

                if (brownFrogs == 2 && greenFrogs == 2)
                {
                    combinationFound = true;
                    return true;
                }
                else
                {
                    driver.FindElement(Selectors.newGameBtn).Click();
                }
            }
            return false;
        }

        public (List<(IWebElement element, int position)> frog0Elements,
        List<(IWebElement element, int position)> frog1Elements,
        List<(IWebElement element, int position)> frog2Elements)
        GetFrogElementsToList(IWebDriver driver)
        {
            // Initialize lists to store frogs and empty spaces
            List<(IWebElement element, int position)> frog0Elements = new List<(IWebElement, int)>();
            List<(IWebElement element, int position)> frog1Elements = new List<(IWebElement, int)>();
            List<(IWebElement element, int position)> frog2Elements = new List<(IWebElement, int)>();

            // Find all frog-related elements
            var frogElements = driver.FindElements(By.XPath("//img"));

            foreach (var frogElement in frogElements)
            {
                string onMouseDown = frogElement.GetAttribute("onmousedown");
                if (string.IsNullOrEmpty(onMouseDown) || !onMouseDown.Contains("Clicked("))
                    continue; // Skip if no valid onmousedown attribute

                int position = int.Parse(onMouseDown.Split('(', ')')[1]); // Extracts position number
                string imageSrc = frogElement.GetAttribute("src");

                // Categorize and add to the correct list
                if (imageSrc.Contains("frog0.gif"))
                    frog0Elements.Add((frogElement, position)); // Empty space
                else if (imageSrc.Contains("frog1.gif"))
                    frog1Elements.Add((frogElement, position)); // Brown frog
                else if (imageSrc.Contains("frog2.gif"))
                    frog2Elements.Add((frogElement, position)); // Green frog
            }

            // Return all three lists
            return (frog0Elements, frog1Elements, frog2Elements);
        }

        public void MoveFrogs(IWebDriver driver)
        {
            var (brownFrogs, greenFrogs, emptySpaces) = GetFrogCounts(driver);
            // 2 2 5
            List<(IWebElement element, int position)> frog0Elements = new List<(IWebElement, int)>();
            List<(IWebElement element, int position)> frog1Elements = new List<(IWebElement, int)>();
            List<(IWebElement element, int position)> frog2Elements = new List<(IWebElement, int)>();


        }


    }
}
