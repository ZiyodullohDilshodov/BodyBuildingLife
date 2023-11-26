using Microsoft.EntityFrameworkCore;
using BodyBuildingLife.Domain.Commons;
using BodyBuildingLife.Data.DbContexts;
using BodyBuildingLife.Data.IRepositories;

namespace BodyBuildingLife.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    AppDbContext _appDbContext;
    DbSet<TEntity> _dbSet;

    public Repository(AppDbContext appDbContext, DbSet<TEntity> dbSet)
    {
        _appDbContext = appDbContext;
        _dbSet = dbSet;
    }

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        var data = await _dbSet.AddAsync(entity);

        await _appDbContext.SaveChangesAsync();
        return data.Entity;
        
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var data = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        _dbSet.Remove(data);

        return await _appDbContext.SaveChangesAsync()>0;
    }

    public async Task<TEntity> GetByIdAsync(long id) 
        => await _dbSet.FirstOrDefaultAsync(x=>x.Id == id);




    public IQueryable<TEntity> RetriveAllAsync()
        => _dbSet;
   


    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var data = _dbSet.Update(entity);
        await _appDbContext.SaveChangesAsync();

        return data.Entity;

    }
}
