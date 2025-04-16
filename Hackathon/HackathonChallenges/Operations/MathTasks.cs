using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V130.DOM;

namespace Hackathon.Frogs.Operations
{
    internal class MathTasks
    {
        public void GoToMathPage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(Helpers.Selectors.mathLink);
            Thread.Sleep(3000);
        }

        public void Checkbox(IWebDriver driver)
        {
            var checkbox = driver.FindElement(Helpers.Selectors.SubCheckbox);
            checkbox.Click();
        }

        public void SolveMathQuestion(IWebDriver driver)
        {
            var questionElement = driver.FindElement(Helpers.Selectors.QuestionNumber);
            var questionText = questionElement.Text;
       
            var parts = questionText.Split(' ');
            int num1 = int.Parse(parts[0]);
            string operation = parts[1];
            int num2 = int.Parse(parts[2]);
            int answer = 0;

            if (operation == "+")
            {
                answer = num1 + num2;
            }
            else if (operation == "-")
            {
                answer = num1 - num2;
            }
            var answerField = driver.FindElement(Helpers.Selectors.AnswerField);
            answerField.SendKeys(answer.ToString());
        }

        public void CalculateAllAnswers(IWebDriver driver)
        {
            for (int i = 0; i < 70; i++)
            {
                SolveMathQuestion(driver);
                var submitButton = driver.FindElement(Helpers.Selectors.SubmitAnswer);
                submitButton.Click();
            }
        }

        public void CountTime(IWebDriver driver)
        {
            var timeLeft = driver.FindElement(Helpers.Selectors.Timer);
            var timeLeftText = timeLeft.Text;

            if (timeLeftText == "0")
            {
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();
            }
        }
    }
}
