using System.Security.Claims;
using BlogEngine.Domain.Services.Interfaces;

namespace BlogEngine.API.Services
{
    public class UserSession : IUserSession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserSession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int? UserId
        {
            get
            {
                var id = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value;
                return id == null ? null : Convert.ToInt32(id);
            }
        }
    }
}