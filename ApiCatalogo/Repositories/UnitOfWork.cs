using ApiCatalogo.Context;

namespace ApiCatalogo.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IProdutoRepository? _produtoRepository;
        private ICategoriaRepository? _categoriaRepository;

        public AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IProdutoRepository ProdutoRepository
        {
            get
            {
                return _produtoRepository = _produtoRepository ?? new ProdutoRepository(_context);

                //if (_produtoRepository is null)
                //{
                //    _produtoRepository = new ProdutoRepository(_context);
                //}
                //return _produtoRepository;
            }
        }

        public ICategoriaRepository CategoriaRepository
        {
            get
            {
                return _categoriaRepository = _categoriaRepository ?? new CategoriaRepository(_context);
            }
        }

        public async Task CommitAsync()
        {
           await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
