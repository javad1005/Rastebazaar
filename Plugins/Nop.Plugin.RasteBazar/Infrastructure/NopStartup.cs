using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nop.Core.Infrastructure;
using Nop.Plugin.RasteBazar.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.RasteBazar.Infrastructure
{
    /// <summary>
    /// Represents object for the configuring services on application startup
    /// </summary>
    public class NopStartup : INopStartup
    {
        /// <summary>
        /// Gets order of this startup configuration implementation
        /// </summary>
        public int Order => 0;

        /// <summary>
        /// Configure the using of added middleware
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public void Configure(IApplicationBuilder application)
        {
            
        }

        /// <summary>
        /// Add and configure any of the middleware
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="configuration">Configuration of the application</param>
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICheckService, CheckService>();
        }
    }
}
