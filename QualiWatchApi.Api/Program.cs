using QualiWatchApi.Api;
using QualiWatchApi.Application;
using QualiWatchApi.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddInfrastructure(builder.Configuration)
        .AddApplication();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    //app.UseHttpsRedirection();
    app.UseAuthentication();
    app.MapControllers();
    app.Run();
}


