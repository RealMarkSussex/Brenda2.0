using EFCoreFromExistingDB.Models;
using System.Collections.Generic;

namespace EFCoreFromExistingDB.Repositories
{
    internal class UserRepo
    {
        private readonly Brenda20Context _context;
        public UserRepo()
        {
            _context = new Brenda20Context();
        }
        public IEnumerable<User> Get()
        {
            return _context.User;
        }

        public void Add(User user)
        { 
            _context.User.Add(user);
            _context.SaveChanges();
        }

        public void Delete(User user)
        {
            _context.User.Remove(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.User.Update(user);
            _context.SaveChanges();
        }
    }
}
