using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZeGotao.Models
{
    [Table("TipoUsuario")]
    public class TipoUsuario
    {
        [Key]
        public int IdTipoUsuario { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Tipo de Usuário")]
        [StringLength(150)]
        public string DescricaoTipoUsuario { get; set; }

        public List<Usuario> Usuarios { get; set; }
    }
}
