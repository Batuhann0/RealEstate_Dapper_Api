using Dapper;
using RealEstate_Dapper_Api.Dtos.PopulerLocationDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate_Dapper_Api.Repositories.PopulerLocationRepositories
{
    public class PopulerLocationRepository : IPopulerLocationRepository
    {
        private readonly Context _context;

        public PopulerLocationRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultPopulerLocationDto>> GetAllPopulerLocationAsync()
        {
            string quary = "Select * From PopulerLocation";
            using (var connection = _context.CreateConnection())
            {
                //QueryAsync listeleme için kullanılır
                var values = await connection.QueryAsync<ResultPopulerLocationDto>(quary);
                return values.ToList();
            }
        }


    }
}
