using EFCoreFromExistingDB.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EFCoreFromExistingDB.Repositories
{
    internal class LevelRepo
    {
        private readonly Brenda20Context _context;
        public LevelRepo()
        {
            _context = new Brenda20Context();
        }
        public IEnumerable<Level> Get()
        {
            return _context.Level;
        }

        public void Add(Level level)
        {
            _context.Level.Add(level);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var level = new Level() { LevelId = id };
            _context.Entry(_context.Level.FirstOrDefault(l => l.LevelId == id)).State = EntityState.Detached;
            _context.Level.Remove(level);
            _context.SaveChanges();
        }

        public void Update(Level level)
        {
            _context.Entry(_context.Level.FirstOrDefault(l => l.LevelId == level.LevelId)).State = EntityState.Detached;
            _context.Level.Update(level);
            _context.SaveChanges();
        }
    }
}
