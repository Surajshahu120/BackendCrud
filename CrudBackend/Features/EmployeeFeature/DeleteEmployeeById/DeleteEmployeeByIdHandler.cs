using CrudBackend.Entities;
using CrudBackend.RepositoryPattern;
using CrudBackend.UnitWorkPattern;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace CrudBackend.Features.EmployeeFeature.DeleteEmployeeById
{
    public class DeleteEmployeeByIdHandler : IRequestHandler<DeleteEmployeeByIdRequestModel, DeleteEmployeeByIdResponseModel>
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _memoryCache;

        public DeleteEmployeeByIdHandler(IRepository<Employee> employeeRepository, IUnitOfWork unitOfWork, IMemoryCache memoryCache)
        {
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
            _memoryCache = memoryCache;
        }
        public async Task<DeleteEmployeeByIdResponseModel> Handle(DeleteEmployeeByIdRequestModel request, CancellationToken cancellationToken)
        {
            var existingData = await _employeeRepository.GetDataById(request.id);
            if (existingData == null)
            {
                return new DeleteEmployeeByIdResponseModel
                {
                    message = "Id does not exist",
                    isDeleted = false,
                };
            }
            await _employeeRepository.DeleteData(existingData);
            await _unitOfWork.CommitAsync();
            _memoryCache.Remove("Employees");
            return new DeleteEmployeeByIdResponseModel
            {
                isDeleted = true
            };
        }
    }
}
