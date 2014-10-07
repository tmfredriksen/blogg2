using Blogg.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogg.Models
{
    public class PostCommentViewModels
    {
        private IBlogRepository myRepository = new BlogRepository();
        public IEnumerable<Comment> comments = new List<Comment>();
        public Post post;

        public PostCommentViewModels(Post post) 
        {
            this.post = post;
            myRepository.GetPostWithComments(post.ID);
        }
    }
}