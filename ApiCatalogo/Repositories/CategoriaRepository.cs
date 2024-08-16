using ApiCatalogo.Context;
using ApiCatalogo.Models;
using ApiCatalogo.Pagination;

namespace ApiCatalogo.Repositories
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext context) : base(context) { }

        public PagedList<Categoria> GetCategorias(CategoriasParameters categoriasParams)
        {
            var categorias = GetAll().OrderBy(c => c.CategoriaId).AsQueryable();
            var categoriasOrdenadas = PagedList<Categoria>.ToPagedList(categorias, categoriasParams.PageNumber, categoriasParams.PageSize);
            return categoriasOrdenadas;
        }

        public PagedList<Categoria> GetCategoriasFiltroNome(CategoriasFiltroNome categoriasFiltroParams)
        {
            var categorias = GetAll().AsQueryable();

            if (!string.IsNullOrEmpty(categoriasFiltroParams.Nome))
            {
                string nomeFiltro = categoriasFiltroParams.Nome;
                categorias = categorias.Where(c => c.Nome.IndexOf(nomeFiltro, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            var categoriasFiltradas = PagedList<Categoria>.ToPagedList(categorias,
                                       categoriasFiltroParams.PageNumber, categoriasFiltroParams.PageSize);

            return categoriasFiltradas;

        }
    }
}
