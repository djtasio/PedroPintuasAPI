using Microsoft.EntityFrameworkCore;
using API_PedroPinturas.Data;
using API_PedroPinturas.DataAccess.Interfaces;
using System.Linq.Expressions;
using API_PedroPinturas.Models;
using System.Linq;

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
        //guardamos cambios
        public async Task Save(){
            await Db.SaveChangesAsync();
        }
        //mostramos todo
        public async Task<IEnumerable<T>> GetAll()
        {
           return await EntitySet.ToListAsync();
        }
        //mostramos todo a partir del orderby
        public async Task<IEnumerable<T>> GetAllOrderBy(Expression<Func<T, string>> orderby)
        {
            return await EntitySet.OrderBy(orderby).ToListAsync();
        }

        // Saca todos los datos de una tabla y las tablas relacionadas a esta que yo le indique por parámetro.
        public async Task<IEnumerable<T>> GetAllInnerJoin(List<string> lista)
        {
            IQueryable<T>? query = EntitySet;
            lista.ForEach(delegate(string model){
                query = query.Include(model);
            });
            return await query.ToListAsync();
        }
        //buscar por id
        public async Task<T> Get(int id)
        {
            return await EntitySet.FindAsync(id);
        }

        //ordenación en base a los parametros que le indico en el controlador
        public async Task<IEnumerable<T>> GetOrderBy(int id,List<string> lista,Expression<Func<T, bool>> expr,Expression<Func<T, DateTime?>> orderby)
        {
             IQueryable<T>? query = EntitySet;
            lista.ForEach(delegate(string model){
                query = query.Include(model);
            });
            return await query.Where(expr).OrderByDescending(orderby).ToListAsync();
        }
        //Saca todos los datos de un objeto en concreto que yo le indique por parámetro.
        public async Task<T> GetInnerJoin(int id,Expression<Func<T, bool>> expr,List<string> lista){
            IQueryable<T>? query = EntitySet;
            foreach(string model in lista){
                query = query.Include(model);
            }
            return await query.FirstOrDefaultAsync(expr);
        }
        //insertar
        public async Task<T> Insert(T entity)
        {
            EntitySet.Add(entity);
            await Save();
            return entity;
        }
        //eliminar
        public async Task<T> Delete(int id)
        {
            T entity = await EntitySet.FindAsync(id);
            EntitySet.Remove(entity);
            await Save();
            return entity;
        }
        //eliminar en cascada
        public async Task<T> DeleteOnCascade(int id,Expression<Func<T, bool>> expr,List<String> lista)
        {
            IQueryable<T>? query = EntitySet;
            foreach(string model in lista){
                query = query.Include(model);
            }
            T entity = await query.Where(expr).FirstOrDefaultAsync();
            EntitySet.RemoveRange(entity);
            await Save();
            return entity;
        }
        //actualizar
        public async Task Update(T entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            //EntitySet.Attach(entity);
            await Save();
        }
        //buscar por parametros
        public async Task<T> Find(Expression<Func<T, bool>> expr)
        {
            // NO LE DA SEGUIMIENTO A LA ENTIDAD QUE NOS VA A REFLEJAR LA CONSULTA
            return await EntitySet.AsNoTracking().FirstOrDefaultAsync(expr);
        }
        //filtramos por fecha
        public async Task<IEnumerable<T>> Filter(Func<T, bool> predicate,List<string> lista)
        {
             IQueryable<T>? query = EntitySet;
            foreach(string model in lista){
                query = query.Include(model);
            }
            return query.AsNoTracking().ToList().Where(predicate);
        }
        //postear/insertar
        public async Task<T> DoEntry(T entity){
             Db.Entry(entity).State = EntityState.Added;
             await Save();
             return entity;
        }
        //postear/insertar
        public async Task<T> DoAttach(T entity){
             EntitySet.AttachRange(entity);
             await Save();
             return entity;
        }
    }
}