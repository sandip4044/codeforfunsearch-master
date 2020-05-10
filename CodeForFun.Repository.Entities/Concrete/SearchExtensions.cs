using CodeForFun.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CodeForFun.Repository.Entities.Concrete
{
    public partial class SearchExtensions : IEntity 
    {
        [Key]
        public Int16 Id { get; set; }

        [StringLength(128)]
        public string Name { get; set; }
    }
}
