using Microsoft.EntityFrameworkCore;
using API_PedroPinturas.Data;
using API_PedroPinturas.DataAccess.Interfaces;
using System.Linq.Expressions;

namespace API_PedroPinturas.DataAccess.Servicios{

    public class RespositoryAsync<T> : IRepositoryAsync<T> where T : class{
        private PedroPinturasDb Db;

        public RespositoryAsync(PedroPinturasDb db){
            this.Db = db;
        }

        protected DbSet<T> EntitySet{
            get{
                return Db.Set<T>();
            }
        }

        public async Task Save(){
            await Db.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await EntitySet.ToListAsync();
        }

        public async Task<T> Get(int id)
        {
            return await EntitySet.FindAsync(id);
        }

        public async Task<T> Insert(T entity)
        {
            EntitySet.Add(entity);
            await Save();
            return entity;
        }

        public async Task<T> Delete(int id)
        {
            T entity = await EntitySet.FindAsync(id);
            EntitySet.Remove(entity);
            await Save();
            return entity;
        }

        public async Task Update(T entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            await Save();
        }

        public async Task<T> Find(Expression<Func<T, bool>> expr)
        {
            // NO LE DA SEGUIMIENTO A LA ENTIDAD QUE NOS VA A REFLEJAR LA CONSULTA
            return await EntitySet.AsNoTracking().FirstOrDefaultAsync(expr);
        }
    }
}