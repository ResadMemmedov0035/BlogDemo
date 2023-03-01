using BlogDemo.Application;
using BlogDemo.Infrastructure;
using BlogDemo.Web.ErrorHandling;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseMiddleware<MvcExceptionHandlerMiddleware>();

if (!app.Environment.IsDevelopment())
{
    MvcExceptionHandlerMiddleware.IsDevelopment = false;
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
