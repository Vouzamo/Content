using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vouzamo.Common.UnitOfWork;
using Vouzamo.Persistence.Context;
using Vouzamo.Persistence.UnitOfWork;

namespace Vouzamo.Delivery.Api
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
            services.AddDbContext<DeliveryContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Delivery")));

            services.AddMvc();

            services.AddTransient<IDeliveryUnitOfWork, DeliveryUnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var deliveryContext = scope.ServiceProvider.GetService<DeliveryContext>();
                deliveryContext.Database.EnsureCreated();
            }  
        }
    }
}
