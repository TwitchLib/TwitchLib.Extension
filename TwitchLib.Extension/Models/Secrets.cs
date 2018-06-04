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

    public partial class ExtensionSecrets
    {
        public static ExtensionSecrets FromJson(string json) => JsonConvert.DeserializeObject<ExtensionSecrets>(json, TwitchLibJsonSerializer.Settings);
    }
}
