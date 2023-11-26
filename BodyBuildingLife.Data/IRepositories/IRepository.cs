namespace BodyBuildingLife.Data.IRepositories;

public  interface IRepository<TEntity>
{
    Task<bool> DeleteAsync(long  id);
    Task<TEntity> GetByIdAsync(long  id);
    IQueryable<TEntity> RetriveAllAsync();
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<TEntity> CreateAsync(TEntity entity);
}
