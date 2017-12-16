using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ECommerceApp.Features.Core;

namespace ECommerceApp.Features.Products
{
    [Authorize]
    [RoutePrefix("api/products")]
    public class ProductController : BaseApiController
    {
        public ProductController(IMediator mediator)
            :base(mediator) { }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetProductsQuery.Response))]
        public async Task<IHttpActionResult> Get() => Ok(await Send(new GetProductsQuery.Request()));


    }
}
