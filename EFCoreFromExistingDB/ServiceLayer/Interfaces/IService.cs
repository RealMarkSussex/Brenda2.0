using ServiceLayer.Models;
using System.Collections.Generic;

namespace ServiceLayer.Interfaces
{
    public interface IService
    {
        IEnumerable<ServiceSkill> GetServiceSkills();
    }
}
