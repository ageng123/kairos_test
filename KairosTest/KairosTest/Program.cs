using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using KairosTest.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<KairosTestContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("KairosTestContext") ?? throw new InvalidOperationException("Connection string 'KairosTestContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=T_BARANG}/{action=Index}/{id?}");

app.Run();
