using System.ComponentModel.DataAnnotations;

namespace Dto.Produto;

public class ProdutoCriacaoDto
{
    [Required(ErrorMessage = "Digite o Nome!")]
    public string NomeProduto { get; set; } = string.Empty;

    [Required(ErrorMessage = "Digite a Marca!")]
    public string? Marca { get; set; } = string.Empty;

    public string Foto { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Digite o Valor!")]
    public double Valor { get; set; }
    
    [Required(ErrorMessage = "Insira a Quantidade!")]
    public int QuantidadeEstoque { get; set; }
    
    [Required(ErrorMessage = "Selecione a Categoria!")]
    public Guid CategoriaId { get; set; }
}