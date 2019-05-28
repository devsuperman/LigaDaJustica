using LigaDaJustica.Data;
using Microsoft.AspNetCore.Mvc;
using LigaDaJustica.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LigaDaJustica
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<Contexto>(options => options.UseNpgsql(Configuration.GetConnectionString("Automatico")))
                .BuildServiceProvider();

            services.AddHttpContextAccessor();
            services.AddProgressiveWebApp(); 
            services.AddSession();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UsarCulturaBrasileira();
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();            
            app.UseMvcWithDefaultRoute();
        }        
    }
}
