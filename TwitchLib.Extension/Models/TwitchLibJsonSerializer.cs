using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TwitchLib.Extension.Models
{
    internal static class TwitchLibJsonSerializer
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            ContractResolver = new LowercaseContractResolver(),
            NullValueHandling = NullValueHandling.Ignore
        };

        public static string ToJson<T>(this T self) => JsonConvert.SerializeObject(self, Formatting.Indented, Settings);

        public class LowercaseContractResolver : DefaultContractResolver
        {
            protected override string ResolvePropertyName(string propertyName)
            {
                return propertyName.ToLower();
            }
        }

    }
}
