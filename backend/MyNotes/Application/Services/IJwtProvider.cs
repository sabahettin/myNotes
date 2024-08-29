using Domain.Entities;

namespace Application.Services
{
    public interface IJwtProvider
    {
        string CreateToken(AppUser user);
    }
}
