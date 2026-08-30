using AutoMapper;
using CrudBackend.Entities;
using CrudBackend.RepositoryPattern;
using CrudBackend.UnitWorkPattern;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace CrudBackend.Features.EmployeeFeature.UpdateEmployee
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeRequestModel, UpdateEmployeeResponseModel>
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _memoryCache;

        public UpdateEmployeeHandler(IRepository<Employee> employeeRepository, IMapper mapper, IUnitOfWork unitOfWork, IMemoryCache memoryCache)
        { 
             _employeeRepository = employeeRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _memoryCache = memoryCache;
        }
        public async Task<UpdateEmployeeResponseModel> Handle(UpdateEmployeeRequestModel request, CancellationToken cancellationToken)
        {
            var existingData = await _employeeRepository.GetDataById(request.representationModel.id);
            if (existingData == null)
            {
                return new UpdateEmployeeResponseModel
                {
                    message = "Id does not exist"
                };
            }
            var res = _mapper.Map(request.representationModel, existingData);
            var data =await _employeeRepository.UpdateData(res);
            await _unitOfWork.CommitAsync();
            _memoryCache.Remove("Employees");

            return new UpdateEmployeeResponseModel
            {
                employee = _mapper.Map<EmployeeRepresentationModel>(data)
            };
        }
    }
}
