using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace Windy.Core.Entities
{
    public class User
    {
        public User()
        {
            Salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(Salt);
            }
        }
        [ForeignKey("Company")]
        public Guid? CompanyId { get; set; }
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public byte[] Salt { get; set; }
        public Company Company { get; set; }
        public ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();


    }
}
