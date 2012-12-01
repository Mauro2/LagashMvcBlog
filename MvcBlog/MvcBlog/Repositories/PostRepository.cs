using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcBlog.Models;
using System.Data;

namespace MvcBlog.Repositories
{
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
                db.Posts.AddObject(post);
                db.SaveChanges();
            }
        }

        public void Update(Post post)
        {
            using (var db = GetDbContext())
            {
                db.Posts.Attach(post);
                db.ObjectStateManager.ChangeObjectState(post, EntityState.Modified);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = GetDbContext())
            {
                Post post = db.Posts.Single(p => p.IdPost == id);
                db.Posts.DeleteObject(post);
                db.SaveChanges();
            }
        }

        public IEnumerable<Post> List()
        {
            using (var db = GetDbContext())
            {
                return db.Posts.ToList();
            }
        }

        public Post Get(int id)
        {
            using (var db = GetDbContext())
            {
                return db.Posts.Single(x => x.IdPost == id);
            }
        }

        public DatabaseEntities GetDbContext()
        {
            return new DatabaseEntities(_connectionString);
        }
    }
}