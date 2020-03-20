using EFCoreFromExistingDB.Models;
using System.Collections.Generic;

namespace EFCoreFromExistingDB.Repositories
{
    internal static class LevelRepo
    {
        public static IEnumerable<Level> Get()
        {
            var context = new Brenda20Context();
            return context.Level;
        }

        public static void Add(Level level)
        {
            var context = new Brenda20Context();
            context.Level.Add(level);
        }
        public static void Delete(Level level)
        {
            var context = new Brenda20Context();
            context.Level.Remove(level);
        }

        public static void Update(Level level)
        {
            var context = new Brenda20Context();
            context.Level.Update(level);
        }
    }
}
