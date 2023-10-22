using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroCuri.Shared.Entities
{
    public class Comment
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Link ID")]
        public int LinkId { get; set; }

        [Display(Name = "Article ID")]
        public int ArticleId { get; set; }

        [Display(Name = "Photography ID")]
        public int PhotographyId { get; set; }

        [Display(Name = "Fecha de Comentario")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime Fecha_comen { get; set; }

        [Display(Name = "Contenido")]
        [MaxLength(1000, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Contenido { get; set; } = string.Empty;
    }
}
