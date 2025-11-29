using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ZeGotao.Models;

[Table("Unidade")]

public class Unidade
{
    [Key]
    public int IdUnidade { get; set; }

    [Required(ErrorMessage = "Campo Obrigatório!")]
    [Display(Name = "Nome da Unidade")]
    [StringLength(150)]
    public string NomeUnidade { get; set; }

    [Required(ErrorMessage = "Campo obrigatório!")]
    [Display(Name = "Endereço")]
    [StringLength(500, ErrorMessage = "Máximo de 500 caracteres.")]
    public string Endereco { get; set; }

    [Required(ErrorMessage = "Campo obrigatório!")]
    [Display(Name = "Telefone")]
    [StringLength(50, ErrorMessage = "Máximo de 50 caracteres.")]
    public string Telefone { get; set; }
}