using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vk.Base.Model;
using Vk.Data.Context;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Vk.Data.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseModel
    {
        private readonly VkContext _vkContext;
        public GenericRepository(VkContext vkContext) { 
        
        _vkContext = vkContext;
        
        }


        public void DeleteById(int id)
        {
            var data = _vkContext.Set<TEntity>().FirstOrDefault(x => x.Id == id);
            data.IsDeleted = true;
            data.IsActive = false;
            if (data != null)
            {
                _vkContext.Set<TEntity>().Update(data);
            }
        }

        public List<TEntity> GetAll(params string[] includes)
        {
            var query = _vkContext.Set<TEntity>().AsQueryable();
            if (includes.Any())
            {
                query = includes.Aggregate(query, (current, incl) => current.Include(incl));
            }
            return query.ToList();
        }

        public IQueryable<TEntity> GetAsQueryable(params string[] includes)
        {
            var query = _vkContext.Set<TEntity>().AsQueryable();
            if (includes.Any())
            {
                query = includes.Aggregate(query, (current, incl) => current.Include(incl));
            }
            return query;
        }

        public TEntity GetById(int id, params string[] includes)
        {
            var query =_vkContext.Set<TEntity>().AsQueryable();
            if(includes.Any())
            {
                query=includes.Aggregate(query,(current ,incl)=> current.Include(incl));
            }

            return query.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(TEntity entity)
        {
            entity.IsActive = true;
            entity.CrateDate = DateTime.Now;
            entity.IsDeleted = false;
           _vkContext.Set<TEntity>().Add(entity);
        }

        public void InsertRange(List<TEntity> entity)
        {
          _vkContext.Set<List<TEntity>>().AddRange(entity);
        }


        public void RemoveById(int id)
        {
          var data= _vkContext.Set<TEntity>().FirstOrDefault(x => x.Id == id);
            if (data != null)
            {
                _vkContext.Set<TEntity>().Remove(data);
            }
        }

        public void Update(TEntity entity)
        {
            _vkContext.Set<TEntity>().Update(entity);
            _vkContext.SaveChanges();
        }

        public void UpdateRange(List<TEntity> entity)
        {
            _vkContext.UpdateRange(entity);
            _vkContext.SaveChanges();
        }

        public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> expression, params string[] includes)
        {
            var query = _vkContext.Set<TEntity>().AsQueryable();
            query.Where(expression);
            if (includes.Any())
            {
                query = includes.Aggregate(query, (current, incl) => current.Include(incl));
            }
            return query.ToList();

        }
        public async Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken, params string[] includes)
        {
            var query = _vkContext.Set<TEntity>().AsQueryable();
            if (includes.Any())
            {
                query = includes.Aggregate(query, (current, incl) => current.Include(incl));
            }

            return await query.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
