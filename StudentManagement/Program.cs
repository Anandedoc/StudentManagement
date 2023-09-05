using Serilog;
using Services;
using StudentManagement.Util;

Log.Information("Starting up - pre init");


try
{
    var builder = WebApplication.CreateBuilder(args);

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

    Log.Information("App Starting Up");

    AuthProvider.Configure(builder.Services, builder.Configuration);
    SwaggerProvider.Configure(builder.Services);
    ComponentsRegistry.Configure(builder.Services);

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
    dbContext.Initialize();

    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
       
}
catch (Exception ex)
{
    Log.Error(ex.Message, ex);
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}

