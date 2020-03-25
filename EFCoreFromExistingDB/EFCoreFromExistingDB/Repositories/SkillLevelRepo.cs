using EFCoreFromExistingDB.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EFCoreFromExistingDB.Repositories
{
    internal class SkillLevelRepo
    {
        private readonly Brenda20Context _context;

        public SkillLevelRepo()
        {
            _context = new Brenda20Context();
        }
        public IEnumerable<SkillLevel> Get()
        {
            return _context.SkillLevel;
        }

        public void Add(SkillLevel skillLevel)
        {
            _context.SkillLevel.Add(skillLevel);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var skillLevel = new SkillLevel() { SkillLevelId = id };
            _context.Entry(_context.SkillLevel.FirstOrDefault(sl => sl.SkillLevelId == id)).State = EntityState.Detached;
            _context.SkillLevel.Remove(skillLevel);
            _context.SaveChanges();
        }

        public void Update(SkillLevel skillLevel)
        {
            _context.Entry(_context.SkillLevel.FirstOrDefault(sl => sl.SkillLevelId == skillLevel.SkillLevelId)).State = EntityState.Detached;
            _context.SkillLevel.Update(skillLevel);
            _context.SaveChanges();
        }
    }
}
