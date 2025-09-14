using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using System.Reflection;
using FlowSalong.Application.Common.Behaviors;
using FlowSalong.Application.Common.Mappings;
using FlowSalong.Application.Features.Customers.Commands;
using FlowSalong.Domain.Common.Interfaces;
using FlowSalong.Infrastructure.Persistence;
using FlowSalong.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine($"Environment: {builder.Environment.EnvironmentName}");

builder.Services.AddDbContext<FlowSalongDbContext>(options =>
    options.UseInMemoryDatabase("FlowSalongDb"));

builder.Services.AddScoped<IFlowSalongDbContext>(sp => sp.GetRequiredService<FlowSalongDbContext>());
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IStaffRepository, StaffRepository>();

builder.Services.AddMediatR(typeof(CreateCustomerCommand).Assembly);
builder.Services.AddAutoMapper(typeof(CommonMappingProfile).Assembly);
builder.Services.AddValidatorsFromAssemblyContaining<CreateCustomerCommand>();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

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
