using AutoMapper;
using Resolutions.Server.Model;
using Resolutions.Server.Model.DTOs;

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
