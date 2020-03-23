using ServiceLayer.Models;
using System.Collections.Generic;

namespace ServiceLayer.Interfaces
{
    public interface IService
    {
        IEnumerable<ServiceSkill> GetServiceSkills();
        IEnumerable<ServiceUser> GetUsers();
        void Add(ServiceUser user);
        void Delete(int id);
        void Update(ServiceUser user);

    }
}
