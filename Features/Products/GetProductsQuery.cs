using MediatR;
using ECommerceApp.Data;
using ECommerceApp.Features.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace ECommerceApp.Features.Products
{
    public class GetProductsQuery
    {
        public class Request : BaseRequest, IRequest<Response>
        {
            
        }

        public class Response
        {

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
                throw new System.NotImplementedException();
            }

            private readonly IECommerceAppContext _context;
            private readonly ICache _cache;
        }
    }
}
