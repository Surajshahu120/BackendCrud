using CrudBackend.Entities;
using CrudBackend.RepositoryPattern;
using CrudBackend.UnitWorkPattern;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CrudBackend.Features.AddressFeature.DeleteAddress
{
    public class DeleteAddressHandler : IRequestHandler<DeleteAddressRequestModel, DeleteAddressResponseModel>
    {
        private readonly IRepository<Addresses> _addressRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteAddressHandler(IRepository<Addresses> addressRepository, IUnitOfWork unitOfWork)
        {
            _addressRepository = addressRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<DeleteAddressResponseModel> Handle(DeleteAddressRequestModel request, CancellationToken cancellationToken)
        {
           var existingAddress = await _addressRepository.GetAllQueryable().FirstOrDefaultAsync(x => x.AddressId == request.id, cancellationToken);
            if (existingAddress == null) { 
            return new DeleteAddressResponseModel { isDeleted = false, message = "Address not found." };
            }
            await _addressRepository.DeleteData(existingAddress);
            await _unitOfWork.CommitAsync();
            return new DeleteAddressResponseModel { isDeleted = true, message = "Address Deleted Successfully" };
        }
    }
}
