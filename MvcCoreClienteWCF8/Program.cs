using MvcCoreClienteWCF8.Helpers;
using MvcCoreClienteWCF8.Repositories;
using MvcCoreClienteWCF8.Services;
using ServiceReference2;
using ServiceReferenceCatastro;
using ServiceReferenceCoches;
using ServiceReferenceEscenas;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<ServiceCountries>();
builder.Services.AddTransient<ServiceConversor>();
builder.Services.AddTransient<ServiceCatastro>();
builder.Services.AddTransient<CallejerodelasedeelectrónicadelcatastroSoapClient>();

builder.Services.AddTransient<MetodosVariosContractClient>();
builder.Services.AddTransient<ServiceMetodosVarios>();

builder.Services.AddTransient<CochesContractClient>();
builder.Services.AddTransient<ServiceCoches>();

builder.Services.AddTransient<EscenasContractClient>();
builder.Services.AddTransient<ServiceEscenas>();

builder.Services.AddTransient<RepositoryClientesXML>();
builder.Services.AddSingleton<HelperPathProvider>();

builder.Services.AddControllersWithViews();

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
