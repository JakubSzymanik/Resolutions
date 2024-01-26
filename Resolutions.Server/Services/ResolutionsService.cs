using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Resolutions.Server.Data;
using Resolutions.Server.Errors;
using Resolutions.Server.Helpers;
using Resolutions.Server.Model;
using Resolutions.Server.Model.DTOs;
using System.Data.Common;

namespace Resolutions.Server.Services
{
    public class ResolutionsService : IResolutionsService
    {
        readonly AppDBContext _context;
        readonly IBussinessConfigurationConstantsService _constantsService;

        public ResolutionsService(AppDBContext context, IBussinessConfigurationConstantsService constantsService)
        {
            _context = context;
            _constantsService = constantsService;
        }

        public async Task<Resolution> GetResolutionByID(int id)
        {
            var res = await _context.Resolutions.FindAsync(id);
            return res;
        }
        public async Task<IEnumerable<Resolution>> GetUserResolutions(AppUser user)
        {
            var userResolutionsQuery = _context.Resolutions.Where(v => v.AppUserId == user.Id);
            return await userResolutionsQuery.ToListAsync();
        }
        public async Task<bool> UserResolutionExists(AppUser user, string name)
        {
            return await _context.Resolutions.Where(v => v.AppUserId == user.Id).AnyAsync(v => v.Name == name);
        }
        public async Task<bool> ResolutionExists(int id)
        {
            return await _context.Resolutions.AnyAsync(r => r.Id == id);
        }
        public async Task<int> GetUserResolutionCount(AppUser user)
        {
            return await _context.Resolutions.Where(v => v.AppUserId != user.Id).CountAsync();
        }

        public async Task<Resolution> CreateResolution(ResolutionCreateDTO resolution, AppUser user)
        {
            int userResCount = await _context.Resolutions.Where(v => v.AppUserId == user.Id).CountAsync();
            int maxUserResCount = 0;

            maxUserResCount = await _constantsService.GetConstant(BussinessConstants.MaxResolutionsPerUser);
            
            if (userResCount >= maxUserResCount)
                throw new LimitExceededException("Max resolutions per user exceeded");

            Resolution res = new Resolution() { AppUserId = user.Id, Name = resolution.Name, CreationDate = DateTime.UtcNow };
            await _context.Resolutions.AddAsync(res);
            await _context.SaveChangesAsync();
            return res;
        }

        public async Task<int> DeleteResolution(int id)
        {
            Resolution? res = await _context.Resolutions.FindAsync(id);
            if (res == null) return 0;

            _context.Resolutions.Remove(res);
            return await _context.SaveChangesAsync();
        }

        public async Task<Resolution> EditResolution(Resolution editedResolution)
        {
            var resolution = await _context.Resolutions.FirstOrDefaultAsync(v=>v.Id == editedResolution.Id);
            if (resolution == null) return null;

            resolution.Name = editedResolution.Name;
   
            await _context.SaveChangesAsync();
            return resolution;
        }
    }
}
