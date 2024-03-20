using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RWP.Data;
using RWP.Service;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<RWPContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RWPContext") ?? throw new InvalidOperationException("Connection string 'RWPContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IMovieService, MovieService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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

app.Run();
