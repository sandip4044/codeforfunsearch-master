﻿using CodeForFun.Core;
using CodeForFun.Repository.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeForFun.Repository.DataAccess.Abstract
{
    public interface ISearchExtensionsDal : IEntityRepository<SearchExtensions>
    {
        List<SearchExtensions> GetExtensions();
    }
}
