using CrudBackend.Entities;
using CrudBackend.RepositoryPattern;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CrudBackend.Features.AddressFeature.DeleteAddress
{
    public class DeleteAddressHandler :  IRequestHandler<DeleteAddressRequestModel, DeleteAddressResponseModel>
    {
        private readonly IRepository<Addresses> _repository;
        public DeleteAddressHandler(IRepository<Addresses> repository) { _repository = repository; }
        public async Task<DeleteAddressResponseModel> Handle(DeleteAddressRequestModel request,CancellationToken cancellation)
        {
            var existing = await _repository.GetAllQueryable().FirstOrDefaultAsync(x => x.AddressId == request.id, cancellation);
            if (existing == null)
            {
                return new DeleteAddressResponseModel { isupdated = false, message = "Address not found." };
            }

            await _repository.DeleteData(existing);
            return new DeleteAddressResponseModel { isupdated = true, message = "Address deleted successfully." };
        }
    }
}