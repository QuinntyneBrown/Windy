using Windy.Core.Entities;
using System;

namespace Windy.Api.Features.Addresses
{
    public class AddressDto
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
    }

    public static class AddressExtensions
    {        
        public static AddressDto ToDto(this Address address)
            => new AddressDto
            {
                Street = address.Street,
                City = address.City,
                Province = address.Province,
                PostalCode = address.PostalCode
            };
    }
}
