using AutoMapper;
using CrudBackend.Entities;
using CrudBackend.Features.EmployeeFeature.GetAllEmployee;
using CrudBackend.Features.EmployeeFeature.GetAllEmployeeById;
using CrudBackend.RepositoryPattern;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CrudBackend.Features.EmployeeFeature.GetEmployeeById
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdRequestModel,GetEmployeeByIdResponseModel>
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;
        public GetEmployeeByIdHandler(IRepository<Employee> employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task<GetEmployeeByIdResponseModel> Handle(GetEmployeeByIdRequestModel request, CancellationToken cancellationToken)
        {
            var existingData = await _employeeRepository.GetAllQueryable().Include(x => x.Addresses).FirstOrDefaultAsync(x => x.Id == request.id);
            if (existingData == null) {
                return new GetEmployeeByIdResponseModel
                {
                    message = "Id does not exist"
                };
            }
            var res = _mapper.Map<EmployeeRepresentationModel>(existingData);
            return new GetEmployeeByIdResponseModel
            {
                employee = res
            };
        }
    }
}
