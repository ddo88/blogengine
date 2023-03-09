using AutoMapper;
using BlogEngine.API.Entities;
using BlogEngine.Core;
using BlogEngine.Domain.Models;
using BlogEngine.Domain.Services.Exceptions;
using BlogEngine.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogEngine.API.Services
{
    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment, int> _repository;
        private readonly IRepository<Post, int> _postRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _objMapper;
        private readonly IUserSession _userSession;

        public CommentService(IRepository<Comment, int> repository,IRepository<Post, int> postRepository, IUnitOfWork unitOfWork, IMapper objMapper, IUserSession userSession)
        {
            _repository = repository;
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
            _objMapper = objMapper;
            _userSession = userSession;
        }

        public async Task<IEnumerable<CommentDto>> GetAllAsync(int postId)
        {
            var lst = await _repository.GetQueryable()
                                    .Include(x => x.Creator)
                                    .Where(x => x.PostId == postId)
                                    .ToListAsync();
            return _objMapper.Map<IEnumerable<CommentDto>>(lst);
        }

        public async Task AddCommentAsync(int postId, CreateCommentDto input)
        {
            var post = await _postRepository.GetQueryable()
                                            .Include(x=>x.Comments)
                                            .FirstOrDefaultAsync(x=>x.Id==postId);
            if (post == null)
                throw new PostNotFoundException(postId);
            
            if (!post.IsPublish)
                throw new PostNotPublishException(postId);

            var comment = _objMapper.Map<Comment>(input);

            
            comment.CreatorId = _userSession.UserId.Value;
            post.Comments.Add(comment);
            await _unitOfWork.CompleteAsync();
        }
    }
}
