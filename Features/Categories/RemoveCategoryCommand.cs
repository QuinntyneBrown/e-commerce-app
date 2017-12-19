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
    public class RemoveCategoryCommand
    {
        public class Request : BaseRequest, IRequest<Response>
        {
            public int Id { get; set; }
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
                var category = await _context.Categories.SingleAsync(x=>x.Id == request.Id && x.Tenant.UniqueId == request.TenantUniqueId);
                category.IsDeleted = true;
                await _context.SaveChangesAsync();
                return new Response();
            }

            private readonly IECommerceAppContext _context;
        }
    }
}
