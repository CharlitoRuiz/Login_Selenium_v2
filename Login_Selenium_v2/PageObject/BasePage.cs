using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
