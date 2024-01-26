using Resolutions.Server.Model;
using Resolutions.Server.Model.DTOs;

namespace Resolutions.Server.Services
{
    public interface IResolutionsService
    {
        Task<IEnumerable<Resolution>> GetUserResolutions(AppUser user);
        Task<Resolution> GetResolutionByID(int id);
        Task<bool> UserResolutionExists(AppUser user, string name);
        Task<bool> ResolutionExists(int id);
        Task<int> GetUserResolutionCount(AppUser user);
        Task<Resolution> CreateResolution(ResolutionCreateDTO resolution, AppUser user); //do poprawy, dać w argumencie model
        Task<Resolution> EditResolution(Resolution resolution);
        Task<int> DeleteResolution(int id);
    }
}