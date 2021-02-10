using RestApiTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiTO.Helpers
{
    public class MapProduct
    {
        private readonly Products _product;
        public MapProduct(Products product)
        {
            _product.Name = product.Name;
            _product.Price = product.Price;
        }

    }
}
