using Resolutions.Server.Model;

namespace Resolutions.Server.Services
{
    public interface IResolutionEventsService
    {
        public Task<bool> CanCreateResolutionEvent(Resolution resolution);
        public Task<ResolutionEvent> CreateResolutionEvent(Resolution resolution, ResolutionEvent resolutionEvent, ResolutionEventType eventType = null);
        public Task<ResolutionEventType> CreateResolutionEventType(Resolution resolution, ResolutionEventType eventType);
    }
}
