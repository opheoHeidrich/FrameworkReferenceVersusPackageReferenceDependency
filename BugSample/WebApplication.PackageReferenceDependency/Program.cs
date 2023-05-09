using Microsoft.AspNetCore.Http.Connections;

namespace WebApplication.PackageReferenceDependency
{
    public class Program
    {
        public void UnusedMethod()
        {
            //this project references 'Microsoft.AspNetCore.Http.Connections.Common' as a dependency of 'Microsoft.AspNetCore.SignalR.Client',
            //this DLL WILL be copied during build, ignoring the framework reference, wich should overwrite it!
            //Explicitly: "C:\Program Files\dotnet\packs\Microsoft.AspNetCore.App.Ref\6.0.16\ref\net6.0\Microsoft.AspNetCore.Http.Connections.Common.dll"

            //Random call to something in 'Microsoft.AspNetCore.Http.Connections.Common' to ensure the reference is needed.
            _ = HttpTransportType.None;

            //Random call to something in 'Microsoft.AspNetCore.SignalR.Client' to ensure the reference is needed.
            Microsoft.AspNetCore.SignalR.Client.HubConnectionBuilderHttpExtensions.WithUrl(null, "");
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
}