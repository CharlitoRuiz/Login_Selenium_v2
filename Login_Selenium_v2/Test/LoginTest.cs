using Login_Selenium_v2.Genericos;
using Login_Selenium_v2.PageObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections;

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

        public static IEnumerable TestData
        {
            get
            {
                var json = new LeerJson();
                return json.login_data().Select(data => new TestCaseData(data.username, data.password));
            }
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public void IngresoPagina(String user, String password)
        {

            login.IngresarCredenciales(user, password);
        }
    }
}