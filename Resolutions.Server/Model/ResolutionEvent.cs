namespace Resolutions.Server.Model
{
    public class ResolutionEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }

        public int ResolutionId { get; set; }

        public int? ResolutionEventTypeId { get; set; }
        public ResolutionEventType? ResolutionEventType { get; set; }
    }
}
