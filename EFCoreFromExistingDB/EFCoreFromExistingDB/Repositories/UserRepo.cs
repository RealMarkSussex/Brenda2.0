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
        ~UserRepo()
        {
            _context.SaveChanges();
        }
        public IEnumerable<User> Get()
        {
            return _context.User;
        }

        public void Add(User user)
        { 
            _context.User.Add(user);
        }

        public void Delete(User user)
        {
            var context = new Brenda20Context();
            context.User.Remove(user);
        }

        public void Update(User user)
        {
            var context = new Brenda20Context();
            context.User.Update(user);
        }
    }
}
