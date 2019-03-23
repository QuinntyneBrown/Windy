using Windy.Core.Entities;
using System;

namespace Windy.Api.Features.Addresses
{
    public class AddressDto
    {        

    }

    public static class AddressExtensions
    {        
        public static AddressDto ToDto(this Address address)
            => new AddressDto
            {

            };
    }
}
