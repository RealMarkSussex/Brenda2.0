using EFCoreFromExistingDB.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EFCoreFromExistingDB.Repositories
{
    internal class UserSkillRepo
    {
        private readonly Brenda20Context _context;
        public UserSkillRepo()
        {
            _context = new Brenda20Context();
        }
        public IEnumerable<UserSkill> Get()
        {
            return _context.UserSkill;
        }

        public void Add(UserSkill userSkill)
        {
            _context.UserSkill.Add(userSkill);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var userSkill = new UserSkill() { UserSkillId = id };
            _context.Entry(_context.UserSkill.FirstOrDefault(us => us.UserSkillId == id)).State = EntityState.Detached;
            _context.UserSkill.Remove(userSkill);
            _context.SaveChanges();
        }

        public void Update(UserSkill userSkill)
        {
            _context.Entry(_context.UserSkill.FirstOrDefault(us => us.UserSkillId == userSkill.UserSkillId)).State = EntityState.Detached;
            _context.UserSkill.Update(userSkill);
            _context.SaveChanges();
        }
    }
}
