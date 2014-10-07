using System;
namespace Blogg.Repository
{
    public interface IBlogRepository
    {
        bool CreateBlog(Blogg.Models.Blog blog);
        bool CreateComment(Blogg.Models.Comment comment, int id);
        bool CreatePost(Blogg.Models.Post post);
        bool DeleteBlog(int? id);
        bool DeleteComment(int? id);
        bool DeletePost(int? id);
        System.Collections.Generic.List<Blogg.Models.Blog> GetAllBlogs();
        System.Collections.Generic.List<Blogg.Models.Comment> GetAllComments(int? parentID);
        System.Collections.Generic.List<Blogg.Models.Post> GetAllPosts(int parentID);
        Blogg.Models.Blog GetDeleteBlog(int? id);
        Blogg.Models.Comment GetDeleteComment(int? id);
        Blogg.Models.Post GetDeletePost(int? id);
        Blogg.Models.Post GetPostWithComments(int id);
        Blogg.Models.Blog GetUpdateBlog(int? id);
        Blogg.Models.Comment GetUpdateComment(int? id);
        Blogg.Models.Post GetUpdatePost(int? id);
        Blogg.Models.Blog ReadBlog(int? id);
        Blogg.Models.Post ReadPost(int? id);
        bool UpdateBlog(Blogg.Models.Blog blog);
        bool UpdateComment(Blogg.Models.Comment comment);
        bool UpdatePost(Blogg.Models.Post post);
    }
}
