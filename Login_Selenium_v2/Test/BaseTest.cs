using Login_Selenium_v2.Genericos;
using Login_Selenium_v2.PageObject.Login;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Selenium_v2.Test
{
    public class BaseTest
    {
        public IWebDriver driver;
        public LoginPage login;
        public LeerJson json;



        [SetUp]
        public void IniciarNavegador()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");
            login = new LoginPage(driver);
            json = new LeerJson();
        }

        [TearDown]
        public void CerrarNavegador()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
