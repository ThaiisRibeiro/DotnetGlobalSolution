using Aplication.Aplication;
using Aplication.Interface;
using Domain.Entities;
using Domain.Interface;
using Infrastructure.Configuration;
using Infrastructure.Repository.ContasEnergiaRepository;
using Infrastructure.Repository.PrecoEcologicoRepository;
using Infrastructure.Repository.UsuarioRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//1
var stringConexao = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521))) (CONNECT_DATA=(SERVER=DEDICATED)(SID=ORCL)));User Id=;Password=;";

builder.Services.AddDbContext<Context>
    (options => options.UseOracle(stringConexao));

//1


builder.Services.AddScoped<InterfaceUsuario, RepositoryUsuario>();
builder.Services.AddScoped<InterfacePrecoEcologico, RepositoryPrecoEcologico>();
builder.Services.AddScoped<InterfaceContasEnergia, RepositoryContasEnergia>();





builder.Services.AddScoped <InterfaceUsuarioApp, AppUsuario> ();

builder.Services.AddScoped<InterfacePrecoEcologicoApp, AppPrecoEcologico>();
builder.Services.AddScoped<InterfaceContasEnergiaApp, AppContasEnergia>();





/*services.AddSingleton (      typeof(InterfaceGenerica<>), typeof(RepositorioGenerico<>)       );
services.AddSingleton< InterfaceProduto, RepositorioProduto>();
services.AddSingleton<  InterfaceAppProduto, AppProduto>      ();*/

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
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
