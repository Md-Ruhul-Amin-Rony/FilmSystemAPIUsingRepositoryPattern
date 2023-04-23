using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Test_API_Interest.Contracts.IPersistance;
using Test_API_Interest.Persistence.Repositories;
using Test_API_Interest.TMDB;

namespace Test_API_Interest
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddTransient<IPerson, PersonRepository>();
            services.AddTransient<IGenre, GenreRepository>();
            services.AddTransient<IMovie, MovieRepository>();
            services.AddTransient<ITmdbApiClient, TmdbApiClient>();
            //services.AddScoped<DbContext, ApplicationDbContext>();

            //string assemblyName = typeof(ApplicationDbContext).Namespace;
            //x => x.MigrationsAssembly(assemblyName)

            services.AddDbContext<InterestingDbContext>(
                    options =>
                    {
                        options.UseSqlServer(Configuration.GetConnectionString("ContextConnection"));
                    });

            services.AddCors(options =>
            {
                options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
            });

            services.AddHttpClient();
            services.AddHttpContextAccessor();
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Interest");
                    c.RoutePrefix = string.Empty;
                });

            }

            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthentication();
            //app.UseAuthorization();
            app.UseCors("Open");


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
