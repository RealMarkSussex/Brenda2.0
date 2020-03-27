using EFCoreFromExistingDB.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.Models
{
    public class ServiceUser
    {
        public int UserId { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int DesiredRoleId { get; set; }
        public virtual ICollection<UserSkill> UserSkill { get; set; }

    }
}
