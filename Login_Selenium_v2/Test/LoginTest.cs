using Login_Selenium_v2.Genericos;
using Login_Selenium_v2.PageObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Login_Selenium_v2.Test
{
    public class Tests
    {
        public IWebDriver driver;
        public LoginPage login;
        public LeerJson json;

        [SetUp]
        public void IniciarNavegador() { 
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");
            login = new LoginPage(driver);
            json = new LeerJson();
        }

        [TearDown]
        public void CerrarNavegador() {
            driver.Close();
            driver.Quit();
        }

        [Test]
        public void IngresoCorrecto()
        {
            String user = json.login_data().username;
            String password = json.login_data().password;

            login.IngresarCredenciales(user, password);
        }

        [Test]
        public void ingresoIncorrecto()
        {

            login.IngresarCredenciales("tomsmith1", "password");
        }
    }
}