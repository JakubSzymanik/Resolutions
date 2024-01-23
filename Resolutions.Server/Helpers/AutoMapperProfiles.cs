using AutoMapper;
using Resolutions.Server.Model;

namespace Resolutions.Server.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Resolution, ResolutionDTO>();
        }
    }
}
