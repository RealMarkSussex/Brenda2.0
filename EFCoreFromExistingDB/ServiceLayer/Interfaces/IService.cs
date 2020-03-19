using System;
using System.Collections.Generic;
using System.Text;
using ServiceLayer.Models;

namespace ServiceLayer.Interfaces
{
    public interface IService
    {
        IEnumerable<ServiceSkill> GetServiceSkills();
    }
}
