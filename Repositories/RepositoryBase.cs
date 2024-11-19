using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
    where T : class , new() // Type(T) Newlenebilir class olmalı.
    {
        protected readonly RepositoryContext _context;

        protected RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
           _context.Set<T>().Add(entity);
        }


        //Abstract olduğu için newlenemez nesne oluşturulamaz.
        public IQueryable<T> FindAll(bool trackChanges)
        {
            return trackChanges 
            ? _context.Set<T>() // Takip ediliyorsa 
            : _context.Set<T>().AsNoTracking(); // Takip edilmiyorsa takip edilmeden geri döndürülür.
        }

        public T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return trackChanges 
            ? _context.Set<T>().Where(expression).SingleOrDefault()
            : _context.Set<T>().Where(expression).AsNoTracking().SingleOrDefault();

        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
           _context.Set<T>().Update(entity);
        }
    }
} 