using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.IRepository;
using App.Model.DBEntity;
using App.Model.RequestBody;

namespace App.Repositoty
{
    public class ProductRepository: IProductRepository
    {
        public List<Product> GetProductsFor(ProductRequest request)
        {
            List<Product> products = new List<Product>();
            products.Add(new Product() { Name = "衣服" });
            products.Add(new Product() { Name = "裤子" });
            return products;
        }
    }
}
