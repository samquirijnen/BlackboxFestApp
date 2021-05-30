using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using BlackboxFest.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlackboxFest.Models;
using BlackboxFest.Data.Repositories;
using BlackboxFest.Data.UnitOfWork;
using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using BlackboxFest.Helpers;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace BlackboxFest
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
            services.AddControllersWithViews()
                .AddNewtonsoftJson(o => o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddHttpContextAccessor();
           services.AddSession(options => 
           {
               options.IdleTimeout = TimeSpan.FromMinutes(10);
               options.Cookie.HttpOnly = true;
               options.Cookie.IsEssential = true;
           
           });
            services.AddIdentity<CustomUser,IdentityRole>(options=> { options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false
              ;
            }).AddRoles<IdentityRole>()
                   .AddEntityFrameworkStores<ApplicationDbContext>()
                   .AddDefaultTokenProviders().AddDefaultUI();

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            var appSettings = Configuration.GetSection("AppSettings").Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication()
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddSwaggerGen(c=>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "APiBlackboxFest", Version = "v1" });
                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer",new string[0] }
                };
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement { 
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id= "Bearer"
                        }
                    },
                    new string[] {}
                }
                });
            });
          //  services.AddAuthorization(options => options.AddPolicy("Admin", policy => policy.RequireClaim("Manager")));
            services.AddControllersWithViews();
            services.AddNotyf(config => { config.DurationInSeconds = 15;config.IsDismissable = true;config.Position = NotyfPosition.TopRight;  }) ;
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddScoped<IGenericRepository<Artist>, GenericRepository<Artist>>();
            services.AddScoped<IGenericRepository<News>, GenericRepository<News>>();
            services.AddScoped<IGenericRepository<Gallery>, GenericRepository<Gallery>>();
            services.AddScoped<IGenericRepository<Concert>, GenericRepository<Concert>>();
            services.AddScoped<IGenericRepository<Stage>, GenericRepository<Stage>>();
            services.AddScoped<IGenericRepository<TypeTicket>, GenericRepository<TypeTicket>>();
            services.AddScoped<IGenericRepository<TicketOrder>, GenericRepository<TicketOrder>>();
            services.AddScoped<IGenericRepository<TimeSlot>, GenericRepository<TimeSlot>>();
            services.AddScoped<IGenericRepository<CustomUser>, GenericRepository<CustomUser>>();
            services.AddScoped<IGenericRepository<TicketOrderDetail>, GenericRepository<TicketOrderDetail>>();
            services.AddScoped<IGenericRepository<TicketShopCart>, GenericRepository<TicketShopCart>>();
            services.AddScoped<IGenericRepository<DateDayFestival>, GenericRepository<DateDayFestival>>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "APiBlackboxFest"); });
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.UseNotyf();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
          // CreateUserRoles(serviceProvider).Wait();
        }

        private async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            RoleManager<IdentityRole> RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            ApplicationDbContext Context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            IdentityResult roleResult;
            bool roleCheck = await RoleManager.RoleExistsAsync("Admin");
            if (!roleCheck)
            {
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin"));

            }
            IdentityUser user = Context.Users.FirstOrDefault(u => u.UserName == "Admin");
            if (user != null)
            {
                DbSet<IdentityUserRole<string>> roles = Context.UserRoles;
                IdentityRole adminRole = Context.Roles.FirstOrDefault(r => r.Name == "Admin");
                if (adminRole != null)
                {
                    if (!roles.Any(ur => ur.UserId == user.Id && ur.RoleId == adminRole.Id))
                    {
                        roles.Add(new IdentityUserRole<string>() { UserId = user.Id, RoleId = adminRole.Id });
                        Context.SaveChanges();
                    }
                }
            }
        }
    }
}
