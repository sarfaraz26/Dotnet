using Asp.Versioning;
using Microsoft.OpenApi.Models;
using Product.Application.Handlers;
using Product.Application.Mappers;
using Product.Core.IRepositories;
using Product.Infrastructure.Extensions;
using Product.Infrastructure.Middlewares;
using Product.Infrastructure.Repositories;
using System.Reflection;


#region SERVICES
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddInfraServices(builder.Configuration);

// API Versioning
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen(setup =>
{
    setup.SwaggerDoc("v1", new OpenApiInfo { Title = "Product.API", Version = "v1" });
    setup.SwaggerDoc("v2", new OpenApiInfo { Title = "Product.API", Version = "v2" });
});


// Auto Mapper
builder.Services.AddAutoMapper(typeof(EmployeeMappingProfile).Assembly);
// ends

// MediatR  begins
var assemblies = new Assembly[]
{
    typeof(CreateEmployeeCommandHandler).Assembly,
    Assembly.GetExecutingAssembly(),
};
builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblies(assemblies));
// ends


//Repositories
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
#endregion



#region MIDDLEWARES
var app = builder.Build();

//Logging Middleware
app.UseMiddleware<LoggingMiddleware>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(setup =>
    {
        setup.SwaggerEndpoint("/swagger/v1/swagger.json", "Product.API v1");
        setup.SwaggerEndpoint("/swagger/v2/swagger.json", "Product.API v2");
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion