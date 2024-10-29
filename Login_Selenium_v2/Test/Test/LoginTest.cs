using AventStack.ExtentReports;
using Login_Selenium_v2.Genericos;
using OpenQA.Selenium;
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
            test = extent.CreateTest("Ingresar a la página");


            try
            {
                login.IngresarCredenciales(user, password);
                test.Log(Status.Pass, $"Se ingresaron las credenciales: {user}, {password}");
                wait.Until(driver => login.LoginButtom.Enabled && login.LoginButtom.Displayed);
                wait.Until(driver => !login.UsernameField.Equals(null)); // wait.Until(driver => login.UsernameField != null); 
                login.ClickBotonLogin();
                test.Log(Status.Pass, "Click en el botón Login");
                Assert.That(driver.Url.Equals("https://the-internet.herokuapp.com/secure"), "La URL no corresponde a la pagina de inicio esperada");
                wait.Until(driver => login.PageMessage.Displayed);
                Assert.That(login.ValidarIngresoCorrecto(), "La validación de ingreso correcto falló.");
                Assert.That(login.LogoutButtom.Displayed, "El botón de logout no se mostró correctamente.");
                wait.Until(driver => login.LogoutButtom.Enabled);
                login.ClickBotonLogout();
                test.Log(Status.Pass, "Se dio click en el botón Logout");
            }
            catch (NoSuchElementException ex)
            {
                test.AddScreenCaptureFromBase64String(captura.CapturarPantalla(driver));
                Assert.Fail($"No se encontró el elemento: {ex.Message}");
            }
            catch (AssertionException ex)
            {
                test.Log(Status.Fail, $"Fallo de aserción: {ex.Message}");
                test.AddScreenCaptureFromBase64String(captura.CapturarPantalla(driver));
                Assert.Fail($"Fallo de aserción: {ex.Message}");
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, $"Error en la ejecución del test: {ex.Message}");
                test.AddScreenCaptureFromBase64String(captura.CapturarPantalla(driver));
                Assert.Fail($"Error en la ejecución del test: {ex.Message}");
                throw;
            }
        }
    }
}