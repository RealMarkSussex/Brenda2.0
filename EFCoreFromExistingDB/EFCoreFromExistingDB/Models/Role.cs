using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreFromExistingDB.Models
{
    public partial class Role
    {
        public Role()
        {
            UserDesiredRole = new HashSet<User>();
            UserRole = new HashSet<User>();
        }

        [Key]
        [Column("RoleID")]
        public int RoleId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Department { get; set; }

        [InverseProperty(nameof(User.DesiredRole))]
        public virtual ICollection<User> UserDesiredRole { get; set; }
        [InverseProperty(nameof(User.Role))]
        public virtual ICollection<User> UserRole { get; set; }
    }
}
