using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace SeleniumFinalTestProject.Pages
{
    public class Product
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        private By addToCartButton => By.LinkText("Add to cart");
        private By LaptopLink(string laptopName) => By.LinkText(laptopName);

        public Product(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void SelectLaptop(string laptopName)
        {
            var laptopLocator = LaptopLink(laptopName);
            wait.Until(ExpectedConditions.ElementIsVisible(laptopLocator));
            driver.Navigate().Refresh();
            driver.FindElement(laptopLocator).Click();
        }

        public void AddToCart()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(addToCartButton)).Click();
        }

        public string GetAddToCartAlert()
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