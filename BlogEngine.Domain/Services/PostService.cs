using AutoMapper;
using BlogEngine.API.Entities;
using BlogEngine.Core;
using BlogEngine.Domain.Models;
using BlogEngine.Domain.Services.Exceptions;
using BlogEngine.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogEngine.API.Services
{
    public class PostService : IPostService
    {
        private readonly IRepository<Post, int> _repository;
        private readonly IMapper _objMapper;
        private readonly IUserSession _session;
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IRepository<Post, int> repository, IMapper objMapper,IUserSession session,IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _objMapper = objMapper;
            _session = session;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PostDto>> GetAllPublishPostsAsync()
        {
            var lst = await _repository.GetQueryable().Include(x => x.Creator).Where(x => x.IsPublish).ToListAsync();
            return _objMapper.Map<List<PostDto>>(lst);
        }

        public async Task<IEnumerable<PostFullDto>> GetAllPostsByUserAsync(int userId)
        {
            var lst = await _repository.GetQueryable().Include(x => x.Creator).Where(x => x.CreatorId == userId).ToListAsync();
            return _objMapper.Map<List<PostFullDto>>(lst);
        }

        public async Task<PostDto> CreateAsync(CreatePostDto input)
        {
            var post = _objMapper.Map<Post>(input);
            post.CreatorId = _session.UserId.Value;
            post.IsPublish = false;
            await _repository.CreateAsync(post);
            await _unitOfWork.CompleteAsync();
            return _objMapper.Map<PostDto>(post);
        }

        public async Task<PostDto> UpdateAsync(EditPostDto input)
        {
            var post = await _repository.GetAsync(input.Id);
            if (post == null)
                throw new PostNotFoundException(input.Id);

            if (post.CreatorId != _session.UserId.Value)
                throw new NotTheAuthorOfPostException(input.Id);

            if (post.IsPublish)
                throw new CannotEditPublishedPostException(input.Id);

            if (post.Status != PostStatus.Created)
                throw new CannotEditSubmittedPostException(input.Id);
            
            post.Title= input.Title; 
            post.Content = input.Content;
            await _unitOfWork.CompleteAsync();

            return _objMapper.Map<PostDto>(post);
        }

        public async Task SubmitPostAsync(int postId)
        {
            var post = await _repository.GetAsync(postId);
            if (post == null)
                throw new PostNotFoundException(postId);

            if (post.CreatorId != _session.UserId.Value)
                throw new NotTheAuthorOfPostException(postId);

            if (post.IsPublish)
                throw new CannotSubmitPublishedPostException(postId);

            post.Status = PostStatus.Submitted; 
            await _unitOfWork.CompleteAsync();
        }
    }
}
