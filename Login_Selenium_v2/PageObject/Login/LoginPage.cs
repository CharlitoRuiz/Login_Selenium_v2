using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Selenium_v2.PageObject.Login
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }

        // Elements locators
        private readonly By _txtUsername = By.Id("username");
        private readonly By _txtPassword = By.Id("password");
        private readonly By _btnLogin = By.CssSelector("#login button");
        private readonly By _msgLogged = By.Id("flash");
        private readonly By _btnLogout = By.CssSelector(".button[href='/logout']");
        private readonly By _txtTitle = By.CssSelector("h2");
        private readonly By _msgWelcome = By.CssSelector("h4");

        // Actions
        public IWebElement UsernameField => _driver.FindElement(_txtUsername);
        public IWebElement PasswordField => _driver.FindElement(_txtPassword);
        public IWebElement LoginButtom => _driver.FindElement(_btnLogin);
        public IWebElement LoginMessage => _driver.FindElement(_msgLogged);
        public IWebElement LogoutButtom => _driver.FindElement(_btnLogout);
        public IWebElement PageTitle => _driver.FindElement(_txtTitle);
        public IWebElement PageMessage=> _driver.FindElement(_msgWelcome);


        // Method
        public void IngresarCredenciales(string user, string password)
        {
            UsernameField.SendKeys(user);
            PasswordField.SendKeys(password);
            LoginButtom.Click();

        }
        public bool ValidarIngresoCorrecto() {
            bool isLogged = LoginMessage.Text.Contains("You logged into a secure area!") && PageMessage.Text.Equals("Welcome to the Secure Area. When you are done click logout below.");
            return isLogged;
        }
    }
}
