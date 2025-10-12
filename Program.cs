using Microsoft.EntityFrameworkCore;
using techhelp.api.Data;
using techhelp.api.DTOs;
using techhelp.api.Models;
using techhelp.api.Profiles;
using techhelp.api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Serviço genérico para Cliente
builder.Services.AddScoped<IGenericService<Cliente, ClienteReadDto, ClienteCreateDto, ClienteUpdateDto>, GenericService<Cliente, ClienteReadDto, ClienteCreateDto, ClienteUpdateDto>>();
builder.Services.AddScoped<ClienteService>();

// Serviço genérico para Contratos
builder.Services.AddScoped<IGenericService<Contrato, ContratoReadDto, ContratoCreateDto, ContratoUpdateDto>, GenericService<Contrato, ContratoReadDto, ContratoCreateDto, ContratoUpdateDto>>();
builder.Services.AddScoped<ContratoService>();

// Serviço genérico para Tecnicos
builder.Services.AddScoped<IGenericService<Tecnico, TecnicoReadDto, TecnicoCreateDto, TecnicoUpdateDto>, GenericService<Tecnico, TecnicoReadDto, TecnicoCreateDto, TecnicoUpdateDto>>();
builder.Services.AddScoped<TecnicoService>();

// Serviço genérico para Especialidades
builder.Services.AddScoped<IGenericService<Especialidade, EspecialidadeReadDto, EspecialidadeCreateDto, EspecialidadeUpdateDto>, GenericService<Especialidade, EspecialidadeReadDto, EspecialidadeCreateDto, EspecialidadeUpdateDto>>();
builder.Services.AddScoped<EspecialidadeService>();


builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<MappingProfile>();
});

// Connection string do banco de dados (em appsettings.json)
var connectionString = builder.Configuration.GetConnectionString("localhost");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
