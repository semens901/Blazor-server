using BlazorServer.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.DependencyInjection;
using BlazorServer.Data;
using BlazorServer.Models;
using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using Blazorise.DataGrid;
using Blazorise.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();



builder.Services.AddDbContextFactory<BlazorServerContext>(opt =>
opt.UseSqlServer(builder.Configuration.GetConnectionString("BlazorServerContext") ?? throw new InvalidOperationException("Connection string 'BlazorServerContext' not found.")));
builder.Services.AddDbContext<BlazorServerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BlazorServerContext") ?? throw new InvalidOperationException("Connection string 'BlazorServerContext' not found.")));


//builder.Services.AddSqlServer<BlazorServerContext>(builder.Configuration.GetConnectionString("BlazorServerContext") ?? throw new InvalidOperationException("Connection string 'BlazorServerContext' not found."));
builder.Services
    .AddBlazorise( options =>
    {
        options.Immediate = true;
    } )
    .AddBootstrap5Providers()
    .AddFontAwesomeIcons();

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();

app.Run();
