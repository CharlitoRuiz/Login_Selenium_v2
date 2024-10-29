using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Login_Selenium_v2
{
    public class Tests
    {

        [Test]
        public void ingresoCorrecto()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");

            driver.FindElement(By.Id("username")).SendKeys("tomsmith");
            driver.FindElement(By.Id("password")).SendKeys("SuperSecretPassword!");
            driver.FindElement(By.CssSelector("#login button")).Click();

            driver.Close();
            driver.Quit();
        }
    }
}