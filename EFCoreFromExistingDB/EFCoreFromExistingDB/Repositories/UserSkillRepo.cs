using EFCoreFromExistingDB.Models;
using System.Collections.Generic;

namespace EFCoreFromExistingDB.Repositories
{
    internal static class UserSkillRepo
    {
        public static IEnumerable<UserSkill> Get()
        {
            using var context = new Brenda20Context();
            return context.UserSkill;
        }

        public static void Add(UserSkill userSkill)
        {
            using var context = new Brenda20Context();
            context.UserSkill.Add(userSkill);
        }

        public static void Delete(UserSkill userSkill)
        {
            using var context = new Brenda20Context();
            context.UserSkill.Remove(userSkill);
        }

        public static void Update(UserSkill userSkill)
        {
            using var context = new Brenda20Context();
            context.UserSkill.Update(userSkill);
        }
    }
}
