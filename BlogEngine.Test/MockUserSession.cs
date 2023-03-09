using BlogEngine.Domain.Services.Interfaces;

namespace BlogEngine.Test
{
    public class MockUserSession : IUserSession
    {
        public int? UserId => 2;
    }
}
