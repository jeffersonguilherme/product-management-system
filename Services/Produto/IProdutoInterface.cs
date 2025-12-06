using Dto.Produto;
using Models;

namespace Services.Produto;

public interface IProdutoInterface
{
    //Retorno nome e parametros
    Task<List<ProdutoModel>> ListaProdutos();
    Task<ProdutoModel> Cadastrar(ProdutoCriacaoDto produtoCriacaoDto, IFormFile foto);

}