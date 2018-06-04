using System.Linq;
using System.Threading.Tasks;
using TwitchLib.Extension.Models;

namespace TwitchLib.Extension
{
    public class RotatedSecretExtension : ExtensionBase
    {
        private readonly int _interval;

        public RotatedSecretExtension(ExtensionConfiguration config, int rotationIntervalMinutes = 720) : base(config)
        {
            _interval = rotationIntervalMinutes * 1000 * 60;
            var secrets = GetExtensionSecretAsync().GetAwaiter().GetResult();

            if (secrets != null)
                Secrets = secrets.Secrets.ToList();

            Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(_interval);

                    //Until saving of Extension Config is implemented, just get current secret so it can't be lost!
                    //CreateAndSaveNewSecret(await CreateExtensionSecretAsync());

                    CreateAndSaveNewSecret(await GetExtensionSecretAsync());
                }
            });
        }

        private void CreateAndSaveNewSecret(ExtensionSecrets extensionSecrets)
        {
            if (extensionSecrets == null) return;

            // Todo: Save Secret Here - Where?
            // EF allowing end-developer specified providers?

            Secrets = extensionSecrets.Secrets.ToList();
        }
    }
}
