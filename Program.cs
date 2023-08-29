using AplcacionLogistica.Data;
using AplcacionLogistica.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var cadenaConexionSQL = new ConexionBD(builder.Configuration.GetConnectionString("defaultConnection"));
builder.Services.AddSingleton(cadenaConexionSQL);
builder.Services.AddSingleton<IServicioCliente, ServicioCliente>();
builder.Services.AddSingleton<IServicioProducto, ServicioProducto>();
builder.Services.AddSingleton<IServicioPuertoBodega, ServicioPuertoBodega>();
builder.Services.AddSingleton<IServicioTransporte, ServicioTransporte>();
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
