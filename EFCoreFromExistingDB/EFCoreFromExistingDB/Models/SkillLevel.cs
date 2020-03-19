using System;
using System.Collections.Generic;

namespace EFCoreFromExistingDB.Models
{
    public partial class SkillLevel
    {
        public int SkillLevelId { get; set; }
        public int SkillId { get; set; }
        public int LevelId { get; set; }
        public string Description { get; set; }

        public virtual Level Level { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
