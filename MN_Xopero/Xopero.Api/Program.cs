using Serilog;
using Xopero.Api;
using Xopero.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddHttpLogging(logging => { });

builder.Services.AddApplicationConfiguration(builder.Configuration);
builder.Services.AddApplicationValidators();
builder.Services.AddApplicationImplementation();
builder.Services.AddHttpClientService();
builder.Services.AddGlobalErrorHandling();

builder.Logging.ClearProviders();
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseHttpLogging();

// Add Endpoints
app.MapApiEndpoints();
app.Run();

