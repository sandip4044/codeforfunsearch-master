using CodeForFun.Repository.Business.Abstract.Services;
using CodeForFun.Repository.DataAccess.Abstract;
using CodeForFun.Repository.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeForFun.Repository.Business.Concrete.Managers
{
    public class SearchPagesManager : ISearchPages
    {
        private readonly ISearchPagesDal _dal;
        public SearchPagesManager(ISearchPagesDal dal)
        {
            _dal = dal;
        }
        public List<SearchPages> SearchList(string searchText)
        {
            return _dal.GetSearch(searchText);
        }
    }
}
