using OpenQA.Selenium;

namespace Login_Selenium_v2.PageObject
{
    public class BasePage
    {
        public IWebDriver _driver;

        // Constructor
        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
