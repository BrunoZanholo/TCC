using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace TCC.FrontEnd
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
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
                
                //options.DefaultAuthenticateScheme = "oidc";
            })
            .AddCookie()
            .AddOpenIdConnect(options =>
            {
                //options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme; // cookie middle setup above
                options.SignedOutRedirectUri = "/";
#if DEBUG
                options.Authority = "http://localhost:3000"; // Auth Server
                options.RequireHttpsMetadata = false; // only for development 
#else
                options.Authority = "https://api-tcc-autenticacao.azurewebsites.net"; // Auth Server
#endif
                options.ClientId = "tcc_auth_client"; // client setup in Auth Server
                options.ClientSecret = "secret";
                //options.ResponseType = "code id_token"; // means Hybrid flow (id + access token)
                options.ResponseType = OpenIdConnectResponseType.CodeIdToken;
                options.Scope.Add("tcc_auth");
                options.Scope.Add("offline_access");
                options.GetClaimsFromUserInfoEndpoint = true;
                options.SaveTokens = true;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}