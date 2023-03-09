using AutoMapper;
using BlogEngine.API.Controllers;
using BlogEngine.API.Entities;
using BlogEngine.API.Models;

namespace BlogEngine.API.Profiles
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Post, PostDto>().ForMember(x=>x.Author, o=>o.MapFrom(y=>y.Creator.FullName));
            CreateMap<Post, PostFullDto>().ForMember(x => x.Author, o => o.MapFrom(y => y.Creator.FullName));
            
            CreateMap<CreatePostDto, Post>();
            CreateMap<EditPostDto, Post>();
            

            CreateMap<CreateCommentDto,Comment>();
            CreateMap<Comment, CommentDto>().ForMember(x => x.Author, o => o.MapFrom(y => y.Creator.FullName));


        }
    }
}
