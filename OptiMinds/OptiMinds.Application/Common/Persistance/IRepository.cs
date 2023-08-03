using OptiMinds.Domain.Common.Models;
using System.Linq.Expressions;

namespace OptiMinds.Application.Common.Persistance
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
	{
		public Task AddAsync(TEntity entity);
		public Task DeleteAsync(int id);
		public Task<TEntity> UpdateAsync(TEntity newData);
		public Task<TEntity?> GetByIdAsync(int? id);
		public TEntity? GetById(int? id);
		public Task<List<TEntity>> GetAllAsync();
		public Task<List<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> predicate);
		public Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

	}
}
