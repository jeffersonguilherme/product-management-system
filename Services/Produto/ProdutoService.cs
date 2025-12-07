using Data;
using Dto.Produto;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using Models;

namespace Services.Produto;

public class ProdutoService : IProdutoInterface
{
    private readonly DataContext _context;
        private readonly string _sistema;
    public ProdutoService(DataContext context, IWebHostEnvironment sistema)
    {
        _context = context;
        _sistema = sistema.WebRootPath;
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

    public async Task<ProdutoModel> Cadastrar(ProdutoCriacaoDto produtoCriacaoDto, IFormFile foto)
    {
        try
        {
            
            var nomeCaminhoImagem = GeraCaminhoArquivo(foto);
            var produto = new ProdutoModel
            {
                NomeProduto = produtoCriacaoDto.NomeProduto,
                Marca = produtoCriacaoDto.Marca,
                Valor = produtoCriacaoDto.Valor,
                CategoriaId  = produtoCriacaoDto.CategoriaId,
                Foto = nomeCaminhoImagem,
                QuantidadeEstoque = produtoCriacaoDto.QuantidadeEstoque
            };

             _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return produto;

        }catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    private string GeraCaminhoArquivo(IFormFile foto)
    {
        var codigoUnico = Guid.NewGuid().ToString();
        var extensao = Path.GetExtension(foto.FileName);
        var nomeSemExt = Path.GetFileNameWithoutExtension(foto.FileName)
                         .Replace(" ", "")
                         .ToLower();

        var nomeCaminhoImagem = $"{nomeSemExt}_{codigoUnico}{extensao}";

        var caminhoParaSalvar = Path.Combine(_sistema, "imagem");

        if (!Directory.Exists(caminhoParaSalvar))
            Directory.CreateDirectory(caminhoParaSalvar);

        var caminhoCompleto = Path.Combine(caminhoParaSalvar, nomeCaminhoImagem);

        using (var stream = File.Create(caminhoCompleto))
        {
            foto.CopyToAsync(stream).Wait();
        }
        return nomeCaminhoImagem;
    }

    public async Task<ProdutoModel> BuscarProdutoPorId(Guid id)
    {
        try
        {
            var produto = await _context.Produtos
                                        .Include(x=> x.Categoria)
                                        .FirstOrDefaultAsync(p=> p.Id == id);

            return produto;
        }catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}