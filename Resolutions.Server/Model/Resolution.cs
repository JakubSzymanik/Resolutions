using System.ComponentModel.DataAnnotations.Schema;

namespace Resolutions.Server.Model
{
    public class Resolution
    {
        public int Id {  get; set; }
        public string? Name { get; set; }

        public string AppUserId {  get; set; }
    }
}
