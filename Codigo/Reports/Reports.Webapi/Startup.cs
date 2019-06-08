using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Reports.BusinessLogic;
using Reports.BusinessLogic.Interface;
using Reports.DataAccess;
using Reports.DataAccess.Interface;
using Reports.Domain;





namespace Reports.Webapi
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

            services.AddDbContext<DbContext, ReportsContext>(
                 o => o.UseSqlServer(Configuration.GetConnectionString("ReportsDB")).UseLazyLoadingProxies()
            );

            services.AddScoped<IAreaLogic, AreaLogic>();
            services.AddScoped<IRepository<Area>, AreaRepository>();
            services.AddScoped<IRepository<AreaUser>, AreaUserRepository>();

            services.AddScoped<IUserLogic, UserLogic>();
            services.AddScoped<IRepository<User>, UserRepository>();

            services.AddScoped<IIndicatorLogic, IndicatorLogic>();
            services.AddScoped<IRepository<Indicator>, IndicatorRepository>();
            services.AddScoped<IRepository<IndicatorConfig>, IndicatorConfigRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
