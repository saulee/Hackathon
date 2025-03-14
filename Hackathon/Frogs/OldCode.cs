//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using NUnit.Framework;
//using static System.Net.Mime.MediaTypeNames;
//using Hackathon.Frogs.Selectors;
//using OpenQA.Selenium.DevTools.V130.Debugger;

//namespace Hackathon
//{
//    public class Tests
//    {
//        public IWebDriver driver;

//        [OneTimeSetUp]
//        public void Setup()
//        {
//            driver = new ChromeDriver();
//        }

//        [Test]
//        public void Test1()
//        {

//            driver.Navigate().GoToUrl("https://www.lutanho.net/play/frogs.html");
//            Assert.That(driver.Title, Is.EqualTo("Frogs"));

//            bool combinationFound = false;

//            while (!combinationFound)
//            {
//                var frogElements = driver.FindElements(By.TagName("img"));

//                int brownFrogs = 0;
//                int greenFrogs = 0;
//                int emptySpaces = 0;

//                foreach (IWebElement frog in frogElements)
//                {
//                    string frogSrc = frog.GetAttribute("src");

//                    if (frogSrc.Contains("frog1.gif"))
//                    {
//                        brownFrogs++;
//                    }
//                    else if (frogSrc.Contains("frog2.gif"))
//                    {
//                        greenFrogs++;
//                    }
//                    else if (frogSrc.Contains("frog0.gif"))
//                    {
//                        emptySpaces++;
//                    }
//                }


//                if (brownFrogs == 2 && greenFrogs == 2)
//                {
//                    combinationFound = true;
//                }
//                else
//                {
//                    driver.FindElement(By.XPath("//input[@value='NEW GAME']")).Click();
//                }
//            }



//        }
//        pradeda zalia - jei pries ja yra forg zero - spausti
//        patikrinti ar vel is kaires yra tuscia, jei ne veiksmas su zalia
//        ruda - ar pries ja yra laisvas, jei ne laisvas - tikrinti ar zalia varle ir jei uz jos tuscia - sokti
//        su ruda persoki
//        su abiejom zaliom

//        issiaiskinti varliu pozicijas
//        kai turi pozicijas pasisortint varles
//        pradeti spaydineti - tikrinti kas yra proies tavo varle(jei prieky ne tuscias, object uz jos tuscias - sokti aletras)


//ANOTHER

//private bool combinationFound;

//public void GoToPage(IWebDriver driver)
//{
//    driver.Navigate().GoToUrl(Selectors.frogLink);
//    Assert.That(driver.Title, Is.EqualTo("Frogs"));
//}

//public (int brownFrogs, int greenFrogs, int emptySpaces) GetFrogCounts(IWebDriver driver)
//{
//    var frogElements = driver.FindElements(Selectors.frogElements);

//    int brownFrogs = 0;
//    int greenFrogs = 0;
//    int emptySpaces = 0;

//    foreach (IWebElement frog in frogElements)
//    {
//        string frogSrc = frog.GetAttribute("src");

//        if (frogSrc.Contains("frog1.gif"))
//        {
//            brownFrogs++;
//        }
//        else if (frogSrc.Contains("frog2.gif"))
//        {
//            greenFrogs++;
//        }
//        else if (frogSrc.Contains("frog0.gif"))
//        {
//            emptySpaces++;
//        }
//    }

//    return (brownFrogs, greenFrogs, emptySpaces);
//}

//public void FrogCombinationFound(IWebDriver driver, int brownFrogs, int greenFrogs)
//{
//    combinationFound = false;

//    if (brownFrogs == 2 && greenFrogs == 2)
//    {
//        combinationFound = true;
//    }
//    else
//    {
//        driver.FindElement(Selectors.newGameBtn).Click();
//    }
//}

//        [OneTimeTearDown]
//        public void TearDown()
//        {

//            driver.Quit();
//        }
//    }
//}
