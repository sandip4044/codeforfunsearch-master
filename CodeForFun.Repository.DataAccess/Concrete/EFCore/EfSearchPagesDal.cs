using CodeForFun.Core.DataAccess.EFCore;
using CodeForFun.Repository.DataAccess.Abstract;
using CodeForFun.Repository.DataAccess.DbContexts;
using CodeForFun.Repository.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeForFun.Repository.DataAccess.Concrete.EFCore
{
    public class EfSearchPagesDal : EfEntityRepository<SearchPages, RepositoryContext>, ISearchPagesDal
    {
        private readonly EfEntityRepository<SearchPages, RepositoryContext> _EntityRepository = new
           EfEntityRepository<SearchPages, RepositoryContext>();
        public List<SearchPages> GetSearch(string searchText)
        {
            return _EntityRepository.ReadList(e => e.Notes.Contains(searchText));
        }
    }
}
