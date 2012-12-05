namespace MvcBlog.Models
{
    using System;

    public class Comentario
    {
        public int IdComentario { get; set; }
        public string Autor { get; set; }
        public string Contenido { get; set; }
        public int IdPost { get; set; }
        public DateTime Fecha { get; set; }
    }
}