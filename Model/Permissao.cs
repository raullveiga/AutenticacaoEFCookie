using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutenticacaoEFCookie.Model{
    public class Permissao{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPermissao { get; set; }

        [Required]
        public string NomePermissao { get; set; }

        public ICollection<UsuarioPermissao> UsuarioPermissoes { get; set; }
    }
}