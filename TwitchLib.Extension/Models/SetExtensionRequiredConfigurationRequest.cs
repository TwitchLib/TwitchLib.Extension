using Newtonsoft.Json;

namespace TwitchLib.Extension.Models
{
    public class SetExtensionRequiredConfigurationRequest
    {
        [JsonProperty(PropertyName = "required_configuration")]
        public string Required_Configuration { get; internal set; }
    }
}
