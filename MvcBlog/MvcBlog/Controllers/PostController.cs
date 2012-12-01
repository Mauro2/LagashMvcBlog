using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBlog.Models;
using MvcBlog.Repositories;
using System.Configuration;

namespace MvcBlog.Controllers
{ 
    public class PostController : Controller
    {
        protected readonly PostRepository _postRepository;

        public PostController()
        {
            _postRepository = new PostRepository(ConfigurationManager.ConnectionStrings["DatabaseEntities"].ConnectionString);
        }

        //
        // GET: /Post/

        public ViewResult Index()
        {
            return View(_postRepository.List());
        }

        //
        // GET: /Post/Details/5

        public ViewResult Details(int id)
        {
            Post post = _postRepository.Get(id);
            return View(post);
        }

        //
        // GET: /Post/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Post/Create

        [HttpPost]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                _postRepository.Create(post);
                return RedirectToAction("Index");  
            }

            return View(post);
        }
        
        //
        // GET: /Post/Edit/5
 
        public ActionResult Edit(int id)
        {
            Post post = _postRepository.Get(id);
            return View(post);
        }

        //
        // POST: /Post/Edit/5

        [HttpPost]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                _postRepository.Update(post);
                return RedirectToAction("Index");
            }
            return View(post);
        }

        //
        // GET: /Post/Delete/5
 
        public ActionResult Delete(int id)
        {
            Post post = _postRepository.Get(id);
            return View(post);
        }

        //
        // POST: /Post/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _postRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}