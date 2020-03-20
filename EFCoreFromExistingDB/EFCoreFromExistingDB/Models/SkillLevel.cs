using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreFromExistingDB.Models
{
    public partial class SkillLevel
    {
        [Key]
        [Column("SkillLevelID")]
        public int SkillLevelId { get; set; }
        [Column("SkillID")]
        public int SkillId { get; set; }
        [Column("LevelID")]
        public int LevelId { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [ForeignKey(nameof(LevelId))]
        [InverseProperty("SkillLevel")]
        public virtual Level Level { get; set; }
        [ForeignKey(nameof(SkillId))]
        [InverseProperty("SkillLevel")]
        public virtual Skill Skill { get; set; }
    }
}
