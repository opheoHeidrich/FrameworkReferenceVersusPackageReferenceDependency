using Microsoft.AspNetCore.Http.Connections;

namespace WebApplication.FrameworkReference;

public class Program
{
    public void UnusedMethod()
    {
        //this project has a reference to the framework DLL 'Microsoft.AspNetCore.Http.Connections.Common', this DLL will not be copied during build.
        //Explicitly: "C:\Program Files\dotnet\packs\Microsoft.AspNetCore.App.Ref\6.0.16\ref\net6.0\Microsoft.AspNetCore.Http.Connections.Common.dll"

        //Random call to something in 'Microsoft.AspNetCore.Http.Connections.Common' to ensure the reference is needed.
        _ = HttpTransportType.None;
    }

    public static void Main(string[] args)
    {
        var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}