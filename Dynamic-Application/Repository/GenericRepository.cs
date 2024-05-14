using Dynamic_Application.AppContext;
using Dynamic_Application.Common;
using Dynamic_Application.Enum;
using Dynamic_Application.model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq.Expressions;

namespace Dynamic_Application.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ApplicationData _context;

        protected GenericRepository(ApplicationData context)
        {
            _context = context;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public async Task<TEntity?> GetAsync()
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync();
        }

        public TEntity? Get()
        {
            return _context.Set<TEntity>().FirstOrDefault();
        }

        public TEntity? Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).FirstOrDefault();
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<TEntity?> GetLastAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).LastOrDefaultAsync();
        }

        public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, object>>? includePredicate = null)
        {
            return (includePredicate != null) ? (await _context.Set<TEntity>().Include(includePredicate).ToListAsync()) : (await _context.Set<TEntity>().ToListAsync());
        }

        public async Task InsertAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            SaveDbLog(DbLogType.Insert, entity);
        }

        public async Task InsertAsync(IEnumerable<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
            foreach (TEntity entity in entities)
            {
                SaveDbLog(DbLogType.Insert, entity);
            }
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            SaveDbLog(DbLogType.Delete, entity);
        }

        public void Delete(TEntity[] entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
            foreach (TEntity entity in entities)
            {
                SaveDbLog(DbLogType.Delete, entity);
            }
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            SaveDbLog(DbLogType.Update, entity);
        }

        public bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Any(predicate);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().UpdateRange(entities);
            foreach (TEntity entity in entities)
            {
                SaveDbLog(DbLogType.Update, entity);
            }
        }


        private void SaveDbLog(DbLogType logType, TEntity entity)
        {
            DataBaseLog entity2 = new DataBaseLog
            {
                Id = entity.Id,
                LogType = logType.ToString(),
                EntityClass = typeof(TEntity).Name,
                Value = JsonConvert.SerializeObject(entity, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                })
            };
            _context.Set<DataBaseLog>().Add(entity2);
        }
    }
}