using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.DurableTask;
using Microsoft.DurableTask.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer; // Add this namespace if not already present
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NCFApi.Infrastructure;
using NCFApi.Infrastructure.Repositories;
using NCFApi.Application.Services;
using NCFApi.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// ✅ Configure SQL Server Database Context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NCFConnectionor")));

// ✅ Register Repository & Service Layers
builder.Services.AddScoped<IDonorRepository, DonorRepository>();
builder.Services.AddScoped<IDonorService, DonorService>();

// ✅ Add Azure Durable Functions Support
builder.Services.AddDurableTaskClient();
builder.Services.AddFunctionsWorkerDefaults(); // Ensure the required NuGet package is installed

// ✅ Add Controllers & API Documentation (Swagger)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ✅ Configure Middleware Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();