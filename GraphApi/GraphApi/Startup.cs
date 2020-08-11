using GraphApi.GraphQLMiddleWare;
using GraphApi.GraphQLMiddleWare.Mutations;
using GraphApi.GraphQLMiddleWare.Queries;
using GraphApi.GraphQLMiddleWare.Types;
using GraphApi.Infraestructure;
using GraphApi.Infraestructure.IRepositories;
using GraphApi.Infraestructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net;

namespace GraphApi
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
            services.AddDbContext<TrainingContext>(opt => opt.UseSqlServer(BuildConnection()));
            InjectGraphQLDependencies(services);
            InjectRepositories(services);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();

            //Add Cors
            services.AddCors(options => options.AddPolicy("AllowAllDEV", p => p.WithOrigins("https://localhost:44349").AllowCredentials().AllowAnyMethod().AllowAnyHeader()));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, TrainingContext trainingContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAllDEV");

            InitializeDatabase(trainingContext);

            app.UseSwagger();

            app.UseGraphiQLServer();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "GraphQL API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        #region Private Methods
        private void InitializeDatabase(TrainingContext trainingContext)
        {
            if (trainingContext.Database.EnsureCreated())
            {
                trainingContext.Database.Migrate();
            }
        }

        private void InjectGraphQLDependencies(IServiceCollection services)
        {
            services.AddScoped<ContractType>();
            services.AddScoped<OperationType>();
            services.AddScoped<InspectionType>();
            services.AddScoped<GraphQLQuery>();
            services.AddScoped<ContractQuery>();
            services.AddScoped<ContractMutation>();
            services.AddScoped<InspectionQuery>();
            services.AddScoped<InspectionMutation>();
            services.AddScoped<OperationQuery>();
            services.AddScoped<OperationMutation>();
        }

        private void InjectRepositories(IServiceCollection services)
        {
            services.AddScoped<IContractRepository, ContractRepository>();
            services.AddScoped<IOperationRepository, OperationRepository>();
            services.AddScoped<IInspectionRepository, InspectionRepository>();
        }

        private string BuildConnection()
        {
            var connection = Configuration.GetConnectionString("TrainingDb");
            try
            {
                var dnHostAddress = Dns.GetHostAddresses(new Uri("http://docker.for.win.localhost").Host)[0].ToString();
                return string.Format(connection, dnHostAddress);
            }
            catch (Exception ex)
            {
                return string.Format(connection, "localhost");
            }
        }
        #endregion
    }
}
