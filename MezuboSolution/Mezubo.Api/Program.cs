
using Mezubo.Application;
using Mezubo.Infraestructure;
using Sistran.Presentation.Api.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApiSwagger(builder.Configuration);
builder.AddApplication()
       .AddInfrastructure();
WebApplication app = builder.Build();


app.UseHttpsRedirection();
app.UseOpenApiSwagger();

if (builder.Configuration.GetValue<bool>("Authentication:Enabled"))
    app.MapControllers().RequireAuthorization();
else
    app.MapControllers();


app.Run();