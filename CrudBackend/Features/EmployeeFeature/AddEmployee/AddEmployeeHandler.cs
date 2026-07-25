using AutoMapper;
using CrudBackend.Entities;
using CrudBackend.RepositoryPattern;
using CrudBackend.UnitWorkPattern;
using MediatR;

namespace CrudBackend.Features.EmployeeFeature.AddEmployee
{

    public class AddEmployeeHandler : IRequestHandler<AddEmployeeRequestModel, AddEmployeeResponseModel>
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AddEmployeeHandler(IRepository<Employee> employeeRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<AddEmployeeResponseModel> Handle(AddEmployeeRequestModel request, CancellationToken cancellationToken)
        {
            var mapData = _mapper.Map<Employee>(request.employee);
            var data = await _employeeRepository.AddData(mapData);
            await _unitOfWork.CommitAsync();
            return new AddEmployeeResponseModel
            {
                employeeData = _mapper.Map<EmployeeRepresentationModel>(data)
            };
        }
    }
}
