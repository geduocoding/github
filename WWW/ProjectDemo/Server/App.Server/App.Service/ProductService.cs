using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.IRepository;
using App.IService;
using App.Model.DBEntity;
using App.Model.RequestBody;

namespace App.Service
{
    public class ProductService:IProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetProductsFor(ProductRequest request)
        {
            return _productRepository.GetProductsFor(request);
        }
    }
}
