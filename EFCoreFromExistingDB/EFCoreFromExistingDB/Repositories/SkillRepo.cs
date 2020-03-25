using EFCoreFromExistingDB.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EFCoreFromExistingDB.Repositories
{
    internal class SkillRepo
    {
        private readonly Brenda20Context _context;
        public SkillRepo()
        {
            _context = new Brenda20Context();
        }
        public IEnumerable<Skill> Get()
        {
            return _context.Skill;
        }

        public void Add(Skill skill)
        {
            _context.Skill.Add(skill);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var skill = new Skill() { SkillId = id };
            _context.Entry(_context.Skill.FirstOrDefault(s => s.SkillId == id)).State = EntityState.Detached;
            _context.Skill.Remove(skill);
            _context.SaveChanges();
        }

        public void Update(Skill skill)
        {
            _context.Entry(_context.Skill.FirstOrDefault(s => s.SkillId == skill.SkillId)).State = EntityState.Detached;
            _context.Skill.Update(skill);
            _context.SaveChanges();
        }
    }
}
