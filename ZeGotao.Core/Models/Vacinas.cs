using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZeGotao.Models;

[Table("Vacinas")]

public class Vacinas
{
    [Key]
    public int IdVacina { get; set; }

    [Required(ErrorMessage = "Campo Obrigatório!")]
    [Display(Name = "Nome da Vacina")]
    [StringLength(150)]
    public string NomeVacina { get; set; }

    [Required(ErrorMessage = "Campo Obrigatório!")]
    [Display(Name = "Descrição da Vacina")]
    [StringLength(900)]
    public string DescricaoVacina { get; set; }

    [Required(ErrorMessage = "Campo Obrigatório!")]
    [Display(Name = "Faixa Etária")]
    [StringLength(20)]
    public string FaixaEtaria { get; set; }
}