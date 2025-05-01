using CarlosM_LigaPro.Data;
using CarlosM_LigaPro.Interfaces;
using CarlosM_LigaPro.Repo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args); 
// Add services to the container.
builder.Services.AddDbContext<LigaProDbContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Repositories
builder.Services.AddScoped<iEquipoRepo, EquipoRepo>();

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

builder.Services.AddScoped<iEquipoRepo, EquipoRepo>();
