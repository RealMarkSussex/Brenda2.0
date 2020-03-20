using EFCoreFromExistingDB.Models;
using System.Collections.Generic;

namespace EFCoreFromExistingDB.Repositories
{
    internal static class RoleRepo
    {
        public static IEnumerable<Role> Get()
        {
            using var context = new Brenda20Context();
            return context.Role;
        }

        public static void Add(Role role)
        {
            using var context = new Brenda20Context();
            context.Role.Add(role);
        }

        public static void Delete(Role role)
        {
            using var context = new Brenda20Context();
            context.Role.Remove(role);
        }

        public static void Update(Role role)
        {
            using var context = new Brenda20Context();
            context.Role.Update(role);
        }
    }
}
