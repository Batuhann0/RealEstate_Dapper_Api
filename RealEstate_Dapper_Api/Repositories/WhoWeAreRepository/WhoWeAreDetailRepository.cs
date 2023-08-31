using Dapper;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepository
{
    public class WhoWeAreDetailRepository : IWhoWeAreRepository
    {
        private readonly Context _context;

        public WhoWeAreDetailRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetailAsync()
        {
            string quary = "select * from WhoAreDetail";
            using(var c = _context.CreateConnection())
            {
                var values = await c.QueryAsync<ResultWhoWeAreDetailDto>(quary);
                return values.ToList();
            }
        }
    }
}
