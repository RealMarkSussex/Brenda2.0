using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreFromExistingDB.Models
{
    public partial class Skill
    {
        public Skill()
        {
            SkillLevel = new HashSet<SkillLevel>();
        }

        [Key]
        [Column("SkillID")]
        public int SkillId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [InverseProperty("Skill")]
        public virtual ICollection<SkillLevel> SkillLevel { get; set; }
    }
}
