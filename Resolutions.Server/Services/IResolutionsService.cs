using Resolutions.Server.Model;

namespace Resolutions.Server.Services
{
    public interface IResolutionsService
    {
        Task<Resolution> CreateResolution(ResolutionCreateDTO resolution, AppUser user);
        Task<IEnumerable<Resolution>> GetUserResolutions(AppUser user);
        Task<Resolution> GetResolutionByID(int id);
        public Task<int> DeleteResolution(int id);
        public Task<bool> UserResolutionExists(AppUser user, string name);
        public Task<bool> ResolutionExists(int id);
        public Task<Resolution> EditResolution(Resolution resolution);
    }
}