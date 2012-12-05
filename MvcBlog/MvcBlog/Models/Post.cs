namespace MvcBlog.Models
{
    using System;

    public class Post
    {
        public int IdPost { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public DateTime Fecha { get; set; }
    }
}