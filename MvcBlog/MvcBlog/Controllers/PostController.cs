namespace MvcBlog.Controllers
{
    using System;
    using System.Configuration;
    using System.Linq;
    using System.Web.Mvc;
    using MvcBlog.Models;
    using MvcBlog.Repositories;

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
            ViewBag.FraseDelMes = "Me dijo un cliente referido a un competidor: Yo creo que el programador anterior sufría de sordera testicular... O sea oía bien!... pero se hacía el boludo.";
            return View(_postRepository.List().OrderByDescending(x => x.Fecha));
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
            if (!ModelState.IsValid)
            {
                return View(post);
            }

            post.Fecha = DateTime.UtcNow;
            _postRepository.Create(post);

            if (Request.IsAjaxRequest())
            {
                return Json(new { Result = true, Url = Url.Action("Index") });
            }
            else
            {
                return RedirectToAction("Index");
            }
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