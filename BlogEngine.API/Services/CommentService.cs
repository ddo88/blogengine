using AutoMapper;
using BlogEngine.API.Core;
using BlogEngine.API.Entities;
using BlogEngine.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogEngine.API.Services
{
    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment, int> _repository;
        private readonly IRepository<Post, int> _postRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IBlogSession _blogSession;

        public CommentService(IRepository<Comment, int> repository,IRepository<Post, int> postRepository, IUnitOfWork unitOfWork, IMapper mapper, IBlogSession blogSession)
        {
            _repository = repository;
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _blogSession = blogSession;
        }

        public async Task<IEnumerable<CommentDto>> GetAllAsync(int postId)
        {
            var lst = await _repository.GetQueryable()
                                    .Include(x => x.Creator)
                                    .Where(x => x.PostId == postId)
                                    .ToListAsync();
            return _mapper.Map<IEnumerable<CommentDto>>(lst);
        }

        public async Task AddCommentAsync(int postId, CreateCommentDto input)
        {
            var post = await _postRepository.GetAsync(postId);
            if (post == null)
                throw new PostNotFoundException(postId);
            
            if (!post.IsPublish)
                throw new PostNotPublishException(postId);

            var comment = _mapper.Map<Comment>(input);
            comment.CreatorId = _blogSession.UserId.Value;
            post.Comments.Add(comment);
            await _unitOfWork.CompleteAsync();
        }

        
    }
}
