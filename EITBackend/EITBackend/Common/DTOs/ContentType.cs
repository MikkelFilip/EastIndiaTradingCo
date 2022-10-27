using System.Text.Json.Serialization;

namespace EITBackend.Common.DTOs
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ContentType
    {
        RecordedDelivery,
        Weapons,
        LiveAnimals,
        CautiousParcels,
        RefrigeratedGoods,
        Other
    }
}
