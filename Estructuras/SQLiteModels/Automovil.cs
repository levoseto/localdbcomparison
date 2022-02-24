using SQLite;
using System.Text.Json.Serialization;

namespace Estructuras.SQLiteModels
{
    public class Automovil
    {
        [JsonIgnore]
        [JsonPropertyName("idAuto")]
        [PrimaryKey, AutoIncrement]
        public int IdAuto { get; set; }

        [JsonPropertyName("marca")]
        public string? Marca { get; set; }

        [JsonPropertyName("modelo")]
        public string? Modelo { get; set; }

        [JsonPropertyName("año")]
        public int Año { get; set; }

        [JsonPropertyName("serie")]
        public string? Serie { get; set; }
    }
}