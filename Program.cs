using AutoMapper;
using WebApplication1.Contexto;
using WebApplication1.Repositorios;
using WebApplication1.Repositorios.Interfaces;
using WebApplication1.Servišos;
using WebApplication1.Servišos.Interfaces;

public class program
{

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<IProfessorServiše, ProfessorServiše>();
        builder.Services.AddScoped<IProfessorRepositori, ProfessorRepositori>();
        builder.Services.AddScoped<IEnderešoRepositori, EnderešoRepositori>();
        builder.Services.AddScoped<IEnderešoServiše, EnderešoServiše>();
        builder.Services.AddScoped<IEscola, EscolaRepositori>();
        builder.Services.AddDbContext<SenaiContext>();
        builder.Services.AddScoped<IEscolaServiše, EscolaServiše>();

        MapperConfiguration mapperConfiguration = new(mapperConfiguration => { mapperConfiguration.AddMaps(new[] { "WebApplication1" }); });
        builder.Services.AddSingleton(mapperConfiguration.CreateMapper());

        var app = builder.Build();
        app.UseSwagger();
        app.UseSwaggerUI();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}