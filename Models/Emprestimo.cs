using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class Emprestimo
    {
        public int EmprestimoId { get; set; }
        public int LivroId { get; set; }
        public Livro Livro { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataEmprestimo { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataDevolucao { get; set; }
    }
}
