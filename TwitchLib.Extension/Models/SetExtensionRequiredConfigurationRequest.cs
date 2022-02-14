using Newtonsoft.Json;

namespace TwitchLib.Extension.Models
{
    public class SetExtensionRequiredConfigurationRequest
    {
        [JsonProperty(PropertyName = "required_configuration")]
        public string RequiredConfiguration { get; internal set; }
        [JsonProperty(PropertyName = "extension_id")]
        public string ExtensionId { get; internal set; }
        [JsonProperty(PropertyName = "extension_version")]
        public string ExtensionVersion { get; internal set; }
    }
}
