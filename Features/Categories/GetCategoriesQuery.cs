using MediatR;
using ECommerceApp.Data;
using ECommerceApp.Features.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace ECommerceApp.Features.Categories
{
    public class GetCategoriesQuery
    {
        public class Request : BaseRequest, IRequest<Response> { }

        public class Response
        {
            public ICollection<CategoryApiModel> Categories { get; set; } = new HashSet<CategoryApiModel>();
        }

        public class Handler : IAsyncRequestHandler<Request, Response>
        {
            public Handler(IECommerceAppContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var categorys = await _context.Categories
                    .Include(x => x.Tenant)
                    .Where(x => x.Tenant.UniqueId == request.TenantUniqueId )
                    .ToListAsync();

                return new Response()
                {
                    Categories = categorys.Select(x => CategoryApiModel.FromCategory(x)).ToList()
                };
            }

            private readonly IECommerceAppContext _context;
            private readonly ICache _cache;
        }
    }
}
