using ManjaApp.Data.Data;
using ManjaApp.Data.Entities;
using ManjaApp.Data.Repositories;
using ManjaApp.Data.Repositories.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace ManjaApp.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
                options.UseLazyLoadingProxies();
            });
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient(typeof(ICrudRepository<>), typeof(CrudRepository<>));
            builder.Services.AddTransient<IManjaService, ManjaService>();
            builder.Services.AddTransient<ICommentService, CommentService>();
            builder.Services.AddTransient<ICategoryService, CategoryService>();
            builder.Services.AddTransient<IManjaRepository, ManjaRepository>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();
            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.
                    GetRequiredService<RoleManager<IdentityRole>>();
                var roles = new[]
                {
                    "Admin", "Member"
                };
                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.
                    GetRequiredService<UserManager<IdentityUser>>();
                string email = "ManjaBoss123@admin.com";
                string password = "Admin_123";
                if (await userManager.FindByEmailAsync(email) == null)
                {
                    var user = new IdentityUser();
                    user.UserName = email;
                    user.Email = email;
                    await userManager.CreateAsync(user, password);
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
            app.Run();
        }
    }
}