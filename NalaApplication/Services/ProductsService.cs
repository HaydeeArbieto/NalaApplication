using NalaApplication.Models;
using NalaApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NalaApplication.Services
{
    public class ProductsService
    {
        private ProductRepository _rep;

        public ProductsService(ProductRepository rep)
        {
            _rep = rep;
        }

         
    }
}
