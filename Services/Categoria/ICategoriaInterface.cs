using Models;

namespace Services.Categoria;

public interface ICategoriaInterface
{
    Task<List<CategoriaModel>> BuscarCategorias();
}