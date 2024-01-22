using Resolutions.Server.Model;

namespace Resolutions.Server.Services
{
    public interface IJWTService
    {
        string CreateToken(AppUser user);
    }
}