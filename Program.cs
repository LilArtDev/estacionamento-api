using EstacionamentoAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

// builder.Services.AddScoped<IEstabelecimentoRepository, EstabelecimentoRepository>();
// builder.Services.AddScoped<IVeiculoRepository, VeiculoRepository>();
// builder.Services.AddScoped<IEstabelecimentoService, EstabelecimentoService>();
// builder.Services.AddScoped<IVeiculoService, VeiculoService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }