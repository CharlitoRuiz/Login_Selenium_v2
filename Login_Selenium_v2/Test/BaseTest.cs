using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
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
        public TomarCaptura captura;
        public WebDriverWait wait;

        // Reportes
        public static ExtentTest test;
        public static ExtentReports extent;



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
            captura = new TomarCaptura();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        [OneTimeSetUp]
        public void IniciarReporte() {
            // Ruta del proyecto y directorio prinicipal
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectRootDirectory = Directory.GetParent(currentDirectory).Parent.Parent.Parent.FullName; // Esto devuelve la raiz del proyecto

            // El folder del reporte es "Reportes"
            string reportFolder = Path.Combine(projectRootDirectory, "Reportes");
            if (!Directory.Exists(reportFolder))
            {
                Directory.CreateDirectory(reportFolder);
            }
            // El nombre del archivo es "index.html"
            string reportPath = Path.Combine(reportFolder, "index.html");

            // Inicializar el reporte
            extent = new ExtentReports();
            ExtentSparkReporter htmlreporter = new ExtentSparkReporter(reportPath);
            extent.AttachReporter(htmlreporter);

            // Configuracion del tema oscuro
            htmlreporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Dark;
        }

        [OneTimeTearDown]
        public void cerrarReporte()
        {
            extent.Flush();
        }

        [TearDown]
        public void CerrarNavegador()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
