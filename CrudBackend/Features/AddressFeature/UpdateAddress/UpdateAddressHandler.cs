using AutoMapper;
using CrudBackend.Entities;
using CrudBackend.RepositoryPattern;
using CrudBackend.UnitWorkPattern;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CrudBackend.Features.AddressFeature.UpdateAddress
{
    public class UpdateAddressHandler : IRequestHandler<UpdateAddressRequestModel, UpdateAddressResponseModel>
    {
        private readonly IRepository<Addresses> _addressRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateAddressHandler(IRepository<Addresses> addressRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<UpdateAddressResponseModel> Handle(UpdateAddressRequestModel request, CancellationToken cancellationToken)
        {
            var res = await _addressRepository.GetAllQueryable().FirstOrDefaultAsync(x => x.AddressId == request.address.id);
            var mapRes = _mapper.Map(request.address,res);
            var resdata=await _addressRepository.UpdateData(mapRes);
            await _unitOfWork.CommitAsync();
            return new UpdateAddressResponseModel
            {
                isUpdated = true,
                address = _mapper.Map<AddressRepresentationalModel>(resdata)
            };
        }
    }
}