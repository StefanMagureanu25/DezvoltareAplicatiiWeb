using IMDB.Data;
using IMDB.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Repositories.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly IMDBContext _IMDBcontext;
        protected readonly DbSet <TEntity> _IMDBtable;

        public GenericRepository (IMDBContext iMDBcontext)
        {
            _IMDBcontext = iMDBcontext;
            _IMDBtable  = _IMDBcontext.Set<TEntity>();
        }

        //Get all data needed implemented from the interface
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _IMDBtable.AsNoTracking().ToListAsync();
        }
        public IQueryable<TEntity> GetAllAsQueryable()
        {
            return _IMDBtable.AsNoTracking();
        }

        //Create new data implementations from the interface
        public void Create(TEntity entity)
        {
            _IMDBtable.Add(entity);
        }
        public async Task CreateAsync(TEntity entity)
        {
            await _IMDBtable.AddAsync(entity);
        }
        public void CreateRange(IEnumerable<TEntity> entities)
        {
            _IMDBtable.AddRange(entities);
        }
        public async Task CreateRangeAsync(IEnumerable<TEntity> entities)
        {
            await _IMDBtable.AddRangeAsync(entities);
        }

        //Update data implementations from the interface
        public void Update(TEntity entity)
        {
            _IMDBtable.Update(entity);
        }
        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _IMDBtable.UpdateRange(entities);
        }

        //Delete data implementations from the interface
        public void Delete(TEntity entity)
        {
            _IMDBtable.Remove(entity);
        }
        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _IMDBtable.RemoveRange(entities);
        }

        //Find data implementations from the interface
        public async Task<IEnumerable<TEntity>> GetByIdRangeAsync(IEnumerable<object> Ids)
        {
            return await _IMDBtable.Where(e => Ids.Contains(e.Id)).ToListAsync();
        }

        public TEntity FindById(object id)
        {
            return _IMDBtable.Find(id);
        }
        public async Task<TEntity> FindByIdAsync(object id)
        {
            return await _IMDBtable.FindAsync(id);
        }

        //Save data implementations from the interface
        public bool Save()
        {
            return _IMDBcontext.SaveChanges() > 0;
        }
        public async Task<bool> SaveAsync()
        {
            return await _IMDBcontext.SaveChangesAsync() > 0;
        }
    }
}
