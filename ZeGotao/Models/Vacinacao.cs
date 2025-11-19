using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using ZeGotao.Models;
[Table("Vacinacao")]
public class Vacinacao
{
    [Key]
    public int IdVacinacao { get; set; }

    [Required]
    public int IdUsuario { get; set; }

    [ForeignKey(nameof(IdUsuario))]
    public Usuario Usuario { get; set; }

    [Required]
    public int IdVacina { get; set; }

    [ForeignKey(nameof(IdVacina))]
    public Vacinas Vacina { get; set; }

    [Required]
    public int IdUnidade { get; set; }

    [ForeignKey(nameof(IdUnidade))]
    public Unidade Unidade { get; set; }

    [Required(ErrorMessage = "Campo Obrigatório!")]
    [StringLength(20)]
    public string Status { get; set; } // VACINADO // ATRASADO
}