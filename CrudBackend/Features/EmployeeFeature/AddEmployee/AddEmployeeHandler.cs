using AutoMapper;
using CrudBackend.Entities;
using CrudBackend.RepositoryPattern;
using CrudBackend.UnitWorkPattern;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace CrudBackend.Features.EmployeeFeature.AddEmployee
{

    public class AddEmployeeHandler : IRequestHandler<AddEmployeeRequestModel, AddEmployeeResponseModel>
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        public AddEmployeeHandler(IRepository<Employee> employeeRepository, IUnitOfWork unitOfWork, IMapper mapper, IMemoryCache memoryCache)
        {
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }
        public async Task<AddEmployeeResponseModel> Handle(AddEmployeeRequestModel request, CancellationToken cancellationToken)
        {
            var mapData = _mapper.Map<Employee>(request.employee);
            var data = await _employeeRepository.AddData(mapData);
            await _unitOfWork.CommitAsync();
            _memoryCache.Remove("Employees");

            return new AddEmployeeResponseModel
            {
                employeeData = _mapper.Map<EmployeeRepresentationModel>(data)
            };
        }
    }
}
