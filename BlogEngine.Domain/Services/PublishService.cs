using AutoMapper;
using BlogEngine.API.Entities;
using BlogEngine.Core;
using BlogEngine.Domain.Models;
using BlogEngine.Domain.Services.Exceptions;
using BlogEngine.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogEngine.API.Services
{
    public class PublishService: IPublishService
    {
        private readonly IRepository<Post, int> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _objMapper;

        public PublishService(IRepository<Post, int> repository, IMapper objMapper,IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _objMapper = objMapper;
        }

        public async Task<IEnumerable<PostDto>> GetAllPendingApprovalPostAsync()
        {
            var lst = await _repository
                                    .GetQueryable()
                                    .Include(x => x.Creator)
                                    .Where(x => !x.IsPublish && x.Status == PostStatus.Submitted)
                                    .ToListAsync();

            return _objMapper.Map<IEnumerable<PostDto>>(lst);
        }

        public async Task ApproveAsync(ApproveDto input)
        {
            var post = await _repository.GetAsync(input.PostId);
            if (post == null)
                throw new PostNotFoundException(input.PostId);

            if (post.Status != PostStatus.Submitted)
                throw new PostStatusNotValidException(post.Status.ToString());

            post.Status      = PostStatus.Publish;
            post.PublishDate = DateTime.Now;
            post.IsPublish = true;
            post.ReasonOfReject = "";

            await _unitOfWork.CompleteAsync();
        }

        public async Task RejectAsync(RejectDto input)
        {
            var post = await _repository.GetAsync(input.PostId);
            if (post == null)
                throw new PostNotFoundException(input.PostId);

            if (post.Status != PostStatus.Submitted)
                throw new PostStatusNotValidException(post.Status.ToString());
            
            post.Status= PostStatus.Created;
            post.ReasonOfReject = input.Message;
            await _unitOfWork.CompleteAsync();
        }
    }
}
