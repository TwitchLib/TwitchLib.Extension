using System;
using System.Linq;

namespace TwitchLib.Extension
{
    public class RotatedSecretExtension : ExtensionBase
    {
        private readonly System.Timers.Timer _timer;

        public RotatedSecretExtension(ExtensionConfiguration config, int rotationIntervalMinutes = 720) : base(config)
        {
            var secrets = GetExtensionSecretAsync().Result;
            if (secrets != null)
            {
                Secrets = secrets.Secrets.ToList();
            }

            _timer = new System.Timers.Timer(TimeSpan.FromMinutes(rotationIntervalMinutes).TotalMilliseconds);
            _timer.Elapsed += _timer_Elapsed;
            _timer.AutoReset = true;
            _timer.Start();
        }
        
        private async void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var secrets = await CreateExtensionSecretAsync().ConfigureAwait(false);
            Secrets = secrets.Secrets.ToList();
        }
    }
}
