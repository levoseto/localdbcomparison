using LiteDB;
using System.Text.Json.Serialization;

namespace Estructuras.LiteDBModels
{
    public class Automovil
    {
        [BsonField("_id")]
        public ObjectId? ID { get; set; }

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

        [BsonCtor]
        public Automovil(ObjectId _id, int idAuto, string marca, string modelo, int año, string serie)
        {
            ID = _id;
            IdAuto = idAuto;
            Marca = marca;
            Modelo = modelo;
            Año = año;
            Serie = serie;
        }
    }
}