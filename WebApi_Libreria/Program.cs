using Microsoft.EntityFrameworkCore;
using WebApi_Libreria.Data;
using WebApi_Libreria.Mappings;
using WebApi_Libreria.Repositories;
using WebApi_Libreria.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. zzzzzz
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar DbContext el diablazo
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar repositorios jajajajaja
builder.Services.AddScoped<ILibroRepository, LibroRepository>();

// Registrar servicios xd
builder.Services.AddScoped<ILibroService, LibroService>();

// Agregar AutoMapper y el everest no tienen nada en contra de mi
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

// Configure the HTTP request pipeline. x
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

IApplicationBuilder applicationBuilder = app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Crear la base de datos automáticamente en esto solo es el desarrollo para que aclareimo ahi jajajaj
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.EnsureCreated();
}

app.Run();
