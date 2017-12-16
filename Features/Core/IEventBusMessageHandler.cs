using Newtonsoft.Json.Linq;

namespace ECommerceApp.Features.Core
{
    public interface IEventBusMessageHandler
    {
        void Handle(JObject message);
    }
}