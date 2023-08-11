using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        #region Listeleme
        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string quary = "Select * From Category";
            using (var connection = _context.CreateConnection())
            {
                //QueryAsync listeleme için kullanılır
                var values = await connection.QueryAsync<ResultCategoryDto>(quary);
                return values.ToList();
            }
        }
        #endregion

        #region Ekleme
        public async void CreateCategory(CreateCategoryDto categoryDto)
        {
            string quary = "insert into Category (CategoryName,CategoryStatus) values (@categoryName,@categoryStatus)";

            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", categoryDto.CategoryName);
            parameters.Add("@categoryStatus", true);
            using (var connection = _context.CreateConnection())
            {
                //ekleme,silme,güncelleme işlemi için ExecuteAsync kullanılır
                await connection.ExecuteAsync(quary, parameters);

            }
        }

        #endregion

        #region Sil
        public async void DeleteCategory(int id)
        {
            string quary = "Delete from Category where CategoryID=@categoryID";

            var parameters = new DynamicParameters();
            parameters.Add("@categoryID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(quary, parameters);
            }
        }
        #endregion
        #region Güncelle

        public async void UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            string quary = "update Category set CategoryName=@categoryName,CategoryStatus=@categoryStatus where CategoryID=@categoryID";


            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", updateCategoryDto.CategoryName);
            parameters.Add("@categoryStatus", updateCategoryDto.CategoryStatus);
            parameters.Add("@categoryID", updateCategoryDto.CategoryID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(quary, parameters);
            }
        }

        public async Task<GetByIDCategoryDto> GetCategory(int id)
        {
            string quary = "select * from Category where CategoryID=@CategoryID";

            var parameters = new DynamicParameters();
            parameters.Add("@CategoryID", id);
            using (var connection = _context.CreateConnection())
            {
                //geriye bir tane değer döndürür
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDCategoryDto>(quary, parameters);
                return values;
            }
        }
        #endregion
    }
}
