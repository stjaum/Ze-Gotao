using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ZeGotao.Models
{
    [Table("Usuario")]
    [Index(nameof(Cpf), IsUnique = true)]
    public class Usuario
    {
    
    [Key]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Nome")]
        [StringLength(150)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Email")]
        [StringLength(150)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Senha")]
        [StringLength(150)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "CPF")]
        [StringLength(14)]
        public string Cpf { get; set; }
        
        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Telefone")]
        [StringLength(50, ErrorMessage = "Máximo de 50 caracteres.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Endereço")]
        [StringLength(500, ErrorMessage = "Máximo de 500 caracteres.")]

        public string Endereco { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Data de Nascimento")]

        public DateTime DataNascimento { get; set; }

        [Display(Name = "Tipo de Usuário")]

        public int TipoUsuarioId { get; set; }
        public virtual TipoUsuario? TipoUsuario { get; set; }

        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }

        [Required]
        public int IdVacina { get; set; }
    }
}
