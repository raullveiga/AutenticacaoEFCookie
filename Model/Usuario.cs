using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutenticacaoEFCookie.Model
{
    public class Usuario
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 4)]
        public string NomeUsuario { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string EmailUsuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required]
        public ICollection<Permissao> Permissao { get; set; }
    }
}