using Login_Selenium_v2.Genericos;
using Login_Selenium_v2.PageObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections;

namespace Login_Selenium_v2.Test.Test
{
    public class Tests : BaseTest
    {

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
        public void IngresoPagina(string user, string password)
        {

            login.IngresarCredenciales(user, password);
            wait.Until(driver => login.LoginButtom.Enabled && login.LoginButtom.Displayed);
            wait.Until(driver => !login.UsernameField.Equals(null));
            login.ClickBotonLogin();
            Assert.That(driver.Url.Equals("https://the-internet.herokuapp.com/secure"));
            wait.Until(driver => login.PageMessage.Displayed);
            Assert.That(login.ValidarIngresoCorrecto());
            Assert.That(login.LogoutButtom.Displayed);
            wait.Until(driver => login.LogoutButtom.Enabled);
            login.CerrarSesion();
        }
    }
}