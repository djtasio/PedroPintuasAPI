using System.Linq.Expressions;

namespace API_PedroPinturas.DataAccess.Interfaces{
    public interface IRepositoryAsync<T> where T : class{
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Insert(T entity);
        Task<T> Delete(int id);
        Task Update(T entity);
        // PARA CONSULTAS AVANZADAS LE PASAMOS LOS PARÁMETROS (WHERE,INNER JOIN ...ETC)
        Task<T> Find(Expression<Func<T, bool>> expr);
        
    }
}