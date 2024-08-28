using AMV_Travel;
using AMV_Travel.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n del servicio de base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registro de servicios de aplicaci�n
builder.Services.AddScoped<GestorReservasService>();

// Configuraci�n de controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuraci�n de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policyBuilder =>
        policyBuilder.AllowAnyOrigin()  // Permitir cualquier origen
                     .AllowAnyMethod()  // Permitir cualquier m�todo (GET, POST, etc.)
                     .AllowAnyHeader()); // Permitir cualquier encabezado
});

var app = builder.Build();
app.UseCors("AllowAllOrigins");

// Configuraci�n para entorno de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Aplicar la pol�tica CORS antes de Authorization
//app.UseCors("AllowReactApp");

app.UseAuthorization();

// Configuraci�n del enrutamiento
app.MapControllers();

app.Run();