using Microsoft.OpenApi.Models;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        //Vai adicionar o serviço de controllers
        builder.Services.AddControllers();

        //Adiciona serviço de autentificação
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultChallengeScheme = "JwtBearer";
            options.DefaultAuthenticateScheme = "JwtBearer";
        })

        .AddJwtBearer(options => { });//Paramos aqui, continuar na segunda.
        //Adiciona o gerador do swagger 
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "API filmes tarde",
                Description = "API para gerenciamento de filmes - introdução a sprnt 2 - backend API",
                Contact = new OpenApiContact
                {
                    Name = "Pedro Henrique",
                    Url = new Uri("https://github.com/Pedrohbedin/Pedrohbedin")
                }
            });

            // Configurar o Swagger para usar o arquivo XML gerado
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });

        var app = builder.Build();

        //Habilite o middleware para atender ao documento JSON gerado e à interface do usuário do Swagger
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        //Para atender à interface do usuário do Swagger na raiz do aplicativo
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            options.RoutePrefix = string.Empty;
        });

        //Mapeia os controllers 
        app.MapControllers();
        app.Run();
    }
}