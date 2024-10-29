using OpenQA.Selenium;

namespace Login_Selenium_v2.Genericos
{
    public class TomarCaptura
    {
        public string CapturarPantalla(IWebDriver driver) {

            string photo="";

            try
            {
                ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
                Screenshot screenshot = screenshotDriver.GetScreenshot();
                photo = screenshot.AsBase64EncodedString;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"No se pudo guardar la captura de pantalla: {ex.Message}");
            }
            return photo;
        }
    }
}
