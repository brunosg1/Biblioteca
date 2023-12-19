using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class Autor
    {
        public int AutorId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }
        public List<Livro> Livros { get; set; }
    }
}
