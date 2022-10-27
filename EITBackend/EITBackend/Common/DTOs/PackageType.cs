using System.Text.Json.Serialization;

namespace EITBackend.Common.DTOs
{
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum PackageType
        {
            SmallPackage,
            Box,
            Crate,
        }
    }
