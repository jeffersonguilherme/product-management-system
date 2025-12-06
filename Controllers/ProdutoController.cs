using Microsoft.AspNetCore.Mvc;
using Services.Produto;

namespace Controllers;

public class ProdutoController : Controller
{
    private readonly IProdutoInterface _produtoInterface;
    public ProdutoController(IProdutoInterface produtoInterface)
    {
        _produtoInterface = produtoInterface;
    }
    public async Task<IActionResult> Index()
    {
        var produtos = await _produtoInterface.ListaProdutos();
        return View(produtos);
    }
}