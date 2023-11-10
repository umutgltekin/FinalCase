using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vk.Base.Model;

namespace Vk.Data.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : BaseModel
    {
        TEntity GetById(int id, params string[] includes );
        Task<TEntity> GetByIdAsync(int id,CancellationToken cancellationToken, params string[] includes );
        void Update(TEntity entity);
        void DeleteById(int id);
        List<TEntity> GetAll(params string[] includes);
        void RemoveById(int id);
        void Insert(TEntity entity);
        void UpdateRange(List<TEntity> entity);
        void InsertRange(List<TEntity> entity);
        IQueryable<TEntity> GetAsQueryable(params string[] includes);
        IEnumerable<TEntity> Where(Expression<Func<TEntity,bool>> expression , params string[] includes);


    }
}
