using BlogEngine.API.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlogEngine.API.Core
{
    public class Repository<T, U> : IRepository<T, U> where T : class, IEntity<U>
    {
        private readonly BlogEngineContext _context;
        private readonly DbSet<T> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public Repository(BlogEngineContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _repository = context.Set<T>();
            _unitOfWork = unitOfWork;
        }

        public IQueryable<T> GetQueryable()
        {
            return _repository.AsQueryable<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _repository.ToListAsync();

        public async Task<T?> GetAsync(U Id)=>await _repository.FirstOrDefaultAsync(CreateEqualityExpressionForId(Id));

        public async Task<T> CreateAsync(T entity)
        {
            await _repository.AddAsync(entity);
            
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            if (await _repository.FirstOrDefaultAsync(CreateEqualityExpressionForId(entity.Id)) == null)
                throw new Exception();

            _repository.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            await _unitOfWork.CompleteAsync();

            return entity; 
        }
        public async Task DeleteAsync(U Id)
        {
            var entity = await GetAsync(Id);
            if (entity != null)
            {
                _repository.Remove(entity);
                await _unitOfWork.CompleteAsync();
            }

        }

        protected virtual Expression<Func<T, bool>> CreateEqualityExpressionForId(U id)
        {
            var lambdaParam = Expression.Parameter(typeof(T));

            var leftExpression = Expression.PropertyOrField(lambdaParam, "Id");

            var idValue = Convert.ChangeType(id, typeof(U));

            Expression<Func<object>> closure = () => idValue;
            var rightExpression = Expression.Convert(closure.Body, leftExpression.Type);

            var lambdaBody = Expression.Equal(leftExpression, rightExpression);

            return Expression.Lambda<Func<T, bool>>(lambdaBody, lambdaParam);
        }

        
    }
}
