using Dto.Produto;
using Microsoft.AspNetCore.Mvc;
using Services.Categoria;
using Services.Produto;

namespace Controllers;

public class ProdutoController : Controller
{
    private readonly IProdutoInterface _produtoInterface;
    private readonly ICategoriaInterface _categoriaInterface;
    public ProdutoController(IProdutoInterface produtoInterface, ICategoriaInterface categoriaInterface)
    {
        _produtoInterface = produtoInterface;
        _categoriaInterface = categoriaInterface;
    }
    public async Task<IActionResult> Index() //retorna apenas a view a pagina com a lista de produtos
    {
        var produtos = await _produtoInterface.ListaProdutos();
        return View(produtos);
    }

    public async Task<IActionResult> Cadastrar()//retorna apenas a view a pagina de cadastros
    {
        ViewBag.Categorias = await _categoriaInterface.BuscarCategorias();
        return View();
    }

    public async Task<IActionResult> Remover(Guid id)
    {
        
        return RedirectToAction("Index", "Produto");
    }

    public async Task<IActionResult> Editar(Guid id)
    {
        var produto = await _produtoInterface.BuscarProdutoPorId(id);

        var editarProdutoDto = new EditarProdutoDto
        {
            NomeProduto = produto.NomeProduto,
            Marca = produto.Marca,
            Foto = produto.Foto,
            Valor = produto.Valor,
            QuantidadeEstoque = produto.QuantidadeEstoque,
            CategoriaId = produto.CategoriaId
        };
        
        ViewBag.Categorias = await _categoriaInterface.BuscarCategorias();
        return View(editarProdutoDto);
    }




//-------------------------------------------------------
    [HttpPost]
    public async Task<IActionResult> Cadastrar(ProdutoCriacaoDto produtoCriacaoDto, IFormFile foto)
    {
        if (ModelState.IsValid)
        {
            var produto = await _produtoInterface.Cadastrar(produtoCriacaoDto, foto);
            return RedirectToAction("Index", "Produto");
        }
        else
        {
            ViewBag.Categorias = await _categoriaInterface.BuscarCategorias();
            return View(produtoCriacaoDto);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Editar(EditarProdutoDto editarProdutoDto, IFormFile? foto)
    {
        if (ModelState.IsValid)
        {
            var produto = await _produtoInterface.Editar(editarProdutoDto, foto);
            return RedirectToAction("Index", "Produto");
        }
        else
        {
            ViewBag.Categorias = await _categoriaInterface.BuscarCategorias();
            return View(editarProdutoDto);
        }
    }
}