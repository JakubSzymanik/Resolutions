using Resolutions.Server.Data;
using Resolutions.Server.Helpers;
using Resolutions.Server.Model;
using Resolutions.Server.Errors;
using Microsoft.EntityFrameworkCore;

namespace Resolutions.Server.Services
{
    public class ResolutionEventService : IResolutionEventsService
    {
        readonly AppDBContext _context;
        readonly BussinessConfigurationConstantsService _constantsService;

        public ResolutionEventService(AppDBContext context, BussinessConfigurationConstantsService constantsService)
        {
            _context = context;
            _constantsService = constantsService;
        }

        public async Task<bool> CanCreateResolutionEvent(Resolution resolution)
        {
            throw new NotImplementedException();
        }

        public async Task<ResolutionEvent> CreateResolutionEvent(
            Resolution resolution, 
            ResolutionEvent resolutionEvent, 
            ResolutionEventType eventType = null)
        {
            int eventsThisDay = await _context.Events
                .Where(e => e.ResolutionId == resolution.Id)
                .Where(e => DateTime.Compare(e.CreationDate.Date, DateTime.UtcNow.Date) == 0)
                .CountAsync();
            int maxEventsPerDay = await _constantsService.GetConstant(BussinessConstants.MaxEventsPerDay);
            if (eventsThisDay >= maxEventsPerDay)
                throw new LimitExceededException("Too many events per day");

            resolutionEvent.CreationDate = DateTime.UtcNow;
            resolutionEvent.ResolutionId = resolution.Id;
            if(eventType != null)
            {
                resolutionEvent.ResolutionEventTypeId = eventType.Id;
            }
            _context.Events.Add(resolutionEvent);
            await _context.SaveChangesAsync();
            return resolutionEvent;
        }

        public async Task<ResolutionEventType> CreateResolutionEventType(Resolution resolution, ResolutionEventType eventType)
        {
            throw new NotImplementedException();
        }
    }
}
