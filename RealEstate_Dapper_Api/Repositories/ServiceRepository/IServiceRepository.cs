using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository
{
    public interface IServiceRepository
    {
        Task<List<ResultServiceDto>> GetAllServiceAsync();
        void CreateService(CreateServiceDto createService);
        void DeleteService(int id);
        void UpdateService(UpdateServiceDto updateService);
        Task<GetByIDServiceDto> GetService(int id);
    }
}
