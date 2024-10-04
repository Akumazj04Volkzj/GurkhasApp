using DBController;
using DBController.Controllers;
using GurkhasWebApp.Client.Pages;
using GurkhasWebApp.Components;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

//Set databaseconnection
builder.Services.AddDbContext<DBControllerCtx>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DataBaseConnection")));

//set dbcontext/controller
builder.Services.AddScoped<IMasterDBController, MasterDBController>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(GurkhasWebApp.Client._Imports).Assembly);

app.Run();
