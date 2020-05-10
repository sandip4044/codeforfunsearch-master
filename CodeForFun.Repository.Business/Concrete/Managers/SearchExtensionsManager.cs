using CodeForFun.Repository.Business.Abstract.Services;
using CodeForFun.Repository.DataAccess.Abstract;
using CodeForFun.Repository.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeForFun.Repository.Business.Concrete.Managers
{
    public class SearchExtensionsManager : ISearchExtensions
    {
        private readonly ISearchExtensionsDal _dal;
        public SearchExtensionsManager(ISearchExtensionsDal dal)
        {
            _dal = dal;
        }
        public List<SearchExtensions> GetExtensions()
        {
            return _dal.GetExtensions();
        }
    }

}
