using Microsoft.AspNetCore.Authentication.Cookies;
using Mvc_Projem.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Context>();

// claim
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opt =>
    {
        opt.LoginPath = "/Login/GirisYap"; // Giris yapmak icin yonlendirme
        

    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // kimlik dogrulama / Sen kimsin ?

app.UseAuthorization(); // yetki

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Birim}/{action=Index}/{id?}");

app.Run();
