using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Models
{
    public class ServiceSkillLevel
    {
        public int SkillLevelId { get; set; }
        public int SkillId { get; set; }
        public int LevelId { get; set; }
        public string Description { get; set; }
    }
}
