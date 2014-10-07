using Blogg.Models;
using Blogg.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
/**
 * Tord-Marius Fredriksen @HiN 22.09.14
 * CommentController.cs
 * 
 **/
namespace Blogg.Controllers
{
    public class CommentController : Controller
    {
        private IBlogRepository repository;
        public CommentController()
        {
            repository = new BlogRepository();
        }

        public ActionResult CommentIndex(int id)
        {
            ViewBag.commentParentID = id;
           // ViewBag.blogID = parentID;

            Post post = repository.GetPostWithComments(id);
            return View(new PostCommentViewModels(post));
        }

        public CommentController(IBlogRepository repos)
        {
            repository = repos;

        }
        // GET: Comment
        public ActionResult Index(int? id)
        {
            ViewBag.commentParentID = id;
            return View(repository.GetAllComments(id));
        }

        // GET: Comment/Create
        [HttpGet]
        public ActionResult Create(int? id)
        {
          //  ViewBag.commentParentID = id;
            var comment = new Comment();
            comment.PostID = Convert.ToInt32(id);

            return View(comment);
        }

        // POST: Comment/Create
        [HttpPost]
        public ActionResult Create(Comment c, int id)
        {
            c.PostID = id;
            try
            {
                if (ModelState.IsValid)
                {
                    if (repository.CreateComment(c, id))
                        return RedirectToAction("CommentIndex", "Comment", new { id = c.PostID });
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int? id, int parentID)
        {
            ViewBag.commentParentID = parentID;
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            return View(repository.GetUpdateComment(id));
        }

        // POST: Post/Edit/5
        [HttpPost]
        public ActionResult Edit(Comment comment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (repository.UpdateComment(comment))
                        return RedirectToAction("Index", "Comment", new { id = comment.PostID });
                }
                return View(comment);
            }
            catch
            {
                return View();
            }

        }

        // GET: Post/Delete/5
        public ActionResult Delete(int? id, int? parentID)
        {
            ViewBag.commentParentID = parentID;
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            return View(repository.GetDeleteComment(id));
        }

        // POST: Post/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, Comment c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    if (repository.DeleteComment(id))
                        return RedirectToAction("CommentIndex", id);
                }
                return RedirectToAction("CommentIndex", id);
            }
            catch
            {
                return View();
            }
        }
    }
}
