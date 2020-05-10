﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CodeForFun.Core.Entities;

namespace CodeForFun.Repository.Entities.Concrete
{
    public partial class ProductsToCustomer : IEntity
    {
        [Key]
        public int CustomerId { get; set; }
        [Key]
        public int ProductId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("ProductsToCustomers")]
        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(ProductId))]
        [InverseProperty("ProductsToCustomers")]
        public virtual Product Product { get; set; }
    }
}