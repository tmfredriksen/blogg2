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
 * BlogController.cs
 * 
 **/
namespace Blogg.Controllers
{
    public class BlogController : Controller
    {
        private IBlogRepository repository;

        public BlogController()
        {
            repository = new BlogRepository();
        }
        public BlogController(IBlogRepository repos)
        {
            repository = repos;
        }
        // GET: Blog
        public ActionResult Index()
        {
            return View(repository.GetAllBlogs());
        }

        // GET: Blog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Blog blog = repository.ReadBlog(id);
            if (blog == null)
                return HttpNotFound();
            return View(blog);
        }

        // GET: Blog/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blog/Create
        [HttpPost]
        public ActionResult Create(Blog blog)
        {     
            try
            {
                if(ModelState.IsValid)
                {
                    if(repository.CreateBlog(blog))
                    return RedirectToAction("Index");
                }
                // TODO: Add insert logic here
                return View(blog);
            }
            catch
            {
                return View();
            }
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Blog blog = repository.GetUpdateBlog(id);
            if (blog == null)
                return HttpNotFound();
            return View(blog);
        }

        // POST: Blog/Edit/5
        [HttpPost]
        public ActionResult Edit(Blog blog)
        {
            
            try
            {
                if(ModelState.IsValid)
                {

                    if(repository.UpdateBlog(blog))
                   
                    return RedirectToAction("Index");
                }
                return View(blog);
            }
            catch
            {
                return View();
            }
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Blog blog = repository.GetDeleteBlog(id);
            if (blog == null)
                return HttpNotFound();
            return View(blog);
        }

        // POST: Blog/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, Blog blo)
        {
            try
            {              
                if (ModelState.IsValid)
                {
                    if(id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    
                    if(repository.DeleteBlog(id))
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
