using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using LiteDB;

namespace Estructuras
{
    public partial class Automovil
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
    }
}