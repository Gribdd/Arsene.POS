using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Arsene.POS.ApiClient.IoC
{
    public static class ServiceCollectionExtension
    {
        public static void AddApiClientService(this IServiceCollection services,
            Action<ApiClientOptions> options)
        {
            services.Configure(options);
            services.AddSingleton(provider =>
            {
                var options = provider.GetRequiredService<IOptions<ApiClientOptions>>().Value;
                return new ApiClientService(options);
            });
        }

    }
}
