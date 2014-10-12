using Blogg.Models;
using Blogg2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogg.Repository
{
    public class BlogRepository : Blogg.Repository.IBlogRepository
    {
        private DatabaseModel db;

        public BlogRepository()
        {
            db = new DatabaseModel();
        }

        #region blog
        public List<Blog> GetAllBlogs()
        {
            return db.Blogs.ToList();
        }
        
        public bool CreateBlog(Blog blog)
        {
            try
            {
                db.Blogs.Add(blog);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }

        }
        public Blog ReadBlog(int? id)
        {
            return db.Blogs.Find(id);
            
        }
        public Blog GetUpdateBlog(int? id)
        {
            return db.Blogs.Find(id);
        }
        public bool UpdateBlog(Blog blog)
        {
            try
            {
                db.Entry(blog).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;

         
            
        }
        public bool DeleteBlog(int? id)
        {
            try
            {
                db.Blogs.Remove(db.Blogs.Find(id));
                db.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;


        }
        public Blog GetDeleteBlog(int? id)
        {
            return db.Blogs.Find(id);
        }
        #endregion
        #region post

        public Post GetPostWithComments(int id)
        {
            var p = db.Posts
                .Include("Comments")
                .Where(i => i.ID == id).FirstOrDefault();
            return p;
        }

        public List<Post> GetAllPosts(int parentID)
        {
            return db.Posts.Where(i => i.BlogID == parentID).ToList();
        }
        public bool CreatePost(Post post)
        {
            try
            {
                db.Posts.Add(post);
                db.SaveChanges();
            }
            catch {
                return false;
            }
            return true;

        }
        public Post ReadPost(int? id)
        {
            return db.Posts.Find(id);
        }
        public Post GetUpdatePost(int? id)
        {
            return db.Posts.Find(id);
        }
        public bool UpdatePost(Post post)
        {
            try
            {
                db.Entry(post).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            catch {
                return false;
            }
            return true;

          

        }
        public Post GetDeletePost(int? id)
        {
            return db.Posts.Find(id);

        }
        public bool DeletePost(int? id)
        {
            try
            {
                db.Posts.Remove(db.Posts.Find(id));
                db.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion
        #region comment
        public bool CreateComment(Comment comment, int id)
        {
            Post post = db.Posts.Find(id);
            if (post.CommentsAllowed)
            {
                try
                {
                    db.Comments.Add(comment);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
                return false;
           
        }
        public List<Comment> GetAllComments(int? parentID)
        {
            return db.Comments.Where(i => i.PostID == parentID).ToList();
        }

        public Comment GetUpdateComment(int? id)
        {         
            return db.Comments.Find(id);
     
        }
        public bool UpdateComment(Comment comment)
        {
            try
            {
                db.Entry(comment).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;

        }

        public Comment GetDeleteComment(int? id)
        {
            return db.Comments.Find(id);

        }
        public bool DeleteComment(int? id)
        {
            try
            {
                db.Comments.Remove(db.Comments.Find(id));
                db.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;

        }
        #endregion

        #region user

        public User GetUser(string username)
        {
            return db.Users.Find(username);
        }
        
        public User GetUserPW(string pw)
        {
            return db.Users.Find(pw);
        }
        #endregion

    }
}