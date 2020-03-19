using System;
using System.Collections.Generic;

namespace EFCoreFromExistingDB.Models
{
    public partial class Role
    {
        public Role()
        {
            UserDesiredRole = new HashSet<User>();
            UserRole = new HashSet<User>();
        }

        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }

        public virtual ICollection<User> UserDesiredRole { get; set; }
        public virtual ICollection<User> UserRole { get; set; }
    }
}
