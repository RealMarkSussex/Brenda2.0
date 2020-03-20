using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EFCoreFromExistingDB.Models;
using ServiceLayer.Models;

namespace API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Skill, ServiceSkill>();
        }
    }
}
