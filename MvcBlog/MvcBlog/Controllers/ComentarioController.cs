namespace MvcBlog.Controllers
{
    using System.Configuration;
    using System.Linq;
    using System.Web.Mvc;
    using MvcBlog.Models;
    using MvcBlog.Repositories;

    public class ComentarioController : Controller
    {
        protected readonly ComentarioRepository comentarioRepository;
        protected readonly PostRepository postRepository;

        public ComentarioController()
        {
            comentarioRepository = new ComentarioRepository(ConfigurationManager.ConnectionStrings["DatabaseEntities"].ConnectionString);
            postRepository = new PostRepository(ConfigurationManager.ConnectionStrings["DatabaseEntities"].ConnectionString);
        }

        public ActionResult GetByPost(string tituloPost, int idPost)
        {
            ViewBag.TituloComentario = tituloPost;

            var comentarios = this.comentarioRepository.GetByPostId(idPost);

            return View(comentarios);
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
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = false });
                }

                this.comentarioRepository.Create(comentario);

                comentario = this.comentarioRepository.List().OrderBy(x => x.IdComentario).Last();

                return Json(new { Result = true, Data = comentario });
            }
            catch
            {
                return Json(new { Result = false });
            }
        }
        
        //
        // GET: /Comentario/Edit/5
        public ActionResult Edit(int id)
        {
            Comentario comentario = this.comentarioRepository.Get(id);

            return View(comentario);
        }

        //
        // POST: /Comentario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Comentario comentario)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(comentario);
                }

                Post post = postRepository.Get(comentario.IdPost);

                this.comentarioRepository.Update(comentario);

                return RedirectToAction("GetByPost", new { tituloPost = post.Titulo, idPost = post.IdPost });
            }
            catch
            {
                return View(comentario);
            }
        }

        //
        // GET: /Comentario/Delete/5
        public ActionResult Delete(int id)
        {
            Comentario comentario = comentarioRepository.Get(id);
            Post post = postRepository.Get(comentario.IdPost);
            comentarioRepository.Delete(id);
            return RedirectToAction("GetByPost", new { tituloPost = post.Titulo, idPost = post.IdPost });
        }
    }
}
