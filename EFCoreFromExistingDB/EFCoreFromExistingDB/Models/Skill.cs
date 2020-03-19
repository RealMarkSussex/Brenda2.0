using System;
using System.Collections.Generic;

namespace EFCoreFromExistingDB.Models
{
    public partial class Skill
    {
        public Skill()
        {
            SkillLevel = new HashSet<SkillLevel>();
        }

        public int SkillId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<SkillLevel> SkillLevel { get; set; }
    }
}
