using System;
using System.Collections.Generic;

namespace EFCoreFromExistingDB.Models
{
    public partial class Level
    {
        public Level()
        {
            SkillLevel = new HashSet<SkillLevel>();
        }

        public int LevelId { get; set; }
        public int LevelNumber { get; set; }

        public virtual ICollection<SkillLevel> SkillLevel { get; set; }
    }
}
