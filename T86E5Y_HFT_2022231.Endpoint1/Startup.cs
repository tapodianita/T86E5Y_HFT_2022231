using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T86E5Y_HFT_2022231.Logic.Classes;
using T86E5Y_HFT_2022231.Logic.Interfaces;
using T86E5Y_HFT_2022231.Models.Entities;
using T86E5Y_HFT_2022231.Repository.Database;
using T86E5Y_HFT_2022231.Repository.Interfaces;
using T86E5Y_HFT_2022231.Repository.ModelRepositories;

namespace T86E5Y_HFT_2022231.Endpoint1
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
      services.AddTransient<AirplaneDbContext>();
      services.AddTransient<IRepository<Airplane>, AirplaneRepository>();
      services.AddTransient<IRepository<Airline>, AirlineRepository>();
      services.AddTransient<IRepository<Flights>, FlightsRepository>();
      services.AddTransient<IRepository<Manufacturer>, ManufacturerRepository>();

      services.AddTransient<IAirplaneLogic, AirplaneLogic>();
      services.AddTransient<IAirlineLogic, AirlineLogic>();
      services.AddTransient<IFlightsLogic, FlightsLogic>();
      services.AddTransient<IManufacturerLogic, ManufacturerLogic>();

      services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "starter.Endpoint", Version = "v1" });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "starter.Endpoint v1"));
      }
      app.UseExceptionHandler(c => c.Run(async context =>
      {
        var exception = context.Features.Get<IExceptionHandlerPathFeature>().Error;
        var response = new { error = exception.Message };
        await context.Response.WriteAsJsonAsync(response);
      }));
      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
