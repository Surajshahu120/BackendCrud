using AutoMapper;
using CrudBackend.Entities;
using CrudBackend.RepositoryPattern;
using MediatR;

namespace CrudBackend.Features.EmployeeFeature.GetAllEmployee
{
    public class GetAllEmployeeHandler : IRequestHandler<GetAllEmployeeRequestModel, GetAllEmployeeResponseModel>
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;
        public GetAllEmployeeHandler(IRepository<Employee> employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task<GetAllEmployeeResponseModel> Handle(GetAllEmployeeRequestModel request, CancellationToken cancellationToken)
        {
            var data = await _employeeRepository.GetAllData();
            if (data == null)
            {
                return new GetAllEmployeeResponseModel
                {
                    message = "Data not found"
                };
            }
            return new GetAllEmployeeResponseModel
            {
                Employees = _mapper.Map<IEnumerable<EmployeeRepresentationModel>>(data)
            };
        }
    }
}
