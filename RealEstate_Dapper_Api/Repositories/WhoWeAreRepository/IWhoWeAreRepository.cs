using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepository
{
    public interface IWhoWeAreRepository
    {
        Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetailAsync();
    }
}
