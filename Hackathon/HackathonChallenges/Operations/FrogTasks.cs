using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hackathon.Frogs.Helpers;
using NUnit.Framework;
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

        public (List<int> positionsEmptySpace, List<int> positionsBrownFrog, List<int> positionsGreenFrog) GetFrogElementsToList(IWebDriver driver)
        {
            List<int> positionsEmptySpace = new List<int>();
            List<int> positionsBrownFrog = new List<int>();
            List<int> positionsGreenFrog = new List<int>();

            // Find all frog-related elements
            var frogElements = driver.FindElements(By.XPath("//img"));

            foreach (var frogElement in frogElements)
            {
                string onMouseDown = frogElement.GetAttribute("onmousedown");
                if (string.IsNullOrEmpty(onMouseDown) || !onMouseDown.Contains("Clicked("))
                    continue; // Skip if no valid onmousedown attribute

                int position = int.Parse(onMouseDown.Split('(', ')')[1]); // Extracts position number
                string imageSrc = frogElement.GetAttribute("src");

                // Categorize positions based on the image source
                if (imageSrc.Contains("frog0.gif"))
                {
                    positionsEmptySpace.Add(position);
                }
                else if (imageSrc.Contains("frog1.gif"))
                {
                    positionsBrownFrog.Add(position);
                }
                else if (imageSrc.Contains("frog2.gif"))
                {
                    positionsGreenFrog.Add(position);
                }
            }

            return (positionsEmptySpace, positionsBrownFrog, positionsGreenFrog);
        }

        public (List<int> positionsEmptySpace, List<int> positionsBrownFrog, List<int> positionsGreenFrog) sortFrogPositionInList(IWebDriver driver)
        {
            var (positionsEmptySpace, positionsBrownFrog, positionsGreenFrog) = GetFrogElementsToList(driver);
            positionsEmptySpace = positionsEmptySpace.OrderBy(pos => pos).ToList();
            positionsBrownFrog = positionsBrownFrog.OrderByDescending(pos => pos).ToList();
            positionsGreenFrog = positionsGreenFrog.OrderBy(pos => pos).ToList();
            return (positionsEmptySpace, positionsBrownFrog, positionsGreenFrog);
        }

        public void MoveFrogs(IWebDriver driver)
        {
            var (brownFrogs, greenFrogs, emptySpaces) = GetFrogCounts(driver);
            var (positionsEmptySpace, positionsBrownFrog, positionsGreenFrog) = sortFrogPositionInList(driver);

            while (positionsBrownFrog.Any(pos => pos < 4) || positionsGreenFrog.Any(pos => pos > 4))
            {
                foreach (var position in positionsBrownFrog)
                {
                    var nextPosition = position + 1;
                    var jumpPosition = position + 2;

                    if (positionsEmptySpace.Contains(nextPosition))
                    {
                        driver.FindElement(By.XPath($"//img[contains(@onmousedown, 'Clicked({position})')]")).Click();
                        //check the alert message separate method
                        break;
                    }
                    else if (positionsEmptySpace.Contains(jumpPosition))
                    {
                        driver.FindElement(By.XPath($"//img[contains(@onmousedown, 'Clicked({position})')]")).Click();
                        break;
                    }
                }

                (positionsEmptySpace, positionsBrownFrog, positionsGreenFrog) = sortFrogPositionInList(driver);

                foreach (var position in positionsGreenFrog)
                {
                    var nextPosition = position - 1;
                    var jumpPosition = position - 2;

                    if (positionsEmptySpace.Contains(nextPosition))
                    {
                        driver.FindElement(By.XPath($"//img[contains(@onmousedown, 'Clicked({position})')]")).Click();
                        break;
                    }
                    else if (positionsEmptySpace.Contains(jumpPosition))
                    {
                        driver.FindElement(By.XPath($"//img[contains(@onmousedown, 'Clicked({position})')]")).Click();
                        break;
                    }
                }
                (positionsEmptySpace, positionsBrownFrog, positionsGreenFrog) = sortFrogPositionInList(driver);
            }
            //if alert - break also add into method
        }
    }
}