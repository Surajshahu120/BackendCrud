using AutoMapper;
using CrudBackend.Entities;
using CrudBackend.RepositoryPattern;
using CrudBackend.UnitWorkPattern;
using MediatR;

namespace CrudBackend.Features.AddressFeature.AddAddress
{
    public class AddAddressHandler : IRequestHandler<AddAddressRequestModel, AddAddressResponseModel>
    {
        private readonly IRepository<Addresses> _addressRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public AddAddressHandler(IRepository<Addresses> addressRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _addressRepository= addressRepository;
            _mapper = mapper;
            _unitOfWork= unitOfWork;
        }
        public async Task<AddAddressResponseModel> Handle(AddAddressRequestModel request, CancellationToken cancellationToken)
        {
            var resMap = _mapper.Map<Addresses>(request.address);
            if (resMap == null) {
                return new AddAddressResponseModel
                {
                    message = "data is null"
                };
            }
            var res =await _addressRepository.AddData(resMap);
            await _unitOfWork.CommitAsync();
            return new AddAddressResponseModel
            {
                address = _mapper.Map<AddressRepresentationalModel>(res)
            };
        }
    }
}
