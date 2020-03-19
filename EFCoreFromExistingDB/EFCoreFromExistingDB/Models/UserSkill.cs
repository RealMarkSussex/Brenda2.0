using System;
using System.Collections.Generic;

namespace EFCoreFromExistingDB.Models
{
    public partial class UserSkill
    {
        public int UserSkillId { get; set; }
        public int UserId { get; set; }
        public int SkillLevelId { get; set; }

        public virtual User User { get; set; }
    }
}
