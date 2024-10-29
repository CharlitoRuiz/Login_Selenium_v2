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
                return json.login_data("login", "credenciales").Select(data => new TestCaseData(data.username, data.password));
            }
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public void IngresoPagina(string user, string password)
        {
            try
            {
                login.IngresarCredenciales(user, password);
                wait.Until(driver => login.LoginButtom.Enabled && login.LoginButtom.Displayed);
                wait.Until(driver => !login.UsernameField.Equals(null));
                login.ClickBotonLogin();
                Assert.That(driver.Url.Equals("https://the-internet.herokuapp.com/secure"), "La URL no corresponde a la pagina de inicio esperada");
                wait.Until(driver => login.PageMessage.Displayed);
                Assert.That(login.ValidarIngresoCorrecto(), "La validaci�n de ingreso correcto fall�.");
                Assert.That(login.LogoutButtom.Displayed, "El bot�n de logout no se mostr� correctamente.");
                wait.Until(driver => login.LogoutButtom.Enabled);
                login.CerrarSesion();
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine($"No se encontr� el elemento: {ex.Message}");
                Assert.Fail($"Prueba fallida: { ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la ejecuci�n del test: {ex.Message}");
                throw;
            }
        }
    }
}