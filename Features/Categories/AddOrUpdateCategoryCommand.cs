using MediatR;
using ECommerceApp.Data;
using ECommerceApp.Model;
using ECommerceApp.Features.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace ECommerceApp.Features.Categories
{
    public class AddOrUpdateCategoryCommand
    {
        public class Request : BaseRequest, IRequest<Response>
        {
            public CategoryApiModel Category { get; set; }            
        }

        public class Response { }

        public class Handler : IAsyncRequestHandler<Request, Response>
        {
            public Handler(IECommerceAppContext context, IEventBus bus)
            {
                _context = context;
            }

            public async Task<Response> Handle(Request request)
            {
                var entity = await _context.Categories
                    .Include(x => x.Tenant)
                    .SingleOrDefaultAsync(x => x.Id == request.Category.Id && x.Tenant.UniqueId == request.TenantUniqueId);
                
                if (entity == null) {
                    var tenant = await _context.Tenants.SingleAsync(x => x.UniqueId == request.TenantUniqueId);
                    _context.Categories.Add(entity = new Category() { TenantId = tenant.Id });
                }

                entity.Name = request.Category.Name;
                
                await _context.SaveChangesAsync();

                return new Response();
            }

            private readonly IECommerceAppContext _context;
        }
    }
}
