namespace ECommerceApp.Features.Core
{
    public interface ILogger
    {
        void AddProvider(ILoggerProvider provider);
    }
}
