using System.Reflection;
using AutoMapper;
using GestranSuppliers.Application.Interfaces;
using GestranSuppliers.Infrastructure;
using GestranSuppliers.Infrastructure.Profiles;
using GestranSuppliers.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddTransient<ISupplierRepository, SupplierRepository>();
builder.Services.AddTransient<IAddressRepository, AddressRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var sqlServerConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DataContext>(opts => opts
    .UseSqlServer(sqlServerConnection));

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

var configuration = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<SupplierProfile>();
    cfg.AddProfile<AddressProfile>();
});
var mapper = configuration.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();