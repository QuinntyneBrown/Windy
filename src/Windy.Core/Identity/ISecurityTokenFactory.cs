using System;
using System.Collections.Generic;
using System.Text;

namespace Windy.Core.Identity
{
    public interface ISecurityTokenFactory
    {
        string Create(Guid userId, string uniqueName);
    }
}
