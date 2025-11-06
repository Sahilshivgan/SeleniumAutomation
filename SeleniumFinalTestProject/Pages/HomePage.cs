using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace SeleniumFinalTestProject.Pages
{
    public class HomePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        // Locators
        private By signUpButton => By.Id("signin2");
        private By loginButton => By.Id("login2");
        private By laptopsLink => By.LinkText("Laptops");
        private By cartButton => By.Id("cartur");

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void NavigateToSite()
        {
            driver.Navigate().GoToUrl("https://www.demoblaze.com/");
            driver.Manage().Window.Maximize();
        }

        public void ClickSignUp()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(signUpButton));
            driver.FindElement(signUpButton).Click();
        }

        public void ClickLogin()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(loginButton));
            driver.FindElement(loginButton).Click();
        }

        public void ClickLaptops() => wait.Until(ExpectedConditions.ElementToBeClickable(laptopsLink)).Click();

        public void ClickCart() => wait.Until(ExpectedConditions.ElementToBeClickable(cartButton)).Click();
    }
}