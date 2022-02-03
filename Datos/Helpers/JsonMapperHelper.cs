using System.Text.Json;

namespace Datos.Helpers
{
    public class JsonMapperHelper
    {
        public static T? LeeElementoDesdeArchivo<T>(string rutaArchivo)
        {
            try
            {
                var streamReader = new StreamReader(rutaArchivo);
                if (streamReader != null)
                {
                    var jsonString = streamReader.ReadToEnd();
                    var resultado = JsonSerializer.Deserialize<T>(jsonString);
                    return resultado;
                }

                return default;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}