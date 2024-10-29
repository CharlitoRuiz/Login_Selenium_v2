using Newtonsoft.Json;

namespace Login_Selenium_v2.Genericos
{
    public class LeerJson
    {
        public List<POCO.LoginData> login_data()
        {
            try
            {
                var Json = JsonConvert.DeserializeObject<Dictionary<String, List<POCO.LoginData>>>(File.ReadAllText(@"..\..\..\Data\login.json"));
                return Json["credenciales"] ?? throw new InvalidOperationException("El archivo JSON está vacío o mal formateado."); 
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("No se encontró el archivo JSON en la ruta especificada.");
            }
            catch (JsonException)
            {
                throw new JsonException("El archivo JSON tiene un formato incorrecto.");
            }

        }
    }
}
