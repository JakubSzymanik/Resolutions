namespace Resolutions.Server.Model
{
    public class ResolutionEventType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsValueBase { get; set; }

        public int ResolutionId { get; set; }
    }
}
