using RealEstate_Dapper_Api.Dtos.PopulerLocationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate_Dapper_Api.Repositories.PopulerLocationRepositories
{
    public interface IPopulerLocationRepository
    {
        Task<List<ResultPopulerLocationDto>> GetAllPopulerLocationAsync();
    }
}
