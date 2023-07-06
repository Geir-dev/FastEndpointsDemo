global using FastEndpoints;
using FastEndpoints.Swagger;
using EndpointsDemo.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddFastEndpoints();
#pragma warning disable CS0618 // Type or member is obsolete
builder.Services.AddSwaggerDoc(config =>
{
    config.Title = "Student API";
    config.Version = "v1";
    config.Description = "An API to expose all students in the database";
},
    tagIndex: 0,
    shortSchemaNames: true,
    removeEmptySchemas: true,
    addJWTBearerAuth: false
);
#pragma warning restore CS0618 // Type or member is obsolete
builder.Services.AddMvcCore().AddApiExplorer();

builder.Services.AddDbContext<StudentDbContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseFastEndpoints();
app.UseOpenApi();
app.UseSwaggerUi3(configure => configure.ConfigureDefaults());
app.Run();
