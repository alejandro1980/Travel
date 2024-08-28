using AMV_Travel;
using AMV_Travel.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuración del servicio de base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registro de servicios de aplicación
builder.Services.AddScoped<GestorReservasService>();

// Configuración de controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policyBuilder =>
        policyBuilder.AllowAnyOrigin()  // Permitir cualquier origen
                     .AllowAnyMethod()  // Permitir cualquier método (GET, POST, etc.)
                     .AllowAnyHeader()); // Permitir cualquier encabezado
});

var app = builder.Build();
app.UseCors("AllowAllOrigins");

// Configuración para entorno de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Aplicar la política CORS antes de Authorization
//app.UseCors("AllowReactApp");

app.UseAuthorization();

// Configuración del enrutamiento
app.MapControllers();

app.Run();