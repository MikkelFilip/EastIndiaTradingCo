using System.Text.Json.Serialization;

namespace EITBackend.Common.DTOs
{
        /// <summary>
        /// Placment in a vehicle.
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum PackageType
        {
            /// <summary>
            /// Package Type A
            /// </summary>
            A,

            /// <summary>
            /// Package Type B
            /// </summary>
            B,

            /// <summary>
            /// Package Type C
            /// </summary>
            C,
        }
    }
