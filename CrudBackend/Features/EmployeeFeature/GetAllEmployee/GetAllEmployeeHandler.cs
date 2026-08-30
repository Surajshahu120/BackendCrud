using AutoMapper;
using CrudBackend.Entities;
using CrudBackend.RepositoryPattern;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace CrudBackend.Features.EmployeeFeature.GetAllEmployee
{
    public class GetAllEmployeeHandler : IRequestHandler<GetAllEmployeeRequestModel, GetAllEmployeeResponseModel>
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        public GetAllEmployeeHandler(IRepository<Employee> employeeRepository, IMapper mapper, IMemoryCache memoryCache)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }
        public async Task<GetAllEmployeeResponseModel> Handle(GetAllEmployeeRequestModel request, CancellationToken cancellationToken)
        {
            var cacheKey = "Employees";
            if (_memoryCache.TryGetValue(cacheKey, out List<Employee> employees))
            {
                return new GetAllEmployeeResponseModel
                {
                    Employees = _mapper.Map<IEnumerable<EmployeeRepresentationModel>>(employees)
                };
            }
            var cacheOption = new MemoryCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10) };
            var data = await _employeeRepository.GetAllQueryable().Include(x => x.Addresses).ToListAsync();
            _memoryCache.Set(cacheKey, data, cacheOption);
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
