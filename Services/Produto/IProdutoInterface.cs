using Models;

namespace Services.Produto;

public interface IProdutoInterface
{
    //Retorno nome e parametros
    Task<List<ProdutoModel>> ListaProdutos();
}