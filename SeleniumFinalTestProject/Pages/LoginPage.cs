using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace SeleniumFinalTestProject.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        private By usernameField => By.Id("loginusername");
        private By passwordField => By.Id("loginpassword");
        private By loginBtn => By.XPath("//button[contains(text(),'Log in')]");
        private By loggedInUser => By.Id("nameofuser");

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void Login(string username, string password)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(usernameField)).SendKeys(username);
            wait.Until(ExpectedConditions.ElementIsVisible(passwordField)).SendKeys(password);
            wait.Until(ExpectedConditions.ElementToBeClickable(loginBtn)).Click();
        }

        public bool IsUserLoggedIn()
        {
            try
            {
                return wait.Until(ExpectedConditions.ElementIsVisible(loggedInUser)).Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}