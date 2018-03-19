using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Jose;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebApiCore.App_Start;
using WebApiCore.Repositroy;
using static WebApiCore.Controllers.AuthController;

namespace WebApiCore
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
            var key = "WebApiTestingKey";

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(o =>
                    {
                        o.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = false,
                            ValidateAudience = false,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,                            
                            
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                        };

                        o.Events = new JwtBearerEvents
                        {
                            OnAuthenticationFailed = context =>
                            {
                                var ex = context.Exception.ToString();
                                return Task.CompletedTask;
                            },
                            OnTokenValidated = context =>
                            {
                                var token = context.SecurityToken;
                                return Task.CompletedTask;
                            }
                        };
                        
                    });

            services.AddMvc();

            services.SetupDependencyInjection();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseMvc();
        }

        
    }
}
