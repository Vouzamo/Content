using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vouzamo.Common.Converters;
using Vouzamo.Common.Services;
using Vouzamo.Common.UnitOfWork;
using Vouzamo.Manager.Services;
using Vouzamo.Persistence.Context;
using Vouzamo.Persistence.UnitOfWork;

namespace Vouzamo.Manager.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ManagerContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Manager")));

            services.AddMvc().AddJsonOptions(o => ConfigureJsonOptions(o));

            services.AddTransient<IManagerUnitOfWork, ManagerUnitOfWork>();
            services.AddTransient<IManagerService, ManagerService>();
        }

        private void ConfigureJsonOptions(MvcJsonOptions options)
        {
            var serializerSettings = options.SerializerSettings;

            serializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            serializerSettings.Converters.Add(new ItemJsonConverter());
            serializerSettings.Converters.Add(new FieldJsonConverter());
            serializerSettings.Converters.Add(new ValueJsonConverter());
        }
            
            
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var managerContext = scope.ServiceProvider.GetService<ManagerContext>();
                managerContext.Database.EnsureCreated();
            }
        }
    }
}
