using Resolutions.Server.Model;

namespace Resolutions.Server.Services
{
    public interface IBussinessConfigurationConstantsService
    {
        Task<int> GetConstant(string key);
        Task<IEnumerable<BussinessConfigurationConstant>> GetConstants();
        Task<BussinessConfigurationConstant> CreateConstant(string key, int value);
        Task<BussinessConfigurationConstant> UpdateConstant(string key, int value);
        Task<int> DeleteConstant(string key);
    }
}