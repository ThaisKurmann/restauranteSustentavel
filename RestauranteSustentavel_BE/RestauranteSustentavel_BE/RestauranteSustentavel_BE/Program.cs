

using RestauranteSustentavel_BE;
using RestauranteSustentavel_BE.Repository;
using RestauranteSustentavel_BE.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<BebidaRepository>();
builder.Services.AddSingleton<BebidaService>();

builder.Services.AddSingleton<SobremesaRepository>();
builder.Services.AddSingleton<SobremesaService>();

builder.Services.AddSingleton<IngredienteRepository>();
builder.Services.AddSingleton<IngredienteService>();

builder.Services.AddSingleton<PedidoRepository>();
builder.Services.AddSingleton<PedidoService>();

builder.Services.AddSingleton<PedidoSobremesaRepository>();

builder.Services.AddSingleton<PedidoBebidaRepository>();

builder.Services.AddSingleton<IngredientePratoRepository>();

builder.Services.AddSingleton<PratoRepository>();
builder.Services.AddSingleton<PratoService>();


builder.Services.AddSingleton<DbContext>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
/*
builder.Services.AddCors(options =>
{
    options.AddPolicy("Policy1",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200/",
                                "https://localhost:4200/").AllowAnyHeader()
                                .AllowAnyMethod();
        });
});
*/

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(option => option.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();
app.UseCors();
app.Run();
