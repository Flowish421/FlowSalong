using FlowSalong.Application.Common.Interfaces;
using FlowSalong.Application.Features.Customers.Commands;
using FlowSalong.Infrastructure.Persistence;
using FlowSalong.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ---------------------------
// DbContext (InMemory)
// ---------------------------
builder.Services.AddDbContext<FlowSalongDbContext>(options =>
    options.UseInMemoryDatabase("FlowSalongDb"));

// ---------------------------
// Repository
// ---------------------------
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

// ---------------------------
// MediatR version 12 – ny syntax
// ---------------------------
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateCustomerCommand>());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
