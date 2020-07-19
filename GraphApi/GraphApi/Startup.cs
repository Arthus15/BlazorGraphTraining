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
            services.AddDbContext<TrainingContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("TrainingDb")));
            InjectGraphQLDependencies(services);
            InjectRepositories(services);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, TrainingContext trainingContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            InitializeDatabase(trainingContext);

            app.UseGraphiQLServer();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

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
        #endregion
    }
}
