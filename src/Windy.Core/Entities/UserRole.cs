using System;

namespace Windy.Core.Entities
{
    public class UserRole
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
        public User User { get; set; }
    }
}