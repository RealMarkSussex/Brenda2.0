using EFCoreFromExistingDB.Models;
using System.Collections.Generic;

namespace EFCoreFromExistingDB.Repositories
{
    internal static class UserRepo
    {
        public static IEnumerable<User> Get()
        {
            var context = new Brenda20Context();
            return context.User;
        }

        public static void Add(User user)
        { 
            var context = new Brenda20Context();
            context.User.Add(user);
        }

        public static void Delete(User user)
        {
            var context = new Brenda20Context();
            context.User.Remove(user);
        }

        public static void Update(User user)
        {
            var context = new Brenda20Context();
            context.User.Update(user);
        }
    }
}
