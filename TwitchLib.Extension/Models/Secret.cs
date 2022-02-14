using Newtonsoft.Json;
using System;

namespace TwitchLib.Extension.Models
{
    public class Secret
    {
        public Secret()
        { }

        public Secret(string content, DateTime active, DateTime expires)
        {
            Content = content;
            Active = active;
            Expires = expires;
        }

        [JsonProperty(PropertyName = "active_at")]
        public DateTime Active { get; protected set; }
        [JsonProperty(PropertyName = "content")]
        public string Content { get; protected set; }
        [JsonProperty(PropertyName = "expires_at")]
        public DateTime Expires { get; protected set; }
    }
}
