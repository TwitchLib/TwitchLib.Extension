using Newtonsoft.Json;

namespace TwitchLib.Extension.Models
{
    public class LiveChannels
    {
        [JsonProperty(PropertyName = "channels")]
        public LiveChannel[] Channels { get; protected set; }
        [JsonProperty(PropertyName = "cursor")]
        public string Cursor { get; protected set; }
    }
}
