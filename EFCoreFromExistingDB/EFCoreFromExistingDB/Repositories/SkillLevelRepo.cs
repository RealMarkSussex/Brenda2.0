using System;
using System.Collections.Generic;
using System.Text;
using EFCoreFromExistingDB.Models;

namespace EFCoreFromExistingDB.Repositories
{
    internal static class SkillLevelRepo
    {
        public static IEnumerable<SkillLevel> Get()
        {
            using var context = new Brenda20Context();
            return context.SkillLevel;
        }

        public static void Add(SkillLevel skillLevel)
        {
            using var context = new Brenda20Context();
            context.SkillLevel.Add(skillLevel);
        }

        public static void Delete(SkillLevel skillLevel)
        {
            using var context = new Brenda20Context();
            context.SkillLevel.Remove(skillLevel);
        }

        public static void Update(SkillLevel skillLevel)
        {
            using var context = new Brenda20Context();
            context.SkillLevel.Update(skillLevel);
        }
    }
}
