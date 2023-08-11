using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        #region Listeleme
        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var values = await _categoryRepository.GetAllCategoryAsync();
            return Ok(values);
        }
        #endregion

        #region Ekleme
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            _categoryRepository.CreateCategory(createCategoryDto);
            return Ok("Kategori başarılı bir şekilde eklendi");
        }
        #endregion

        #region Sil
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            _categoryRepository.DeleteCategory(id);
            return Ok("Kategori başarılı bir şekilde silindi");
        }
        #endregion

        #region Güncelleme
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategory)
        {
            _categoryRepository.UpdateCategory(updateCategory);
            return Ok("Kategori başarılı bir şekilde güncellendi");
        }
        #endregion

        #region Id ye göre getir

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var value = await _categoryRepository.GetCategory(id);
            return Ok(value);
        } 
        #endregion
    }
}
