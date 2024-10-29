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

        // Actions
        public IWebElement UsernameField => _driver.FindElement(_txtUsername);
        public IWebElement PasswordField => _driver.FindElement(_txtPassword);
        public IWebElement LoginButtom => _driver.FindElement(_btnLogin);

        // Method
        public void IngresarCredenciales(string user, string password)
        {
            UsernameField.SendKeys(user);
            PasswordField.SendKeys(password);
            LoginButtom.Click();

        }
    }
}
