using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyRecipeApp.Context;
using MyRecipeApp.Repositories;
using MyRecipeApp.Repositories.Implementations;
using MyRecipeApp.Repositories.Interfaces;
using MyRecipeApp.Services.Implementations;
using MyRecipeApp.Services.Interfaces;

namespace MyRecipeApp
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

            services.AddControllersWithViews();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "../MyRecipeApp.ClientApp/build";
            });

            services.AddCors(options =>
            {
                options.AddPolicy("Recipes",
                     builder => builder.WithOrigins("http://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });


            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddSwaggerGen();
            services.AddDbContext<MyRecipeAppDbContext>(options => options.UseSqlite(Configuration.GetValue<string>("ConnectionString")));

            this.InjectCustomDependencies(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();
            app.UseCors("Recipes");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "../MyRecipeApp.ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }

        private  IServiceCollection InjectCustomDependencies(IServiceCollection services)
        {
            services.AddTransient<IRecipeService, RecipeService>();
            services.AddTransient<IIngredientService, IngredientService>();

            services.AddTransient<IRecipeRepository, RecipeRepository>();
            services.AddTransient<IIngredientRepository, IngredientRepository>();

            return services;
        }
    }
}
