using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreFromExistingDB.Models
{
    public partial class Level
    {
        public Level()
        {
            SkillLevel = new HashSet<SkillLevel>();
        }

        [Key]
        [Column("LevelID")]
        public int LevelId { get; set; }
        public int LevelNumber { get; set; }

        [InverseProperty("Level")]
        public virtual ICollection<SkillLevel> SkillLevel { get; set; }
    }
}
