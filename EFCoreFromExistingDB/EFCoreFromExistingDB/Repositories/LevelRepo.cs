using EFCoreFromExistingDB.Models;
using System.Collections.Generic;

namespace EFCoreFromExistingDB.Repositories
{
    internal static class LevelRepo
    {
        public static IEnumerable<Level> Get()
        {
            using var context = new Brenda20Context();
            return context.Level;
        }

        public static void Add(Level level)
        {
            using var context = new Brenda20Context();
            context.Level.Add(level);
        }

        public static void Delete(Level level)
        {
            using var context = new Brenda20Context();
            context.Level.Remove(level);
        }

        public static void Update(Level level)
        {
            using var context = new Brenda20Context();
            context.Level.Update(level);
        }
    }
}
