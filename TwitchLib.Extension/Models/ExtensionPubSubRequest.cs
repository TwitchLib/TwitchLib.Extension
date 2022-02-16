using Newtonsoft.Json;

namespace TwitchLib.Extension.Models
{
    public class ExtensionPubSubRequest
    {
        [JsonProperty(PropertyName = "message")]
        public object Message { get;  set; }
        [JsonProperty(PropertyName = "target")]
        public string[] Targets { get;  set; }
        [JsonProperty(PropertyName = "broadcaster_id")]
        public string BroadcasterId { get; set; } = null;
        [JsonProperty(PropertyName = "is_global_broadcast")]
        public bool IsGlobalBroadcast => string.IsNullOrEmpty(this.BroadcasterId);
    }
}
