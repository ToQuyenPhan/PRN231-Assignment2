using BusinessObject.Context;
using BusinessObject.Models;
using DataAccess.Repositories.GenericRepo;
using DataAccess.Repositories.ParticipatingProjectRepo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectParticipantManagementSystemAPI
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

            services.AddControllers();
            services.AddDbContext<ProjectParticipatingDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ProjectParticipatingManagementDB")));
            services.AddControllers().AddOData(option => 
            {
                option.Select().Filter().Count().OrderBy().Expand().AddRouteComponents("odata", GetEdmModel());
            });
            services.AddScoped<IGenericRepo<Department>, GenericRepo<Department>>();
            services.AddScoped<IGenericRepo<CompanyProject>, GenericRepo<CompanyProject>>();
            services.AddScoped<IGenericRepo<Employee>, GenericRepo<Employee>>();
            services.AddScoped<IGenericRepo<ParticipatingProject>, GenericRepo<ParticipatingProject>>();
            services.AddScoped<IParticipatingProjectRepo, ParticipatingProjectRepo>();
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjectParticipantManagementSystemAPI", Version = "v1" });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjectParticipantManagementSystemAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseODataBatching();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Department>("Departments");
            builder.EntitySet<CompanyProject>("CompanyProjects");
            builder.EntitySet<Employee>("Employees");
            builder.EntityType<ParticipatingProject>().HasKey(p => new {p.EmployeeID, p.CompanyProjectID});
            builder.EntitySet<ParticipatingProject>("ParticipatingProjects");
            return builder.GetEdmModel();
        }
    }
}
