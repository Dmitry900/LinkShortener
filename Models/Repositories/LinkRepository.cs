using System.Collections.Generic;
using System.Threading.Tasks;
using LinkShortener.Models;
using Microsoft.EntityFrameworkCore;



namespace LinkShortener.Models
{
    class LinkRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly DbContext context;
        public LinkRepository(DbContext context)
        {
             this.context = context;
        }
        public async Task<bool> IsFind(string link)
        {
            var entity = await context.FindAsync<TEntity>(link);
            if (entity == null)
                return false;
            else return true;
        }

        public async Task<TEntity> Add(TEntity linkEntity)
        {
            context.Set<TEntity>().Add(linkEntity);
            await context.SaveChangesAsync();
            return linkEntity;
        }

        public async Task<TEntity> Delete(int id)
        {
            var linkEntity = await context.Set<TEntity>().FindAsync(id);
            if (linkEntity == null)
            {
                return linkEntity;
            }

            context.Set<TEntity>().Remove(linkEntity);
            await context.SaveChangesAsync();

            return linkEntity;
        }

        public async Task<TEntity> Get(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }
        public async Task<TEntity> Get(string link)
        {
            return await context.Set<TEntity>().FindAsync(link);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }
    }
}