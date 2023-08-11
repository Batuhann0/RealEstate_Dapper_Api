using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var quary = "select * from Product";
            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDto>(quary);
                return values.ToList(); 
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategory()
        {
            //category tablosuyla bağladık
            var quary = "select ProductID,Title,Price,City,District,CategoryName from Product inner join Category on Product.ProductCategory=Category.CategoryID";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(quary);
                return values.ToList();
            }
        }
    }
}
