using CodeForFun.Core.DataAccess.EFCore;
using CodeForFun.Repository.DataAccess.Abstract;
using CodeForFun.Repository.DataAccess.DbContexts;
using CodeForFun.Repository.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeForFun.Repository.DataAccess.Concrete.EFCore
{
    public class EfSearchExtensionsDal : EfEntityRepository<SearchExtensions, RepositoryContext>, ISearchExtensionsDal
    {
        private readonly EfEntityRepository<SearchExtensions, RepositoryContext> _EntityRepository = new
           EfEntityRepository<SearchExtensions, RepositoryContext>();
        public List<SearchExtensions> GetExtensions()
        {
            return _EntityRepository.ReadList();
        }
    }
}
