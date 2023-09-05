
using Dapper;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly Context _context;

        public ServiceRepository(Context context)
        {
            _context = context;
        }

        public async void CreateService(CreateServiceDto createService)
        {
            var quary = "insert into Service (ServiceName,ServiceStatus) values (@ServiceName,@ServiceStatus)";

            var parameters = new DynamicParameters();
            parameters.Add("@ServiceName", createService.ServiceName);
            parameters.Add("@ServiceStatus", true);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(quary, parameters);
            }
        }

        public async void DeleteService(int id)
        {
            var quary = "Delete from Service where ServiceID=@serviceId";

            var parameters = new DynamicParameters();
            parameters.Add("@serviceId", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(quary, parameters);
            }
        }

        public async Task<List<ResultServiceDto>> GetAllServiceAsync()
        {
            var quary = "select * from Service";
            using (var c = _context.CreateConnection())
            {
                var values = await c.QueryAsync<ResultServiceDto>(quary);
                return values.ToList();
            }
        }

        public async Task<GetByIDServiceDto> GetService(int id)
        {
            string quary = "select * from Service where ServiceID=@serviceID";

            var parameters = new DynamicParameters();
            parameters.Add("@serviceID", id);
            using (var connection = _context.CreateConnection())
            {
                //geriye bir tane değer döndürür
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDServiceDto>(quary, parameters);
                return values;
            }
        }

        public async void UpdateService(UpdateServiceDto updateService)
        {
            string quary = "update Service set ServiceName=@serviceName,ServiceStatus=@serviceStatus where ServiceID=@serviceID";


            var parameters = new DynamicParameters();
            parameters.Add("@serviceName", updateService.ServiceName);
            parameters.Add("@serviceStatus", updateService.ServiceStatus);
            parameters.Add("@serviceID", updateService.ServiceID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(quary, parameters);
            }
        }
    }
}
