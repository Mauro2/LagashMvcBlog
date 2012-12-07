namespace MvcBlog.Repositories
{
    using System.Collections.Generic;
    using MvcBlog.Data;

    public abstract class MvcBlogRepositoryBase<T>
    {
        protected string _connectionString;

        public MvcBlogRepositoryBase(string connectionString)
        {
            _connectionString = connectionString;
        }

        public abstract void Create(T instance);

        public abstract void Update(T instance);

        public abstract void Delete(int id);

        public abstract IEnumerable<T> List();

        public abstract T Get(int id);

        protected DatabaseEntities GetDbContext()
        {
            return new DatabaseEntities(_connectionString);
        }
    }
}