using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace SeleniumFinalTestProject.Pages
{
    public class SignUpPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        private By usernameField => By.Id("sign-username");
        private By passwordField => By.Id("sign-password");
        private By signUpButton => By.XPath("//button[contains(text(),'Sign up')]");

        public SignUpPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
        }

        public void SignUp(string username, string password)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(usernameField)).SendKeys(username);
            wait.Until(ExpectedConditions.ElementIsVisible(passwordField)).SendKeys(password);
            wait.Until(ExpectedConditions.ElementToBeClickable(signUpButton)).Click();
        }

        public string GetSignUpAlert()
        {
            try
            {
                wait.Until(ExpectedConditions.AlertIsPresent());
                var alert = driver.SwitchTo().Alert();
                string message = alert.Text;
                alert.Accept();
                return message;
            }
            catch (NoAlertPresentException)
            {
                return "No alert was present.";
            }
        }
    }
}