using Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Services.Produto;

public class ProdutoService : IProdutoInterface
{
    private readonly DataContext _context;
    public ProdutoService(DataContext context)
    {
        _context = context;
    }
    public async Task<List<ProdutoModel>> ListaProdutos()
    {
        try
        {
            var produtos = await _context.Produtos.Include(c=> c.Categoria).ToListAsync();
            return produtos;

        }catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}