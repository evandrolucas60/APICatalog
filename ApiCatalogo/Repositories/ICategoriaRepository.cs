using ApiCatalogo.Models;
using ApiCatalogo.Pagination;

namespace ApiCatalogo.Repositories
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        Task<PagedList<Categoria>> GetCategoriasAsync(CategoriasParameters categoriasParams);
        Task<PagedList<Categoria>> GetCategoriasFiltroNomeAsync(CategoriasFiltroNome categoriasFiltroParams);
    }
}
