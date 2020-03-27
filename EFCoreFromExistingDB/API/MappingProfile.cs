using AutoMapper;
using EFCoreFromExistingDB.Models;
using ServiceLayer.Models;

namespace API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Skill, ServiceSkill>().ReverseMap();
            CreateMap<User, ServiceUser>().ReverseMap();
            CreateMap<SkillLevel, ServiceSkillLevel>().ReverseMap();
            CreateMap<Role, ServiceRole>().ReverseMap();
            CreateMap<Level, ServiceLevel>().ReverseMap();
        }
    }
}
