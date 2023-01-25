using HealthPlus.Application.DTOs;
using HealthPlus.Application.Interfaces.Repositories;
using HealthPlus.Application.Interfaces.Services;
using HealthPlus.Domain.Entities;

namespace HealthPlus.Application.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IRepository _repository;

        public ServiceService(IRepository repository)
        {
            _repository = repository;
        }
        public BaseResponse CreateService(CreateServiceRequestModel request)
        {
            var service = new Service
            {
                ServiceName = request.ServiceName,
                Cost = request.Cost,
            };

           _repository.Add(service);
           _repository.SaveChanges();

            return new BaseResponse
            {
                Message = "Service created successfully",
                Status = true
            };
        }

        public BaseResponse UpdateService(UpdateServiceRequestModel request)
        {
            throw new NotImplementedException();
        }
    }
}
