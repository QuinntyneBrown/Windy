namespace Windy.Shared.Security
{
    using Microsoft.Azure.WebJobs.Host.Config;

    public class AccessTokenExtensionProvider : IExtensionConfigProvider
    {
        public void Initialize(ExtensionConfigContext context)
        {
            var provider = new AccessTokenBindingProvider();
            _ = context.AddBindingRule<AccessTokenAttribute>().Bind(provider);
        }
    }
}
