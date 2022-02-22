using MongoDB.Bson;
using Realms;
using System.Text.Json.Serialization;

namespace Estructuras.RealmModels
{
    public class Automovil : RealmObject
    {
        [PrimaryKey]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        [JsonPropertyName("idAuto")]
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