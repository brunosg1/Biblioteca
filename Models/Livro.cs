using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class Livro
    {
        public int LivroId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        [Column(TypeName = "date")]
        public DateTime Publicacao { get; set; }
        public int AutorId { get; set; }
        public Autor Autor { get; set; }
    }
}
