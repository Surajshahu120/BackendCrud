using AutoMapper;
using CrudBackend.Entities;
using CrudBackend.RepositoryPattern;
using CrudBackend.UnitWorkPattern;
using MediatR;

namespace CrudBackend.Features.EmployeeFeature.UpdateEmployee
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeRequestModel, UpdateEmployeeResponseModel>
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateEmployeeHandler(IRepository<Employee> employeeRepository, IMapper mapper, IUnitOfWork unitOfWork)
        { 
             _employeeRepository = employeeRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
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
            return new UpdateEmployeeResponseModel
            {
                employee = _mapper.Map<EmployeeRepresentationModel>(data)
            };
        }
    }
}
