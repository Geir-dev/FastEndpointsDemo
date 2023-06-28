using FastEndpoints;
using FastEndpoints.Swagger;
using FastEndpointsDemo.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDocument();

builder.Services.AddDbContext<StudentDbContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseFastEndpoints();
app.UseOpenApi();
app.UseSwaggerUi3(c => c.ConfigureDefaults());
app.Run();
