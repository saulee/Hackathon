using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Hackathon.Frogs.Helpers
{
    public class Selectors
    {

        public static string frogLink = "https://www.lutanho.net/play/frogs.html";

        public static readonly By emptySpace = By.XPath("//img[@src='https://www.lutanho.net/play/frog0.gif']");
        public static readonly By brownFrog = By.XPath("//img[@src='https://www.lutanho.net/play/frog1.gif']");
        public static readonly By greenFrog = By.XPath("//img[@src='https://www.lutanho.net/play/frog2.gif']");
        public static readonly By frogElements = By.TagName("img");
        public static readonly By newGameBtn = By.XPath("//input[@value='NEW GAME']");

        public static string mathLink = "https://www.mathster.com/10secondsmaths/";
        public static readonly By questionNumber = By.Id("question");
        public static readonly By answerField = By.Id("question-answer");
        public static readonly By submitAnswer = By.Id("submit-answer");
        public static readonly By subCheckbox = By.XPath("//label/input[@type='checkbox' and @value='sub']");
        public static readonly By multipCheckbox = By.XPath("//label/input[@type='checkbox' and @value='mul']");
        public static readonly By divCheckbox = By.XPath("//label/input[@type='checkbox' and @value='div']");
        public static readonly By powCheckbox = By.XPath("//label/input[@type='checkbox' and @value='pow']");
        public static readonly By sqrtCheckbox = By.XPath("//label/input[@type='checkbox' and @value='sqrt']");
        public static readonly By timer = By.Id("time-left");
        public static readonly By slider = By.ClassName("noUi-base");
        public static readonly By sliderValue = By.XPath("//*[@style='left: 20%;']");
    }

}