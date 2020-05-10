using CodeForFun.Core;
using CodeForFun.Repository.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeForFun.Repository.DataAccess.Abstract
{
    public interface ISearchPagesDal : IEntityRepository<SearchPages>
    {
        List<SearchPages> GetSearch(string searchText);
    }
}
