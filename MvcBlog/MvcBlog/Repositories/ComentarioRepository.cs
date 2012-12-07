namespace MvcBlog.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Comentario = MvcBlog.Models.Comentario;

    public class ComentarioRepository : MvcBlogRepositoryBase<Comentario>
    {
        public ComentarioRepository(string connectionString)
            : base(connectionString)
        {
        }

        public override void Create(Comentario instance)
        {
            using (var db = GetDbContext())
            {
                var dbComentario = new MvcBlog.Data.Comentario
                {
                    IdComentario = instance.IdComentario,
                    Autor = instance.Autor,
                    Contenido = instance.Contenido,
                    Fecha = instance.Fecha,
                    IdPost = instance.IdPost,
                };
                db.Comentarios.AddObject(dbComentario);
                db.SaveChanges();
            }
        }

        public override void Update(Comentario instance)
        {
            using (var db = GetDbContext())
            {
                var dbComentario = db.Comentarios.Single(p => p.IdComentario == instance.IdComentario);
                dbComentario.Autor = instance.Autor;
                dbComentario.Contenido = instance.Contenido;
                dbComentario.Fecha = instance.Fecha;
                db.SaveChanges();
            }
        }

        public override void Delete(int id)
        {
            using (var db = GetDbContext())
            {
                var comentario = db.Comentarios.Single(p => p.IdComentario == id);
                db.Comentarios.DeleteObject(comentario);
                db.SaveChanges();
            }
        }

        public override IEnumerable<Comentario> List()
        {
            using (var db = GetDbContext())
            {
                return db.Comentarios.Select(comentario => new Comentario
                {
                    IdComentario = comentario.IdComentario,
                    Autor = comentario.Autor,
                    Contenido = comentario.Contenido,
                    Fecha = comentario.Fecha,
                    IdPost = comentario.IdPost,
                }).ToList();
            }
        }

        public override Comentario Get(int id)
        {
            using (var db = GetDbContext())
            {
                var comentario = db.Comentarios.Single(x => x.IdComentario == id);
                return new Comentario
                {
                    IdComentario = comentario.IdComentario,
                    Autor = comentario.Autor,
                    Contenido = comentario.Contenido,
                    Fecha = comentario.Fecha,
                    IdPost = comentario.IdPost,
                };
            }
        }
    }
}