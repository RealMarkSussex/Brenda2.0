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
            CreateMap<User, ServiceUser>();
        }
    }
}
