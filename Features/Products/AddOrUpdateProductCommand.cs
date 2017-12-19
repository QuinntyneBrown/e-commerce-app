using MediatR;
using ECommerceApp.Data;
using ECommerceApp.Model;
using ECommerceApp.Features.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace ECommerceApp.Features.Products
{
    public class AddOrUpdateProductCommand
    {
        public class Request : BaseRequest, IRequest<Response>
        {
            public ProductApiModel Product { get; set; }            
        }

        public class Response { }

        public class Handler : IAsyncRequestHandler<Request, Response>
        {
            public Handler(ECommerceAppContext context, IEventBus bus)
            {
                _context = context;
            }

            public async Task<Response> Handle(Request request)
            {
                var entity = await _context.Products
                    .Include(x => x.Tenant)
                    .SingleOrDefaultAsync(x => x.Id == request.Product.Id && x.Tenant.UniqueId == request.TenantUniqueId);
                
                if (entity == null) {
                    var tenant = await _context.Tenants.SingleAsync(x => x.UniqueId == request.TenantUniqueId);
                    _context.Products.Add(entity = new Product() { TenantId = tenant.Id });
                }

                entity.Name = request.Product.Name;
                
                await _context.SaveChangesAsync();

                return new Response();
            }

            private readonly ECommerceAppContext _context;
        }
    }
}
