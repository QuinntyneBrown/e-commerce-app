using MediatR;
using ECommerceApp.Data;
using System.Threading.Tasks;
using ECommerceApp.Features.Core;

namespace ECommerceApp.Features.DigitalAssets
{
    public class RemoveDigitalAssetCommand
    {
        public class RemoveDigitalAssetRequest : IRequest<RemoveDigitalAssetResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveDigitalAssetResponse { }

        public class RemoveDigitalAssetHandler : IAsyncRequestHandler<RemoveDigitalAssetRequest, RemoveDigitalAssetResponse>
        {
            public RemoveDigitalAssetHandler(IECommerceAppContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<RemoveDigitalAssetResponse> Handle(RemoveDigitalAssetRequest request)
            {
                var digitalAsset = await _context.DigitalAssets.FindAsync(request.Id);
                digitalAsset.IsDeleted = true;
                await _context.SaveChangesAsync();
                return new RemoveDigitalAssetResponse();
            }

            private readonly IECommerceAppContext _context;
            private readonly ICache _cache;
        }
    }
}
