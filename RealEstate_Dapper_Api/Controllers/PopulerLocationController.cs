using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.PopulerLocationRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopulerLocationController : ControllerBase
    {
        private readonly IPopulerLocationRepository _populerLocationRepository;

        public PopulerLocationController(IPopulerLocationRepository populerLocationRepository)
        {
            _populerLocationRepository = populerLocationRepository;
        }

        #region Listeleme

        [HttpGet]
        public async Task<IActionResult> PopulerLocationList()
        {
            var values = await _populerLocationRepository.GetAllPopulerLocationAsync();
            return Ok(values);
        } 
        #endregion
    }
}
