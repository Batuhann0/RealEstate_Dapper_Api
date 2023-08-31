using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.WhoWeAreRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhoWeAreDetailController : ControllerBase
    {
        private readonly IWhoWeAreRepository _whoWeAreDetail;

        public WhoWeAreDetailController(IWhoWeAreRepository whoWeAreDetail)
        {
            _whoWeAreDetail = whoWeAreDetail;
        }

        [HttpGet]
        public async Task<IActionResult> WhoWeAreDetailList()
        {
            var values = await _whoWeAreDetail.GetAllWhoWeAreDetailAsync();
            return Ok(values);
        }
    }
}
