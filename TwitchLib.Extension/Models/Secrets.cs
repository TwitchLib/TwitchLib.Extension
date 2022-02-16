using Newtonsoft.Json;

namespace TwitchLib.Extension.Models
{
    public partial class ExtensionSecrets
    {
        [JsonProperty(PropertyName = "format_version")]
        public string Format_Version { get; protected set; }
        [JsonProperty(PropertyName = "secrets")]
        public Secret[] Secrets { get; protected set; }
    }

    public partial class ExtensionSecretsData
    {
        [JsonProperty(PropertyName = "data")]
        public ExtensionSecrets[] Data { get; protected set; }
    }

    public partial class ExtensionSecretsData
    {
        public static ExtensionSecretsData FromJson(string json) => JsonConvert.DeserializeObject<ExtensionSecretsData>(json, TwitchLibJsonSerializer.Settings);
    }
}
