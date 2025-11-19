using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZeGotao.Models;

[Table("DependenteUsuario")]
[Index(nameof(Cpf), IsUnique = true)]
public class DependenteUsuario
{
    [Key]
    public int IdDependenteUsuario { get; set; }

    [Required]
    public int IdUsuario { get; set; }

    [ForeignKey(nameof(IdUsuario))]
    public Usuario Usuario { get; set; }

    [Required(ErrorMessage = "Campo obrigatório!")]
    [Display(Name = "Nome do Dependente")]
    [StringLength(150)]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Campo obrigatório!")]
    [Display(Name = "Tipo de Usuário")]
    [StringLength(14)]
    public string Cpf { get; set; }

    [Required(ErrorMessage = "Campo Obrigatório!")]
    [Display(Name = "Data de Nascimento")]

    public DateTime DataNascimento { get; set; }
}