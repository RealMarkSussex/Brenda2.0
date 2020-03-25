using EFCoreFromExistingDB.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EFCoreFromExistingDB.Repositories
{
    internal class RoleRepo
    {
        private readonly Brenda20Context _context;
        public RoleRepo()
        {
            _context = new Brenda20Context();
        }
        public IEnumerable<Role> Get()
        {
            return _context.Role;
        }

        public void Add(Role role)
        {
            _context.Role.Add(role);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var role = new Role() { RoleId = id };
            _context.Entry(_context.Role.FirstOrDefault(r => r.RoleId == id)).State = EntityState.Detached;
            _context.Role.Remove(role);
            _context.SaveChanges();
        }

        public void Update(Role role)
        {
            _context.Entry(_context.Role.FirstOrDefault(r => r.RoleId == role.RoleId)).State = EntityState.Detached;
            _context.Role.Update(role);
            _context.SaveChanges();
        }
    }
}
