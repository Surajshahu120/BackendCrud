using AutoMapper;
using CrudBackend.Entities;
using CrudBackend.RepositoryPattern;
using CrudBackend.UnitWorkPattern;
using MediatR;

namespace CrudBackend.Features.EmployeeFeature.BulkAddEmployee
{
    public class BulkAddEmployeeHandler : IRequestHandler<BulkAddEmployeeRequestModel, BulkAddEmployeeResponseModel>
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BulkAddEmployeeHandler(IRepository<Employee> employeeRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BulkAddEmployeeResponseModel> Handle(BulkAddEmployeeRequestModel request, CancellationToken cancellation)
        {
            var employeeEntities = _mapper.Map<List<Employee>>(request.employee);
            if(employeeEntities == null)
            {
                return new BulkAddEmployeeResponseModel
                {
                    message="Data is empty"
                };
            }
            var res=await _employeeRepository.BulkDataAdd(employeeEntities);
            await _unitOfWork.CommitAsync();
            return new BulkAddEmployeeResponseModel
            {
                employeeData = _mapper.Map<List<EmployeeRepresentationModel>>(res)
            };
        }
    }
}
