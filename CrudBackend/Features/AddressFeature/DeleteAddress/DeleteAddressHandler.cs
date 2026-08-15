using CrudBackend.Entities;
using CrudBackend.RepositoryPattern;
using CrudBackend.UnitWorkPattern;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CrudBackend.Features.AddressFeature.DeleteAddress
{
    public class DeleteAddressHandler :  IRequestHandler<DeleteAddressRequestModel, DeleteAddressResponseModel>
    {
        private readonly IRepository<Addresses> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteAddressHandler(IRepository<Addresses> repository, IUnitOfWork unitOfWork) { _repository = repository; _unitOfWork = unitOfWork; }
        public async Task<DeleteAddressResponseModel> Handle(DeleteAddressRequestModel request,CancellationToken cancellation)
        {
            var existing = await _repository.GetAllQueryable().FirstOrDefaultAsync(x => x.AddressId == request.id, cancellation);
            if (existing == null)
            {
                return new DeleteAddressResponseModel { isDeleted = false, message = "Address not found." };
            }

            await _repository.DeleteData(existing);
            await _unitOfWork.CommitAsync();
            return new DeleteAddressResponseModel { isDeleted = true, message = "Address deleted successfully." };
        }
    }
}