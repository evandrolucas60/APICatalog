using ApiCatalogo.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiCatalogo.Models;
[Table("Produtos")]
public class Produto : IValidatableObject
{
    [Key]
    public int ProdutoId { get; set; }
    [Required]
    [StringLength(80)]
    //[PrimeiraLetraMaiuscula]
    public string? nome { get; set; }
    [Required]
    [StringLength(300)]
    public string? Descricao { get; set; }
    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Preco { get; set; }
    [Required]
    [StringLength(300)]
    public string? ImagemUrl { get; set; }
    public float Estoque { get; set; }
    public DateTime DataCadastro { get; set; }

    public int CategoriaId { get; set; }

    [JsonIgnore]
    public Categoria? Categoria { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (!string.IsNullOrEmpty(this.nome))
        {
            var primeiraLetra = this.nome[0].ToString();
            if (primeiraLetra != primeiraLetra.ToUpper())
            {
                yield return new ValidationResult("Primeira letra não é maiúscula",
                    new[]
                    {nameof(this.nome)}
                    );
            }

            if (this.Estoque <= 0)
            {
                yield return new ValidationResult("Estoque menor ou igual a zero",
                   new[]
                   {nameof(this.Estoque)}
                   );
            }
        }
    }
}
