using System.Linq;
using CodeForFun.Core.Entities;

namespace CodeForFun.Core
{
    public interface IQueryableRepository<out T> where T : class, IEntity, new()
    {
        IQueryable<T> Table { get; }
    }
}