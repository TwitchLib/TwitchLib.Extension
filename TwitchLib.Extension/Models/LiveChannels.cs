using Newtonsoft.Json;

namespace TwitchLib.Extension.Models
{
    public partial class LiveChannels
    {
        [JsonProperty(PropertyName = "channels")]
        public LiveChannel[] Channels { get; protected set; }
        [JsonProperty(PropertyName = "cursor")]
        public string Cursor { get; protected set; }
    }

    public partial class LiveChannels
    {
        public static LiveChannels FromJson(string json) => JsonConvert.DeserializeObject<LiveChannels>(json, TwitchLibJsonSerializer.Settings);
    }
}
