using AutoMapper;
using CrudBackend.Entities;
using CrudBackend.RepositoryPattern;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CrudBackend.Features.AddressFeature.GetAddressById
{
    public class GetAddressByIdHandler : IRequestHandler<GetAddressByIdRequestModel,GetAddressByIdResponseModel>
    {
        private readonly IRepository<Addresses> _addressRepsitory;
        private readonly IMapper _mapper;
        public GetAddressByIdHandler(IRepository<Addresses> addressRepsitory, IMapper mapper) { 
               _addressRepsitory = addressRepsitory;
            _mapper = mapper;
        }
        public async Task<GetAddressByIdResponseModel> Handle(GetAddressByIdRequestModel request, CancellationToken cancellationToken)
        {
            var existingdata = await _addressRepsitory.GetAllQueryable().FirstOrDefaultAsync(x => x.AddressId == request.id);
            if (existingdata == null) {
                return new GetAddressByIdResponseModel
                {
                    message = "Data not found"
                };
            }
            return new GetAddressByIdResponseModel
            {
                address = _mapper.Map<AddressRepresentationalModel>(existingdata)
            };
        }
    }
}
