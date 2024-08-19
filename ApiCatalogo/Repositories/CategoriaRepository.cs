﻿using ApiCatalogo.Context;
using ApiCatalogo.Models;
using ApiCatalogo.Pagination;

namespace ApiCatalogo.Repositories
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext context) : base(context) { }

        public async Task<PagedList<Categoria>> GetCategoriasAsync(CategoriasParameters categoriasParams)
        {
            var categorias = await GetAllAsync();
            var categoriasOrdenadas = categorias.OrderBy(c => c.CategoriaId).AsQueryable();

            var resultado = PagedList<Categoria>.ToPagedList(categoriasOrdenadas, categoriasParams.PageNumber, categoriasParams.PageSize);
            return resultado;
        }

        public async Task<PagedList<Categoria>> GetCategoriasFiltroNomeAsync(CategoriasFiltroNome categoriasFiltroParams)
        {
            var categorias = await GetAllAsync();


            if (!string.IsNullOrEmpty(categoriasFiltroParams.Nome))
            {
                string nomeFiltro = categoriasFiltroParams.Nome;
                categorias = categorias.Where(c => c.Nome.IndexOf(nomeFiltro, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            var categoriasFiltradas =
                PagedList<Categoria>.ToPagedList
                (
                    categorias.AsQueryable(),
                    categoriasFiltroParams.PageNumber,
                    categoriasFiltroParams.PageSize
                );

            return categoriasFiltradas;

        }
    }
}
