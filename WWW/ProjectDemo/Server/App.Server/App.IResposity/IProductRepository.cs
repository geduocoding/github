using App.Model.DBEntity;
using App.Model.RequestBody;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.IRepository
{
    public interface IProductRepository
    {
        List<Product> GetProductsFor(ProductRequest request);
    }
}
