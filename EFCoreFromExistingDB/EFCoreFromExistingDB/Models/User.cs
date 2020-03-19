using System;
using System.Collections.Generic;

namespace EFCoreFromExistingDB.Models
{
    public partial class User
    {
        public User()
        {
            UserSkill = new HashSet<UserSkill>();
        }

        public int UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int DesiredRoleId { get; set; }
        public string Picture { get; set; }

        public virtual Role DesiredRole { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<UserSkill> UserSkill { get; set; }
    }
}
