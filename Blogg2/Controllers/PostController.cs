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
 * PostController.cs
 * 
 **/
namespace Blogg.Controllers
{
    public class PostController : Controller
    {
        private BlogRepository repository;

        public PostController()
        {
            repository = new BlogRepository();
        }

        // GET: Post
        public ActionResult Index(int? id)
        {
            ViewBag.parentID = id;
            int parentID = Convert.ToInt32(id);

            return View(repository.GetAllPosts(parentID));
        }
        
        // GET: Post/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Post post = repository.ReadPost(id);
            if (post == null)
                return HttpNotFound();
            return View(post);
        }
        
        // GET: Post/Create
        [HttpGet]
        public ActionResult Create(int? id)
        {
           // int? par = id;
            var post = new Post();
            post.ID = Convert.ToInt32(id);

            return View(post);
        }

        // POST: Post/Create
        [HttpPost]
        public ActionResult Create(Post p, int id)
        {
            p.BlogID = id;
            try
            {
                if (ModelState.IsValid)     
                {
                    if(repository.CreatePost(p))
                    return RedirectToAction("Index", "Post", new { id = id });

                }
                // TODO: Add insert logic here
                return View();
            }
            catch
            {
                return View();    
            }             
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Post post = repository.GetUpdatePost(id);
            if (post == null)
                return HttpNotFound();
            return View(post);
        }

        // POST: Post/Edit/5
        [HttpPost]
        public ActionResult Edit(Post post)
        {
             try
             {
                if(ModelState.IsValid)
                {
                   if(repository.UpdatePost(post))
                    return RedirectToAction("Index", "Post", new { id = post.BlogID });
                }
                return View(post);
            }
            catch
            {
                return View();
            }
        
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Post post = repository.GetDeletePost(id);
            if (post == null)
                return HttpNotFound();
            return View(post);
        }

        // POST: Post/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, Post po)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    
                    if(repository.DeletePost(id))
                        return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
