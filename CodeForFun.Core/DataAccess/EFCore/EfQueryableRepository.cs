using System.Linq;
using CodeForFun.Core;
using Microsoft.EntityFrameworkCore;
using CodeForFun.Core.Entities;

namespace CodeForFun.Core.DataAccess.EFCore
{
    public class EfQueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        private readonly DbContext _context;
        private DbSet<T> _entities;

        public EfQueryableRepository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Table => Entities;

        protected virtual DbSet<T> Entities
        {
            get { return _entities ??= _context.Set<T>(); }
        }
    }
}