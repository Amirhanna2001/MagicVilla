using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information() // Set the minimum log level to Information
    .WriteTo.Logger(lc => lc
        .Filter.ByIncludingOnly(evt => evt.MessageTemplate.Text.Contains("Message:")) // Only save messages that contain "specific keyword"
        .WriteTo.File(
            "log/WhatHappenedInTheSystem.txt",
            rollingInterval: RollingInterval.Day,
            rollOnFileSizeLimit: true,
            fileSizeLimitBytes: 1000000)) // Write to a file
    .CreateLogger();


builder.Host.UseSerilog();

builder.Services.AddControllers(options=> {
    options.ReturnHttpNotAcceptable = true;
    }).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();

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
