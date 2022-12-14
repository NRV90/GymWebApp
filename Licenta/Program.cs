using Licenta.DAL;
using Licenta.MongoSettings;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDbUsers"));
builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDbSites"));

builder.Services.AddSingleton<MongoDBService>();
builder.Services.AddSingleton<MongoDBSiteService>();




// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option => {
    option.LoginPath = "/Autentificare";
    option.AccessDeniedPath = "/Autentificare/Denied";

    //option.Events = new CookieAuthenticationEvents()
    //{

    //    OnSigningIn = async context =>
    //    {
    //        var principal = context.Principal;
    //        if (principal.HasClaim(c => c.Type == ClaimTypes.NameIdentifier))
    //        {
    //            if (principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value == "bob")
    //            {
    //                var claimsIdentity = principal.Identity as ClaimsIdentity;
    //                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "User"));

    //            }

    //        }
    //        await Task.CompletedTask;
    //    },
    //    OnSignedIn = async context =>
    //    {
    //        await Task.CompletedTask;
    //    },
    //    OnValidatePrincipal = async context =>
    //    {
            
    //        await Task.CompletedTask;
    //    },





    //};

}



    );   

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
app.UseAuthentication();    
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
