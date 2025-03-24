//añade la referencia al proyecto con la inyeccion de dependencias
using Infraestructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//cada configuración que se tenga que agregar se llama a través de Services

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureServices(builder.Configuration);

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