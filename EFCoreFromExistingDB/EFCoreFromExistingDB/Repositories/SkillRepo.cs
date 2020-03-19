using System;
using System.Collections.Generic;
using System.Text;
using EFCoreFromExistingDB.Models;

namespace EFCoreFromExistingDB.Repositories
{
    internal static class SkillRepo
    {
        public static IEnumerable<Skill> Get()
        {
            using var context = new Brenda20Context();
            return context.Skill;
        }

        public static void Add(Skill skill)
        {
            using var context = new Brenda20Context();
            context.Skill.Add(skill);
        }

        public static void Delete(Skill skill)
        {
            using var context = new Brenda20Context();
            context.Skill.Remove(skill);
        }

        public static void Update(Skill skill)
        {
            using var context = new Brenda20Context();
            context.Skill.Update(skill);
        }
    }
}
