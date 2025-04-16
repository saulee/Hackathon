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
        public static readonly By QuestionNumber = By.Id("question");
        public static readonly By AnswerField = By.Id("question-answer");
    }

}