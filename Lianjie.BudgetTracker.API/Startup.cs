using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lianjie.BudgetTracker.ApplicationCore.Entities;
using Lianjie.BudgetTracker.ApplicationCore.RepositoryInterfaces;
using Lianjie.BudgetTracker.ApplicationCore.ServiceInterfaces;
using Lianjie.BudgetTracker.Infrastructure.Data;
using Lianjie.BudgetTracker.Infrastructure.Repositories;
using Lianjie.BudgetTracker.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Lianjie.BudgetTracker.API
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


            // !!! establish the connection !!! passing the options to the Dbcontext 
            services.AddDbContext<BudgetTrackerDbContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("BudgetTrackerDbConnection")
            ));

            services.AddScoped<IAsyncRepository<Income>, EfRepository<Income>>();
            services.AddScoped<IAsyncRepository<Expenditure>, EfRepository<Expenditure>>();
            services.AddScoped<IAsyncRepository<User>, EfRepository<User>>();



            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IIncomeRepository, IncomeRepository>();
            services.AddScoped<IExpenditureRepository, ExpenditureRepository>();


            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IIncomeService, IncomeService>();
            services.AddScoped<IExpenditureService, ExpenditureService>();



            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Lianjie.BudgetTracker.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lianjie.BudgetTracker.API v1"));
            }

            app.UseCors(builder =>
            {
                builder.WithOrigins(Configuration.GetValue<string>("clientSPAUrl")).AllowAnyHeader()
                    .AllowAnyMethod().AllowCredentials();
            });


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
