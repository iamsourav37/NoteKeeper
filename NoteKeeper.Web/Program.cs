using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NoteKeeper.Web.Models.Data;
using NoteKeeper.Web.Models.Domain.Account;
using NoteKeeper.Web.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<INote, NoteService>();


builder.Services.AddDbContext<ApplicationDBContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));


builder.Services.AddIdentity<UserProfile, ApplicationRole>(options =>
{
    options.Password.RequiredLength = 7;
    options.Password.RequireDigit = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;

})
    .AddEntityFrameworkStores<ApplicationDBContext>()
    .AddDefaultTokenProviders()
    .AddUserStore<UserStore<UserProfile, ApplicationRole, ApplicationDBContext, Guid>>()
    .AddRoleStore<RoleStore<ApplicationRole, ApplicationDBContext, Guid>>();






var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
