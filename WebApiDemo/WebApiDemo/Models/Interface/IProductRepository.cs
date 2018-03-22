using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDemo.Models;

namespace WebApiDemo.Models.Interface
{
    interface IProductRepository : IRepository<Product>
    {
      
    }
}
