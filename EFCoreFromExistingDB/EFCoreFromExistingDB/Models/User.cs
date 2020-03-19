using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreFromExistingDB.Models
{
    public partial class User
    {
        public User()
        {
            UserSkill = new HashSet<UserSkill>();
        }

        [Key]
        [Column("UserID")]
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
        [Column("RoleID")]
        public int RoleId { get; set; }
        [Column("DesiredRoleID")]
        public int DesiredRoleId { get; set; }

        [ForeignKey(nameof(DesiredRoleId))]
        [InverseProperty("UserDesiredRole")]
        public virtual Role DesiredRole { get; set; }
        [ForeignKey(nameof(RoleId))]
        [InverseProperty("UserRole")]
        public virtual Role Role { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<UserSkill> UserSkill { get; set; }
    }
}
