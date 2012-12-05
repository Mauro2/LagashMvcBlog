namespace MvcBlog.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using MvcBlog.Data;
    using Post = MvcBlog.Models.Post;

    public class PostRepository
    {
        string _connectionString;

        public PostRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Create(Post post)
        {
            using (var db = GetDbContext())
            {
                var dbPost = new MvcBlog.Data.Post
                {
                    IdPost = post.IdPost,
                    Titulo = post.Titulo,
                    Contenido = post.Contenido,
                    Fecha = post.Fecha,
                };
                db.Posts.AddObject(dbPost);
                db.SaveChanges();
            }
        }

        public void Update(Post post)
        {
            using (var db = GetDbContext())
            {
                var dbPost = db.Posts.Single(p => p.IdPost == post.IdPost);
                dbPost.Titulo = post.Titulo;
                dbPost.Contenido = post.Contenido;
                dbPost.Fecha = post.Fecha;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = GetDbContext())
            {
                var post = db.Posts.Single(p => p.IdPost == id);
                db.Posts.DeleteObject(post);
                db.SaveChanges();
            }
        }

        public IEnumerable<Post> List()
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

        public Post Get(int id)
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

        public DatabaseEntities GetDbContext()
        {
            return new DatabaseEntities(_connectionString);
        }
    }
}