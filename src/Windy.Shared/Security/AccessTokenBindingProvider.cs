using System;
using System.Collections.Generic;
using System.Text;

namespace Windy.Shared.Security
{
    using System.Threading.Tasks;
    using Microsoft.Azure.WebJobs.Host.Bindings;

    public class AccessTokenBindingProvider : IBindingProvider
    {
        public Task<IBinding> TryCreateAsync(BindingProviderContext context)
        {
            IBinding binding = new AccessTokenBinding();
            return Task.FromResult(binding);
        }
    }
}
