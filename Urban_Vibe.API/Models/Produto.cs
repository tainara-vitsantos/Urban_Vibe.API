
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Urban_Vibe.API.Models;

[Table("Produto")]
public class Produto
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Categoria")]
    [Required(ErrorMessage = "A Categoria é obrigatória")]
    public int CategoriaId { get; set; }
    [ForeignKey("CategoriaId")]
    [Display(Name = "Categoria")]
    public Categoria Categoria { get; set; }

    [StringLength(100)]
    [Required(ErrorMessage = "O Nome é obrigatório")]
    public string Nome { get; set; }

    [StringLength(1000)]
    [Display(Name = "Descrição")]
    public string Descricao { get; set; }

    [StringLength(300)]
    public string Foto { get; set; }

}