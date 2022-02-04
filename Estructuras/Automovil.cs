using LiteDB;
using System.Text.Json.Serialization;

namespace Estructuras
{
    public class Automovil
    {
        [BsonField("_id")]
        public ObjectId? ID { get; set; }

        [JsonPropertyName("idAuto")]
        public long IdAuto { get; set; }

        [JsonPropertyName("marca")]
        public string? Marca { get; set; }

        [JsonPropertyName("modelo")]
        public string? Modelo { get; set; }

        [JsonPropertyName("año")]
        public long Año { get; set; }

        [JsonPropertyName("serie")]
        public string? Serie { get; set; }

        public Automovil()
        {
        }

        [BsonCtor]
        public Automovil(ObjectId _id, long idAuto, string marca, string modelo, long año, string serie)
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