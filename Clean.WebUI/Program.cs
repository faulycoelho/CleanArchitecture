using Clean.Domain.Account;
using static Clean.Infra.IoC.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
SeedUserRoles(app);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

void SeedUserRoles(IApplicationBuilder app)
{
    using (var serviceScope = app.ApplicationServices.CreateScope())
    {
        var seed = serviceScope.ServiceProvider
                               .GetService<ISeedUserRoleInitial>();
        seed.SeedRoles();
        seed.SeedUsers();
    }
}