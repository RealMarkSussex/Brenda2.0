using EFCoreFromExistingDB.Models;
using System.Collections.Generic;

namespace EFCoreFromExistingDB.Repositories
{
    internal static class SkillRepo
    {
        public static IEnumerable<Skill> Get()
        {
            var context = new Brenda20Context();
            return context.Skill;
        }

        public static void Add(Skill skill)
        {
            var context = new Brenda20Context();
            context.Skill.Add(skill);
        }

        public static void Delete(Skill skill)
        {
            var context = new Brenda20Context();
            context.Skill.Remove(skill);
        }

        public static void Update(Skill skill)
        {
            var context = new Brenda20Context();
            context.Skill.Update(skill);
        }
    }
}
