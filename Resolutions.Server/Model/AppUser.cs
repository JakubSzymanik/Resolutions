using Microsoft.AspNetCore.Identity;
using System.Collections;

namespace Resolutions.Server.Model
{
    public class AppUser : IdentityUser
    {
        public IList<Resolution>? Resolutions { get; set; }
    }
}
