using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreFromExistingDB.Models
{
    public partial class UserSkill
    {
        [Key]
        [Column("UserSkillID")]
        public int UserSkillId { get; set; }
        [Column("UserID")]
        public int UserId { get; set; }
        [Column("SkillLevelID")]
        public int SkillLevelId { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("UserSkill")]
        public virtual User User { get; set; }
    }
}
