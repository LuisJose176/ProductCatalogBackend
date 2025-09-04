using Microsoft.AspNetCore.Http;
using ProductCatalog.Application.Interfaces;

namespace ProductCatalog.Infrastructure.Services
{
    public class CurrentUserService(IHttpContextAccessor accessor) : ICurrentUserService
    {
        private readonly IHttpContextAccessor _accessor = accessor;

        public string? GetUserId()
        {
            var httpContext = _accessor.HttpContext;

            if (httpContext == null)
                return Environment.MachineName; 

            var ip = httpContext.Connection.RemoteIpAddress?.ToString();

            var machineName = Environment.MachineName;

            return $"{machineName} | {ip}";
        }
    }
}
