using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using IdentityServer4.AccessTokenValidation;
using TCC.BackEnd.API.Core.Data;

namespace TCC.BackEnd.API.Monitoramento
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
            .AddIdentityServerAuthentication(options =>
            {
#if DEBUG
                options.Authority = "http://localhost:3000"; // Auth Server
#else
                options.Authority = "https://api-tcc-autenticacao.azurewebsites.net"; // Auth Server
#endif
                options.RequireHttpsMetadata = false;
                options.ApiName = "tcc_auth"; // API Resource Id
                options.SaveToken = true;               
            });

            services.AddHttpContextAccessor();

            services.AddDbContext<CoreContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("CoreContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDeveloperExceptionPage();
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
        }
    }
}