using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using FlixOne.Models;


namespace FlixOne
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }
    
    public IConfiguration Configuration { get; }
    
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();

      services.AddTransient<IStoreRepository, EFStoreRepository>();

      services.AddDbContext<StoreDbContext>(opts => {
        opts.UseSqlServer(
          Configuration["ConnectionStrings:FlixOneConnection"]);
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseStatusCodePages();
        app.UseStaticFiles();
      }

      app.UseRouting();
      
      SeedData.EnsurePopulated(app);
      
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute("default", pattern: "{controller=Product}/{action=List}/{id?}");
        endpoints.MapDefaultControllerRoute();
      });

    }
  }
}
