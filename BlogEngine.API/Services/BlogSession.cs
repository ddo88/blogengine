using System.Security.Claims;

namespace BlogEngine.API.Services
{
    public class BlogSession : IBlogSession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BlogSession(IHttpContextAccessor httpContextAccessor)
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