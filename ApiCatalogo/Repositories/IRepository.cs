using ApiCatalogo.Models;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.X86;

namespace ApiCatalogo.Repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();

        //<Func<T, bool>> predicate: Este parâmetro aceita uma expressão lambda que representa uma função que recebe um objeto do tipo T e retorna um valor booleano(true ou false)
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
        T Create(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}
