using CodeForFun.Core.DataAccess.EFCore;
using CodeForFun.Repository.DataAccess.Abstract;
using CodeForFun.Repository.DataAccess.DbContexts;
using CodeForFun.Repository.Entities.Concrete;

namespace CodeForFun.Repository.DataAccess.Concrete.EFCore
{
    public class EfCustomerDal : EfEntityRepository<Customer, RepositoryContext>, ICustomerDal
    {
    }
}