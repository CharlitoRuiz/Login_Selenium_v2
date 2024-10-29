using Login_Selenium_v2.Genericos;
using Login_Selenium_v2.PageObject.Login;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
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
        public WebDriverWait wait;



        [SetUp]
        public void IniciarNavegador()
        {
            driver = new ChromeDriver();
            // Implicit wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");
            login = new LoginPage(driver);
            json = new LeerJson();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        [TearDown]
        public void CerrarNavegador()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
