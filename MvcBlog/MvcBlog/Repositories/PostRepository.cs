namespace MvcBlog.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Post = MvcBlog.Models.Post;

    public class PostRepository : MvcBlogRepositoryBase<Post>
    {
        public PostRepository(string connectionString)
            : base(connectionString)
        {
        }

        public override void Create(Post instance)
        {
            using (var db = GetDbContext())
            {
                var dbPost = new MvcBlog.Data.Post
                {
                    IdPost = instance.IdPost,
                    Titulo = instance.Titulo,
                    Contenido = instance.Contenido,
                    Fecha = instance.Fecha,
                };
                db.Posts.AddObject(dbPost);
                db.SaveChanges();
            }
        }

        public override void Update(Post instance)
        {
            using (var db = GetDbContext())
            {
                var dbPost = db.Posts.Single(p => p.IdPost == instance.IdPost);
                dbPost.Titulo = instance.Titulo;
                dbPost.Contenido = instance.Contenido;
                dbPost.Fecha = instance.Fecha;
                db.SaveChanges();
            }
        }

        public override void Delete(int id)
        {
            using (var db = GetDbContext())
            {
                var post = db.Posts.Single(p => p.IdPost == id);
                db.Posts.DeleteObject(post);
                db.SaveChanges();
            }
        }

        public override IEnumerable<Post> List()
        {
            using (var db = GetDbContext())
            {
                return db.Posts.Select(p => new Post
                                            {
                                                IdPost = p.IdPost,
                                                Titulo = p.Titulo,
                                                Contenido = p.Contenido,
                                                Fecha = p.Fecha,
                                            }).ToList();
            }
        }

        public override Post Get(int id)
        {
            using (var db = GetDbContext())
            {
                var post = db.Posts.Single(x => x.IdPost == id);
                return new Post
                {
                    IdPost = post.IdPost,
                    Titulo = post.Titulo,
                    Contenido = post.Contenido,
                    Fecha = post.Fecha,
                };
            }
        }
    }
}