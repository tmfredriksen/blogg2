using Blogg.Controllers;
using Blogg.Models;
using Blogg.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Blogg.Tests.Controllers
{
    [TestClass]
    public class BlogControllerTest
    {
        private Mock<IBlogRepository> repos;

        [TestInitialize]
        public void setupindex()
        {
            repos = new Mock<IBlogRepository>();
        }
        [TestMethod]
        public void TestIndexMethod()
        {

            List<Blog> fakeBlogs = new List<Blog> {
                new Blog { Text = "Blog1", Title = "Hey"},
                new Blog {Text ="Blog2", Title = "Hey"}
            };

            repos.Setup(x => x.GetAllBlogs()).Returns(fakeBlogs);
            var controller = new BlogController(repos.Object);

            var result = (ViewResult)controller.Index();

            CollectionAssert.AllItemsAreInstancesOfType((ICollection)result.ViewData.Model, typeof(Blog));
            Assert.IsNotNull(result, "ViewResult is null");
            var op = result.ViewData.Model as List<Blog>;
            Assert.AreEqual(2, op.Count, "Got wrong number of blogs");
        }
    }
}
