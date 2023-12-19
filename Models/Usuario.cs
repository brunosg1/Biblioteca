using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(50)]
        public string Senha { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Email { get; set; }

        [Column(TypeName = "date")]
        public DateTime Nascimento { get; set; }


        public bool Adm { get; set; } = false;
    }
}
