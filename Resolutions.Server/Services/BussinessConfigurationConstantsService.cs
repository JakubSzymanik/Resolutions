using Microsoft.EntityFrameworkCore;
using Resolutions.Server.Data;
using Resolutions.Server.Errors;
using Resolutions.Server.Model;

namespace Resolutions.Server.Services
{
    public class BussinessConfigurationConstantsService : IBussinessConfigurationConstantsService
    {
        AppDBContext _context;

        public BussinessConfigurationConstantsService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<int> GetConstant(string key)
        {
            var constant = await _context.ConfigurationConstants.FindAsync(key);
            if (constant == null) throw new CriticalBussinessLogicException("Key not found: " + key);

            return constant.Value;
        }
        public async Task<IEnumerable<BussinessConfigurationConstant>> GetConstants()
        {
            return await _context.ConfigurationConstants.ToListAsync();
        }

        public async Task<BussinessConfigurationConstant> CreateConstant(string key, int value)
        {
            bool exists = await _context.ConfigurationConstants.AnyAsync(v => v.Name == key);
            if (exists)
                throw new DbUpdateException("Key already exists");

            var newConstant = new BussinessConfigurationConstant { Name = key, Value = value };
            await _context.ConfigurationConstants.AddAsync(newConstant);
            await _context.SaveChangesAsync();
            return newConstant;
        }

        public async Task<BussinessConfigurationConstant> UpdateConstant(string key, int value)
        {
            var configConstant = await _context.ConfigurationConstants.FindAsync(key) ?? 
                throw new KeyNotFoundException("Key not found: " + key);
            configConstant.Value = value;
            await _context.SaveChangesAsync();
            return configConstant;
        }

        public async Task<int> DeleteConstant(string key)
        {
            var cofigConstat = await _context.ConfigurationConstants.FindAsync(key);
            if (cofigConstat == null)
                return 0;

            _context.ConfigurationConstants.Remove(cofigConstat);
            return await _context.SaveChangesAsync();
        }
    }
}
