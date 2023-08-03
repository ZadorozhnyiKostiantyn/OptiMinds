using Microsoft.EntityFrameworkCore;
using OptiMinds.Application.Common.Persistance;
using OptiMinds.Domain.Common.Models;
using System.Linq.Expressions;

namespace OptiMinds.Infrastructure.Persistance
{
	public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
	{
		private readonly ApplicationDbContext _context;

		public EFRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task AddAsync(TEntity entity)
		{
			await _context.Set<TEntity>().AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var entity = await _context.Set<TEntity>().FindAsync(id);
			_context.Set<TEntity>().Remove(entity);
			await _context.SaveChangesAsync();
		}

		public async Task<List<TEntity>> GetAllAsync()
		{
			return await _context.Set<TEntity>().ToListAsync();
		}

		public async Task<TEntity?> GetByIdAsync(int? id)
		{
			return await _context.Set<TEntity>().FindAsync(id);
		}

		public async Task<List<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> predicate)
		{
			var entities = from e in _context.Set<TEntity>() select e;

			entities = entities.Where(predicate);

			return await entities.ToListAsync();
		}

		public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
		}

		public async Task<TEntity> UpdateAsync(TEntity newData)
		{
			var entity = await _context.Set<TEntity>().FindAsync(newData.Id);
			_context.Entry(entity).CurrentValues.SetValues(newData);
			await _context.SaveChangesAsync();

			return newData;
		}

		public TEntity? GetById(int? id)
		{
			return _context.Set<TEntity>().Find(id);
		}
	}
}
