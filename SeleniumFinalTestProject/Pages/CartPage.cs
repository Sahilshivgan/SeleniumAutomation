using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFinalTestProject.Pages
{
    public class CartPage
    {
         IWebDriver driver;
        WebDriverWait wait;

        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              
        }



        public bool IsLaptopInCart(string laptopName)
        {

            var laptopElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//td[contains(text(),'{laptopName}')]")));
            return laptopElement.Displayed;

        }
    }
}
