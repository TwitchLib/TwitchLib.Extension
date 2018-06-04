using System;

namespace TwitchLib.Extension.Events
{
    public class SecretRotatedEventArgs : EventArgs
    {
        public string NewSecret { get; set; }
        public DateTime Expires { get; set; }

    }
}
