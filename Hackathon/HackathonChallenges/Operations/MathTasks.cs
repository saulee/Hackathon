using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V130.DOM;
using OpenQA.Selenium.Interactions;

namespace Hackathon.Frogs.Operations
{
    internal class MathTasks
    {
        public void GoToMathPage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(Helpers.Selectors.mathLink);
            Thread.Sleep(3000);
        }

        public void SliderTo1000(IWebDriver driver)
        {

        }

        public void Checkbox(IWebDriver driver)
        {
            var checkboxSub = driver.FindElement(Helpers.Selectors.subCheckbox);
            checkboxSub.Click();
            var checkboxMultip = driver.FindElement(Helpers.Selectors.multipCheckbox);
            checkboxMultip.Click();
            var checkboxDiv = driver.FindElement(Helpers.Selectors.divCheckbox);
            checkboxDiv.Click();
        }

        public void SolveMathQuestion(IWebDriver driver)
        {
            var questionElement = driver.FindElement(Helpers.Selectors.questionNumber);
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
            else if (operation == "×")
            {
                answer = num1 * num2;
            }
            else if (operation == "÷")
            {
                answer = num1 / num2;
            }
            else if (operation == "√")
            {
                answer = (int)Math.Sqrt(num1);
            }
            var answerField = driver.FindElement(Helpers.Selectors.answerField);
            answerField.SendKeys(answer.ToString());
        }

        //public void CalculateAllAnswers(IWebDriver driver)
        //{
        //    for (int i = 0; i < 70; i++)
        //    {
        //        SolveMathQuestion(driver);
        //        var submitButton = driver.FindElement(Helpers.Selectors.SubmitAnswer);
        //        submitButton.Click();
        //    }
        //}

        public void CalculateAllAnswers(IWebDriver driver)
        {
            var timeEnded = false;
            while (timeEnded == false)
            {
                SolveMathQuestion(driver);
                var submitButton = driver.FindElement(Helpers.Selectors.submitAnswer);
                submitButton.Click();
               
                timeEnded = CountTime(driver);
            }

        }

        public bool CountTime(IWebDriver driver)
        {
            var timeLeft = driver.FindElement(Helpers.Selectors.timer);
            var timeLeftText = timeLeft.Text;

            if (timeLeftText == "0")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
