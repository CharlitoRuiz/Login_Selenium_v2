using Login_Selenium_v2.PageObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Login_Selenium_v2.Test
{
    public class Tests
    {
        public IWebDriver driver;
        public LoginPage login;

        [SetUp]
        public void IniciarNavegador() { 
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");
            login = new LoginPage(driver);
        }

        [TearDown]
        public void CerrarNavegador() {
            driver.Close();
            driver.Quit();
        }

        [Test]
        public void ingresoCorrecto()
        {
            login.IngresarCredenciales();
        }

        [Test]
        public void ingresoIncorrecto()
        {
            login.IngresarCredenciales();
        }
    }
}