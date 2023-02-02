using IMDB.Models.Base;

namespace IMDB.Repositories.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        //Get all data needed
        Task<IEnumerable<TEntity>> GetAllAsync();
        public IQueryable<TEntity> GetAllAsQueryable();

        //Create new data
        void Create(TEntity entity);
        Task CreateAsync(TEntity entity);
        void CreateRange(IEnumerable<TEntity> entities);
        Task CreateRangeAsync(IEnumerable<TEntity> entities);

        //Update data
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);

        //Delete data
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);

        //Find data
        Task<IEnumerable<TEntity>> GetByIdRangeAsync(IEnumerable<object> id);
        TEntity FindById(object id);
        Task<TEntity> FindByIdAsync(object id);

        //Save data
        bool Save();
        Task<bool> SaveAsync();
    }
}
