using Blogg.Controllers;
using Blogg.Models;
using Blogg.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Blogg.Tests.Controllers
{
    [TestClass]
    public class CommentControllerTest
    {
        public Mock<IBlogRepository> repos;

        [TestInitialize]
        public void Setup()
        {
            repos = new Mock<IBlogRepository>();
        }

        [TestMethod]
        public void CommentTestClosed()
        {
            Post closedPost = new Post { title = "test", Text = "tester", ID = 44, CommentsAllowed = false, BlogID = 1 };
            Comment comment = new Comment { ID = 2, Title = "test", Text = "test", PostID = 44 };

            repos.Setup(x => x.GetPostWithComments(1)).Returns(closedPost);
            repos.Setup(x => x.CreateComment(comment, 3)).Returns(true);

            var controller = new CommentController(repos.Object);

            var result = controller.Create(comment, comment.ID);

            repos.Verify(x => x.CreateComment(comment, comment.PostID));

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
        [TestMethod]
        public void CommentTestOpen()
        {
            Post openPost = new Post { title = "test", Text = "tester", ID = 1, CommentsAllowed = true };
            Comment k = new Comment { ID = 1, Title = "test", Text = "test" };

            repos.Setup(x => x.GetPostWithComments(1)).Returns(openPost);
            repos.Setup(x => x.CreateComment(k,3)).Returns(true);
            
            var controller = new CommentController(repos.Object);

            var result = controller.Create(k, k.ID);

            repos.Verify(x => x.CreateComment(k, k.PostID));

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));

        }
    }
}
