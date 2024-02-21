using BusinessClockApi.Services;
using Microsoft.AspNetCore.Mvc;
using static BusinessClockApi.Services.StandardBusinessClock;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IProvideTheBusinessClock, StandardBusinessClock>();
builder.Services.AddSingleton<ISystemTime, SystemTime>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapGet("/support-info", ([FromServices] IProvideTheBusinessClock clock) =>
{
    if (clock.IsOpen())

    {
        return new SupportInfoResponse("Graham", "555-1212");
    }
    else
    {
        return new SupportInfoResponse("TechSupportPros", "800-STUF-BROKE");
    }


});


app.Run();

public record SupportInfoResponse(string Name, string Phone);

public partial class Program { }

public interface IProvideTheBusinessClock
{

    bool IsOpen();
}


