using MasGlobal.Employees.Mapper;
using MasGlobal.Employees.Models;
using MasGlobal.Employees.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;

namespace MasGlobal.Employees
{
    public class Startup
    {
        readonly string AllowSpecificOrigins = "_allowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(AllowSpecificOrigins,
                builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
            services.AddControllers();
            services
                .AddMvc(options =>
                {
                    options.InputFormatters.RemoveType<Microsoft.AspNetCore.Mvc.Formatters.SystemTextJsonInputFormatter>();
                    options.OutputFormatters.RemoveType<Microsoft.AspNetCore.Mvc.Formatters.SystemTextJsonOutputFormatter>();
                    options.EnableEndpointRouting = false;
                })
                .AddNewtonsoftJson(opts =>
                {
                    opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    opts.SerializerSettings.Converters.Add(new StringEnumConverter(new CamelCaseNamingStrategy()));
                })
                .AddXmlSerializerFormatters();
            services.AddHttpClient();
            services.Configure<Settings>(Configuration.GetSection(
                                       typeof(Settings).Name));
            services.AddSwaggerGen();

            //adding services
            services.AddScoped<IMasGlobalEmployeeApiService, MasGlobalEmployeeApiService>();
            services.AddScoped<ISalaryServiceFactory, SalaryServiceFactory>();
            services.AddScoped<HourlySalaryService>()
                        .AddScoped<ISalaryService, HourlySalaryService>(s => s.GetService<HourlySalaryService>());
            services.AddScoped<MonthtlySalaryService>()
                        .AddScoped<ISalaryService, MonthtlySalaryService>(s => s.GetService<MonthtlySalaryService>());
            services.AddScoped<IMasGlobalEmployeeService, MasGlobalEmployeeService>();
            services.AddScoped<IEmployeeMapperFactory, EmployeeMapperFactory>();
            services.AddAutoMapper(typeof(Startup));

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "masglobal.employees.web/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseSpaStaticFiles();

            app.UseMvc();

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "masglobal.employees.web";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
                else if (env.IsProduction())
                {
                    spa.UseReactDevelopmentServer(npmScript: "build");
                }
            });


            app.UseRouting();

            app.UseCors(AllowSpecificOrigins);

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MasGlobalEmployees V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
