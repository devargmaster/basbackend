using Common.GenericsMethods;
using Common.GenericsMethods.GenericHandlers;
using Common.GenericsMethods.GenericResponse;
using Common.GenericsMethods.Queries;
using CoreWebApi.ApiData;
using CoreWebApi.Models.Entities;
using Infraestructure.Contexts;
using Infraestructure.Repositories;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore; 
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// --- Configuración de Servicios ---
var allowedHosts = builder.Configuration.GetSection("Cors:AllowedHosts").Get<List<string>>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policyBuilder =>
        {
            policyBuilder.WithOrigins(allowedHosts?.ToArray() ?? Array.Empty<string>())
                         .AllowAnyHeader()
                         .AllowAnyMethod();
        });
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BAS Challenge", Version = "v1" });
});


builder.Services.AddMediatR(cfg => {
    // Registra todos los handlers de los ensamblados especificados
    cfg.RegisterServicesFromAssembly(typeof(CreateHandler<>).Assembly);
});


builder.Services.AddScoped<IRepositoryFactory, RepositoryFactory>();
builder.Services.AddScoped<SqlRepository>();
builder.Services.AddScoped<IDbContext>(provider => provider.GetRequiredService<AppDbContext>());
builder.Services.AddScoped<IRepository, SqlRepository>();

var connectionString = builder.Configuration.GetConnectionString("SqlServerConnection") ?? builder.Configuration.GetSection("ConnectionString:SqlServerConnection").Value;
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));


// --- Construcción de la Aplicación ---
var app = builder.Build();

// --- Configuración del Pipeline de HTTP ---
app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "N5 Challenge v1");
    c.RoutePrefix = string.Empty; // Swagger en la raíz
});

app.UseRouting();
app.UseCors("AllowReactApp");
app.UseAuthorization();
app.MapControllers();

app.Run();