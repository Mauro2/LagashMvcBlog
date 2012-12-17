namespace MvcBlog.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Post
    {
        public int IdPost { get; set; }
        
        [Required(AllowEmptyStrings=false, ErrorMessage="El título no puede ser nulo")]
        public string Titulo { get; set; }
        
        [Required(AllowEmptyStrings=false, ErrorMessage="El contenido no puede ser nulo")]
        [StringLength(10)]
        public string Contenido { get; set; }
        
        public DateTime Fecha { get; set; }
    }
}