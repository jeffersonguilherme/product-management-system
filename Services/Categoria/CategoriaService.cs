using Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Services.Categoria;

public class CategoriaService : ICategoriaInterface
{

    private readonly DataContext _context;
    public CategoriaService(DataContext context)
    {
        _context = context;
    }
    public async Task<List<CategoriaModel>> BuscarCategorias()
    {
        try
        {
            var categorias = await _context.Categorias.ToListAsync();
            return categorias;
        }catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}