﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public interface IProductRepository
    {
        // IQueryable is more optimize when querying Products
        IQueryable<Product> Products { get; }
    }
}
