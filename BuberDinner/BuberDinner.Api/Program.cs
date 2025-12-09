using BuberDinner.Api;
using BuberDinner.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
{
    builder.Services.AddPresentationService();
    builder.Services.AddApplicationService();
    builder.Services.AddInfrastructureService(builder.Configuration);

    builder.Services.AddEndpointsApiExplorer(); 
    builder.Services.AddSwaggerGen(); 
}

var app = builder.Build();

// Configure the HTTP request pipeline.
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger(); 
        app.UseSwaggerUI(); 
    }
  
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();

    app.Run();
}

