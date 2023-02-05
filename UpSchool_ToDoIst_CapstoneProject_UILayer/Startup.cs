using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpSchool_ToDoIst_CapstoneProject_BusinessLayer.ValidationRules.AppUserValidation;
using UpSchool_ToDoIst_CapstoneProject_DataAccessLayer.Concrete;
using UpSchool_ToDoIst_CapstoneProject_DTOLayer.AppUserDtos;
using UpSchool_ToDoIst_CapstoneProject_EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using UpSchool_ToDoIst_CapstoneProject_BusinessLayer.DIContainer;
using FluentValidation.AspNetCore;
using MediatR;

namespace UpSchool_ToDoIst_CapstoneProject_UILayer
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
            //services.AddMediatR(typeof(Startup));
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            services.AddHttpClient();

            services.ContainerDependencies();

            services.AddDbContext<Context>();

            services.AddIdentity<AppUser, AppRole>()
                .AddDefaultTokenProviders()
               .AddEntityFrameworkStores<Context>();


            services.CustomizeValidator();

            services.AddControllersWithViews().AddFluentValidation();


            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                            .RequireAuthenticatedUser()//bu kýsým tüm sayfalarda yetkilendirme yani kullanýcý login olmadan hiçbir sayfaya eriþememesini saðlar
                            .Build();
                config.Filters.Add(new AuthorizeFilter(policy));

            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Login/Index";//kullanýcý login olmadan eriþmeye çalýþýrsa login sayfasýna yönlendirilmesini saðlar
            });

            services.AddAutoMapper(typeof(Startup));

            /*.AddErrorDescriber<CustomIdentityValidator>()*//*.AddDefaultTokenProviders();*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
