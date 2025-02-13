using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using static System.Net.Mime.MediaTypeNames;
using Hackathon.Frogs.Selectors;
using OpenQA.Selenium.DevTools.V130.Debugger;

namespace Hackathon
{
    public class Tests
    {
        public IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void Test1()
        {
            
            driver.Navigate().GoToUrl("https://www.lutanho.net/play/frogs.html");
            Assert.That(driver.Title, Is.EqualTo("Frogs"));

            var frogElements = driver.FindElements(By.TagName("img"));

            int brownFrogs = 0;
            int greenFrogs = 0;
            int emptySpaces = 0;

            foreach (IWebElement frog in frogElements)
            {
                string frogSrc = frog.GetAttribute("src"); 

                if (frogSrc.Contains("frog1.gif")) 
                {
                    brownFrogs++;
                }
                else if (frogSrc.Contains("frog2.gif"))
                {
                    greenFrogs++;
                }
                else if (frogSrc.Contains("frog0.gif"))
                {
                    emptySpaces++;
                }
            }

            Console.WriteLine($"Brown Frogs: {brownFrogs}");
            Console.WriteLine($"Green Frogs: {greenFrogs}");
            Console.WriteLine($"Empty Spaces: {emptySpaces}");

            bool correctSetup = false;

            if (brownFrogs == 2 && greenFrogs == 2)
            {
                correctSetup = true;
                Console.WriteLine(" The game has 2 brown and 2 green frogs!");
                //break;
            }
            else
            {
                try
                {

                    var newGameBtn = driver.FindElement(By.XPath("//input[@value='NEW GAME']"));
                    newGameBtn.Click();
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine("New Game button not found! Retrying...");
                }
            }


            //pasidaryt norima setupa - spaudyt new game kol pasidarys musu norima kombinacija? 2x2 kombo

            //pradeda zalia - jei pries ja yra forg zero - spausti
            //patikrinti ar vel is kaires yra tuscia, jei ne veiksmas su zalia
            //ruda - ar pries ja yra laisvas, jei ne laisvas - tikrinti ar zalia varle ir jei uz jos tuscia - sokti
            //su ruda persoki
            //su abiejom zaliom

        }

        [OneTimeTearDown]
        public void TearDown()
        {
            
            driver.Quit();
        }
    }
}
