using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EFCoreFromExistingDB.Models;

namespace ServiceLayer.Models
{
    public class ServiceSkill
    {
        public int SkillId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
        public virtual ICollection<SkillLevel> SkillLevel { get; set; }
        public string Level1Description { get; set; }
        public string Level2Description { get; set; }
        public string Level3Description { get; set; }
        public string Level4Description { get; set; }

    }
}
