using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Login_Selenium_v2.Genericos
{
    public class LeerJson
    {
        public POCO.LoginData login_data()
        {
            var Json = JsonConvert.DeserializeObject<POCO.LoginData>(File.ReadAllText(@"..\..\..\Data\login.json"));
            return Json;

            //try
            //{
            //    var jsonData = File.ReadAllText(@"..\..\..\Data\login.json");
            //    var loginData = JsonConvert.DeserializeObject<POCO.LoginData>(jsonData);
            //    return loginData ?? throw new InvalidOperationException("El archivo JSON está vacío o mal formateado.");
            //}
            //catch (FileNotFoundException)
            //{
            //    throw new FileNotFoundException("No se encontró el archivo JSON en la ruta especificada.");
            //}
            //catch (JsonException)
            //{
            //    throw new JsonException("El archivo JSON tiene un formato incorrecto.");
            //}


        }
    }
}
