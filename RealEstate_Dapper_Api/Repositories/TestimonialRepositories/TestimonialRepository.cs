using Dapper;
using RealEstate_Dapper_Api.Dtos.TestimonialsDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate_Dapper_Api.Repositories.TestimonialRepositories
{
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly Context _context;

        public TestimonialRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultTestimonialDto>> GetAllTestimonial()
        {
            var quary = "Select * from Testimonial";
            using (var c = _context.CreateConnection())
            {
                var values = await c.QueryAsync<ResultTestimonialDto>(quary);
                return values.ToList();
            }
        }
    }
}
