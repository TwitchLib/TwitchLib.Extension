using System;
using System.Linq;
using System.Threading.Tasks;
using TwitchLib.Extension.Events;

namespace TwitchLib.Extension
{
    public class RotatedSecretExtension : ExtensionBase
    {
        private readonly int _interval;
        public event EventHandler<SecretRotatedEventArgs> SecretRotated;

        public RotatedSecretExtension(ExtensionConfiguration config, int rotationIntervalMinutes = 720) : base(config)
        {
            _interval = rotationIntervalMinutes * 1000 * 60;
            var secretsData = GetExtensionSecretAsync().GetAwaiter().GetResult();
            if (secretsData != null)
                Secrets = secretsData.Data.SelectMany(x => x.Secrets).ToList();

            Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(_interval);

                    if (SecretRotated != null)
                    {
                        secretsData = await CreateExtensionSecretAsync();
                        if (secretsData == null) return;

                        Secrets = secretsData.Data.SelectMany(x => x.Secrets).ToList();
                        var currentSecret = Secrets.ToList().OrderByDescending(x => x.Expires).First();
                        OnSecretRotated(new SecretRotatedEventArgs
                        {
                            NewSecret = currentSecret.Content,
                            Expires = currentSecret.Expires
                        });
                    }
                }
            });
        }

        protected virtual void OnSecretRotated(SecretRotatedEventArgs e)
        {
            SecretRotated?.Invoke(this, e);
        }
    }
}
