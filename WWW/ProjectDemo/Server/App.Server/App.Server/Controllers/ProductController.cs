using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using App.IService;
using App.Model.ResponseBody;
using App.Model.DBEntity;
using App.Model.RequestBody;

namespace App.Server.Controllers
{
    public class ProductController : ApiController
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        /// <summary>
        /// 获取商品列表
        /// </summary>
        /// <param name="request">请求参数</param>
        /// <returns></returns>
        [HttpPost]
        public Response<List<Product>> GetProductsFor([FromBody] ProductRequest request)
        {
            return new Response<List<Product>>(_productService.GetProductsFor(request));
        }
    }
}
