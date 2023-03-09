﻿using BlogEngine.API.Models;

namespace BlogEngine.API.Services
{
    public interface IPostService
    {
        Task<PostDto> CreateAsync(CreatePostDto input);
        Task<PostDto> UpdateAsync(EditPostDto input);
        Task<IEnumerable<PostFullDto>> GetAllPostsByUserAsync(int userId);
        Task<IEnumerable<PostDto>> GetAllPublishPostsAsync();
        Task SubmitPostAsync(int postId);
    }
}