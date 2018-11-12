using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NalaApplication.Data;
using NalaApplication.InterFaces;
using NalaApplication.Models;
using NalaApplication.Repositories;
using NalaApplication.Services;
using System.Threading.Tasks;

namespace NalaApplication
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
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials();
            }));
          
            services.AddDistributedMemoryCache();
            services.AddSession();
            // In production, the Angular files will be served from this directory
            services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("DefaultConnection"));
            services.AddTransient<CartsService>();
            services.AddTransient<ProductsService>();
            services.AddTransient<ProductsRepository>();
            services.AddTransient<CartsService>();
            services.AddTransient<CategoriesService>();
            services.AddTransient<OrdersService>();
            services.AddTransient<OrdersRepository>();
            services.AddTransient<ColorsService>();
            services.AddTransient<SizesService>();
            services.AddTransient<IGenericRepository<Category>, GenericRepository<Category>>();
            services.AddTransient<IGenericRepository<Color>, GenericRepository<Color>>();
            services.AddTransient<IGenericRepository<Size>, GenericRepository<Size>>();

            services.AddSpaStaticFiles(configuration =>
			{
				configuration.RootPath = "ClientApp/dist";
			});
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

        }

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public async void Configure(IApplicationBuilder app, IHostingEnvironment env, AppDbContext context)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				app.UseHsts();
			}
            app.UseSession();
            app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseSpaStaticFiles();
            app.UseCors("MyPolicy");
            app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller}/{action=Index}/{id?}");
			});

			app.UseSpa(spa =>
			{
				// To learn more about options for serving an Angular SPA from ASP.NET Core,
				// see https://go.microsoft.com/fwlink/?linkid=864501

				spa.Options.SourcePath = "ClientApp";

				if (env.IsDevelopment())
				{
					spa.UseAngularCliServer(npmScript: "start");
				}
			});

            await DataInitializer.Initializer(context);
		}
	}
}
