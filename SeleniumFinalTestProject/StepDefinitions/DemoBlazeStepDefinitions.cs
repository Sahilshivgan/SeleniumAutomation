using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using SeleniumFinalTestProject.Pages;
using System;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Edge;

namespace SeleniumFinalTestProject.StepDefinitions
{
    [Binding]
    public class DemoBlazeStepDefinitions
    {
        IWebDriver driver;
        WebDriverWait wait;

        string selectedLaptop;
        HomePage homePage;
        SignUpPage signUpPage;
        LoginPage loginPage;
        Product productPage;
        CartPage cartPage;

        [Given("I navigate to the Demoblaze website")]
        public void GivenINavigateToTheDemoblazeWebsite()
        {
            driver = new EdgeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            homePage = new HomePage(driver);
            loginPage = new LoginPage(driver);
            signUpPage = new SignUpPage(driver);
            productPage = new Product(driver);
            cartPage = new CartPage(driver);

            homePage.NavigateToSite();
        }

        [When("I open the Sign Up modal with {string} and password {string}")]
        public void WhenIOpenTheSignUpModalWithAndPassword(string username, string password)
        {
            homePage.ClickSignUp();
            signUpPage.SignUp(username, password);
        }

        [Then("I should see a signup success message")]
        public void ThenIShouldSeeASignupSuccessMessage()
        {
            var message = signUpPage.GetSignUpAlert();
            Assert.That(message.Contains("Sign up successful.") || message.Contains("This user already exist."));
        }

        [When("I open the Login modal with {string} and password {string}")]
        public void WhenIOpenTheLoginModalWithAndPassword(string username, string password)
        {
            homePage.ClickLogin();
            loginPage.Login(username, password);
        }

        [Then("I should see the user logged in")]
        public void ThenIShouldSeeTheUserLoggedIn()
        {
            Assert.That(loginPage.IsUserLoggedIn());
        }

        [When("I click on {string} category on home page")]
        public void WhenIClickOnCategoryOnHomePage(string category)
        {
            homePage.ClickLaptops(); 
        }

        [When("I select the laptop {string} and add it to the cart")]
        public void WhenISelectTheLaptopAndAddItToTheCart(string laptop)
        {
            selectedLaptop = laptop;
            productPage.SelectLaptop(laptop);
            productPage.AddToCart();
        }

        [Then("I should see a confirmation message")]
        public void ThenIShouldSeeAConfirmationMessage()
        {
            var message = productPage.GetAddToCartAlert();
            Assert.That(message, Is.EqualTo("Product added."));
        }

        [Then("the laptop should appear in the cart")]
        public void ThenTheLaptopShouldAppearInTheCart()
        {
            homePage.ClickCart();
            Assert.That(cartPage.IsLaptopInCart(selectedLaptop));
        }

        [AfterScenario]
        public void TearDown()
        {
            driver?.Quit();
        }
    }
}