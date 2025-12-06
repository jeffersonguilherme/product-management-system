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
    public async Task<IActionResult> Index()
    {
        var produtos = await _produtoInterface.ListaProdutos();
        return View(produtos);
    }

    public async Task<IActionResult> Cadastrar()
    {
        ViewBag.Categorias = await _categoriaInterface.BuscarCategorias();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar(ProdutoCriacaoDto produtoCriacaoDto, IFormFile foto)
    {
        return View();
    }
}