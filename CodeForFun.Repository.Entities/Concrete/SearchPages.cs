using CodeForFun.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CodeForFun.Repository.Entities.Concrete
{
    public partial class SearchPages : IEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(128)]
        public string Title { get; set; }
        [StringLength(256)]
        public string Description { get; set; }
        [StringLength(1024)]
        public string Notes { get; set; }
        [StringLength(1024)]
        public string Path { get; set; }
    }
}
