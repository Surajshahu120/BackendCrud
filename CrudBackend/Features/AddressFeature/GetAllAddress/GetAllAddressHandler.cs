using AutoMapper;
using CrudBackend.Entities;
using CrudBackend.RepositoryPattern;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CrudBackend.Features.AddressFeature.GetAllAddress
{
    public class GetAllAddressHandler : IRequestHandler<GetAllAddressRequestModel, GetAllAddressResponseModel>
    {
        private readonly IRepository<Addresses> _addressRepository;
        private readonly IMapper _mapper;
        public GetAllAddressHandler(IRepository<Addresses> _addressRepository, IMapper mapper)
        {
            this._addressRepository = _addressRepository;
            _mapper = mapper;
        }
        public async Task<GetAllAddressResponseModel> Handle(GetAllAddressRequestModel request, CancellationToken cancellationToken)
        {
            var result = await _addressRepository.GetAllQueryable().ToListAsync(cancellationToken);
            if(result == null)
            {
                return new GetAllAddressResponseModel
                {
                    message = "Data Not found"
                };
            }
            return new GetAllAddressResponseModel
            {
                message = "Data Fetched Successfully",
                address = _mapper.Map<List<AddressRepresentationalModel>>(result)
            };
        }
    }
}
