namespace MvcBlog.Controllers
{
    using System.Web.Mvc;
    using MvcBlog.Models;

    public class ComentarioController : Controller
    {
        public ActionResult GetByPost(string tituloPost, int idPost)
        {
            return View();
        }

        //
        // GET: /Comentario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Comentario/Create
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Comentario/Create
        [HttpPost]
        public ActionResult Create(Comentario comentario)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Comentario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Comentario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Comentario comentario)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Comentario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Comentario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Comentario comentario)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
