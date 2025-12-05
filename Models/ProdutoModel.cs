using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Models;

public class ProdutoModel
{
    public Guid Id { get; set; }
    public string NomeProduto { get; set; } = string.Empty;
    public string Marca { get; set; } = string.Empty;
    public string Foto { get; set; } = string.Empty;
    public double Valor { get; set; }
    public int QuantidadeEstoque { get; set; }
    public Guid CategoriaId { get; set; }
    [ValidateNever]
    public CategoriaModel? Categoria { get; set; }
}